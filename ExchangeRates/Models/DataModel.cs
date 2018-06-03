using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Models
{
    public class DataModel
    {
		public static readonly DateTime defaultDate1 = new DateTime(2016, 01, 01);
		public static readonly DateTime defaultDate2 = new DateTime(2017, 12, 31);
		public static readonly List<BarContainer> Bars = new List<BarContainer>();
	}
}
