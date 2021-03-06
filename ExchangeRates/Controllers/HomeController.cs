﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ExchangeRates.Models;

namespace ExchangeRates.Controllers
{
    public class HomeController : Controller
    {

		public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


		[HttpPost]
		public JsonResult Data(string symbol, string market, string date1, string date2)
		{

			DateTime d1 = StringToDateTime(date1, DataModel.DefaultDate1);
			DateTime d2 = StringToDateTime(date2, DataModel.DefaultDate2);

			if (DateTime.Compare(d1, d2) > 0)
					d1 = DataModel.DefaultDate1;

			string[] rows = AplhaVantage.RequestCryptocurrencyHistoricalData(symbol, market);


			for (int i = 1; i < rows.Length; i++)
			{
				string[] barData = rows[i].Split(',');

				if (barData.Length != 11)
					continue;

				DateTime barDateTmp = Convert.ToDateTime(barData[0]);

				if (IsOutOfDateRange(barDateTmp, d1, d2))
					continue;

				DataModel.Bars.Add(new BarModel(barDateTmp.ToString("dd/MM/yyyy"), Math.Round(Convert.ToDouble(barData[1]), 2),
										Math.Round(Convert.ToDouble(barData[2]), 2), Math.Round(Convert.ToDouble(barData[3]), 2),
										Math.Round(Convert.ToDouble(barData[4]), 2), Math.Round(Convert.ToDouble(barData[9]), 0),
										Math.Round(Convert.ToDouble(barData[10]), 0)));
			}

			return Json(new
			{
				DataModel.Bars
			});
		}

		private bool IsOutOfDateRange(DateTime bar, DateTime first, DateTime last)
		{
			int r1 = DateTime.Compare(bar, first);
			int r2 = DateTime.Compare(bar, last);

			if (r1 < 0 || r2 > 0)
				return true;

			return false;
		}

		private DateTime StringToDateTime(string date, DateTime defDate)
		{
			try
			{
				return Convert.ToDateTime(date);
			}
			catch (FormatException)
			{

				return defDate;
			}
		}

		public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
