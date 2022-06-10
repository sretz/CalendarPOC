using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarPOC
{
	internal static class Calendar
	{
		#region Fields
		private static DateTime day = DateTime.Now.Date;
		private static DateTime[] period;
		#endregion //Fields

		#region Properties
		public static DateTime Day => day;
		public static DateTime[] Period => period;
		#endregion //Properties

		#region Methods
		public static void SetGregorianYear(DateTime date)
		{
			var outset = date.AddDays(1 - date.DayOfYear);
			var ending = outset.AddYears(1).AddDays(-1);

			var days = ending.DayOfYear;
			period = new DateTime[days];

			date = outset;
			var i = 0;
			while (true)
			{
				period[i] = date;
				if (++i >= days)
				{
					break;
				}
				date = date.AddTicks(TimeSpan.TicksPerDay);
			}
		}
		#endregion //Methods
	}
}
