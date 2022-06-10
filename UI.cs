using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Maui.Layouts;

namespace CalendarPOC
{
	internal static class UI
	{
		#region Fields
		private static Color holiColor = Colors.DeepSkyBlue;

		private static ControlTemplate template = new ControlTemplate(() => new ContentPresenter());
		#endregion //Fields

		#region Methods
		public static DayCell GregorianYearCell(DateTime dateTime)
		{
			return Cell(dateTime,
				dateTime.Day.ToString("00"));
		}

		private static DayCell Cell(DateTime dateTime, string text)
		{
			var radio = new RadioButton();
			radio.ControlTemplate = template;
			var container = new VerticalStackLayout();
			var label = new Label()
			{
				Text = text,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
			};
			container.Add(label);
			GetHoliday(dateTime, out var infoHolidayOutset, out var infoHolidayEnding);
			var holidays = new AbsoluteLayout()
			{
				HeightRequest = 1,
			};
			var holidayEnding = new BoxView()
			{
				CornerRadius = 0,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Fill,
			};
			if (infoHolidayEnding)
			{
				holidayEnding.Color = holiColor;
				holidayEnding.BackgroundColor = holiColor;
			}
			holidays.Add(holidayEnding);
			AbsoluteLayout.SetLayoutFlags(holidayEnding, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(holidayEnding, new Rect(0.5, 0.0, 1.0, 1.0));
			var holidayOutset = new BoxView()
			{
				CornerRadius = 0,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Fill,
			};
			if (infoHolidayOutset)
			{
				holidayOutset.Color = holiColor;
				holidayOutset.BackgroundColor = holiColor;
			}
			holidays.Add(holidayOutset);
			AbsoluteLayout.SetLayoutFlags(holidayOutset, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(holidayOutset, new Rect(0.0, 0.0, 0.5, 1.0));
			container.Add(holidays);
			radio.Content = container;
			var cell = new DayCell(radio, container, label, holidayOutset, holidayEnding);
			radio.Value = cell;
			return cell;
		}

		private static void GetHoliday(DateTime dateTime, out bool outset, out bool ending)
		{
			var month = dateTime.Month;
			var day = dateTime.Day;

			if (month == 01 && (day >= 01 && day <= 04))
			{
				outset = true;
				ending = true;
				return;
			}
			if (month == 03 && day == 15)
			{
				outset = true;
				ending = true;
				return;
			}
			if (month == 04 && (day >= 14 && day <= 21))
			{
				outset = true;
				ending = true;
				return;
			}
			if (month == 07 && (day >= 26 && day <= 28))
			{
				outset = true;
				ending = true;
				return;
			}
			if (month == 09 && day == 26)
			{
				outset = true;
				ending = true;
				return;
			}
			if (month == 10 && day == 04)
			{
				outset = false;
				ending = true;
				return;
			}
			if (month == 10 && day == 05)
			{
				outset = true;
				ending = false;
				return;
			}
			if (month == 10 && (day >= 10 && day <= 16))
			{
				outset = true;
				ending = true;
				return;
			}
			if (month == 12 && (day >= 18 && day <= 25))
			{
				outset = true;
				ending = true;
				return;
			}

			outset = false;
			ending = false;
		}
		#endregion //Methods
	}
}
