using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ExchangeRates
{
	public static class AplhaVantage
	{
		private static readonly string API_KEY = "Y3NSQOSLO04NVEMD";
		private static readonly string URL_BASE = "https://www.alphavantage.co/query?function=DIGITAL_CURRENCY_DAILY&symbol=";

		public static string[] RequestCryptocurrencyHistoricalData(string symbol, string market)
		{
			string url = CreateURL(symbol, market);
			string rawData = GetCSV(url);
			string[] rows = rawData.Split('\n');

			return rows;
		}


		private static string GetCSV(string url)
		{
			HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

			StreamReader Stream = new StreamReader(resp.GetResponseStream());

			string results = Stream.ReadToEnd();

			Stream.Close();
			resp.Close();

			return results;
		}

		private static string CreateURL(string symbol, string market)
		{
			return URL_BASE + symbol + "&market=" + market + "&apikey=" + API_KEY + "&datatype=csv";
		}

	}
}
