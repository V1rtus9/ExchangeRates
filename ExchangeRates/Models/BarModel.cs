
namespace ExchangeRates
{
	public struct BarModel
	{
		public string date;
		public double open;
		public double high;
		public double low;
		public double close;
		public double volume;
		public double capitalization;

		public BarModel(string date, double open, double high, double low, double close, double volume, double cap)
		{
			this.date = date;
			this.open = open;
			this.high = high;
			this.low = low;
			this.close = close;
			this.volume = volume;
			this.capitalization = cap;
		}
	}
}
