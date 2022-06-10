using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarPOC
{
	internal sealed class DayCell
	{
		#region Fields
		private readonly RadioButton view;
		private readonly View container;
		private readonly Label text;
		private readonly BoxView holidayOutset;
		private readonly BoxView holidayEnding;
		#endregion //Fields

		#region Constructors
		public DayCell(
			RadioButton view, View container,
			Label text,
			BoxView holidayOutset, BoxView holidayEnding)
		{
			this.view = view;
			this.container = container;
			this.text = text;
			this.holidayOutset = holidayOutset;
			this.holidayEnding = holidayEnding;
		}
		#endregion //Constructors

		#region Properties
		public RadioButton View => view;
		public View Container => container;
		#endregion //Properties
	}
}
