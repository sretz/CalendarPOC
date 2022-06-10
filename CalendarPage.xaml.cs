using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CalendarPOC;

public partial class CalendarPage : ContentPage
{
	private readonly Dictionary<DateTime, DayCell> cells = new Dictionary<DateTime, DayCell>();

	public CalendarPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();

		Calendar.SetGregorianYear(Calendar.Day);

		CellsAdd();
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();

		CellsClear();
	}

	private void CellsAdd()
	{
		var day = Calendar.Day;
		this.period.Text = day.ToString("yyyy");
		var i = 0;
		for (var rs = 01; rs <= 22; rs += 7)
		{
			for (var cs = 00; cs <= 16; cs += 8)
			{
				i = CellsAddMonth(i, rs, cs);
			}
		}
	}

	private int CellsAddMonth(int i, int rs, int cs)
	{
		var period = Calendar.Period;
		var info = period[i];
		var month = info.Month;
		var row = 0;
		var col = (int)info.DayOfWeek;
		while (true)
		{
			CellAdd(info, rs + row, cs + col);
			//Next
			++i;
			if (i >= period.Length)
			{
				return i;
			}
			info = period[i];
			if (info.Month != month)
			{
				return i;
			}
			//Prepare
			if (col == 6)
			{
				++row;
				col = 0;
			}
			else
			{
				++col;
			}
		}
	}

	private void CellAdd(DateTime dateTime, int row, int col)
	{
#if DEBUG
		var watch = Stopwatch.StartNew();
#endif //DEBUG
		var cell = UI.GregorianYearCell(dateTime);
#if DEBUG
		watch.Stop();
		var elapsedCreate = watch.Elapsed;
#endif //DEBUG
		cells.Add(dateTime, cell);
#if DEBUG
		watch.Restart();
#endif //DEBUG
		calendar.Add(cell.View, col, row);
#if DEBUG
		watch.Stop();
		var elapsedAdded = watch.Elapsed;
		Debug.WriteLine("{0:000} Create: {1} Added: {2}",
			dateTime.DayOfYear, elapsedCreate, elapsedAdded);
#endif //DEBUG
	}

	private void CellsClear()
	{
		foreach (var cell in cells.Values)
		{
			calendar.Remove(cell.View);
		}
		cells.Clear();
	}
}