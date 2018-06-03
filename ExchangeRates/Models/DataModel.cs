using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Models
{
    public class DataModel
    {
		public static  DateTime DefaultDate1 { get; } = new DateTime(2016, 01, 01);
		public static  DateTime DefaultDate2 { get; } = new DateTime(2017, 12, 31);
		public static  List<BarModel> Bars { get; set; } = new List<BarModel>();
	}
}
