using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0072
{
    [FunctionalityMarker]
    public partial interface IDateOperator : IFunctionalityMarker,
        L0066.IDateOperator
    {
#pragma warning disable IDE1006 // Naming Styles
        public L0066.IDateOperator _L0066 => L0066.DateOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public DateOnly From_DD_MM_YYYY(int day, int month, int year)
            => this.From(year, month, day);

        public new DateOnly From(int year, int month, int day)
            => new(year, month, day);

        public DateOnly From(DateTime dateTime)
            => this.From(dateTime.Year, dateTime.Month, dateTime.Day);

        public new DateOnly From_YYYYMMDD(string yyyymmdd)
        {
            var output = this.Parse_Exact(
                yyyymmdd,
                Instances.DateTimeFormats.YYYYMMDD);

            return output;
        }

        public DateOnly From_YYYY_MM_DD_Dashed(string yyyy_mm_dd)
        {
            var output = this.Parse_Exact(
                yyyy_mm_dd,
                Instances.DateTimeFormats.YYYY_MM_DD_Dashed);

            return output;
        }

        public IEnumerable<DateOnly> Enumerate_Range_Inclusive(DateOnly start, DateOnly end)
        {
            var current = start;

            while(current <= end)
            {
                yield return current;

                current = Instances.DateOnlyOperator.Add_Day(current);
            }
        }

        public DateOnly[] Get_Range_Inclusive(DateOnly start, DateOnly end)
            => this.Enumerate_Range_Inclusive(start, end)
                .Now();

        public DateOnly[] Get_DaysOfYear(int year)
        {
            var firstDayOfYear = this.Get_FirstDayOfYear(year);
            var lastDayOfYear = this.Get_LastDayOfYear(year);

            var output = this.Get_Range_Inclusive(
                firstDayOfYear,
                lastDayOfYear);

            return output;
        }

        public DateOnly Get_FirstDayOfYear(int year)
            => this.From(year, 1, 1);

        public DateOnly Get_LastDayOfYear(int year)
            => this.From(year, 12, 31);

        public new DateOnly Get_NthFromLastDayOfWeek_OfMonth(int year, int month, int n, DayOfWeek dayOfWeek)
        {
            var output_DateTime = _L0066.Get_NthFromLastDayOfWeek_OfMonth(year, month, n, dayOfWeek);

            var output = this.From(output_DateTime);
            return output;
        }

        public new DateOnly Get_NthDayOfWeek_OfMonth(int year, int month, int n, DayOfWeek dayOfWeek)
        {
            var output_DateTime = _L0066.Get_NthDayOfWeek_OfMonth(year, month, n, dayOfWeek);

            var output = this.From(output_DateTime);
            return output;
        }

        public int Get_Year(DateOnly date)
            => date.Year;

        public new DateOnly GetToday_Local()
        {
            var todayLocalDateTime = _L0066.GetToday_Local();

            var todayLocal = Instances.DateOnlyOperator.From_DateTime(todayLocalDateTime);
			return todayLocal;
        }

        public new DateOnly GetToday_Utc()
        {
            var todayUtcDateTime = _L0066.GetToday_Utc();

            var todayUtc = Instances.DateOnlyOperator.From_DateTime(todayUtcDateTime);
            return todayUtc;
        }

        /// <summary>
		/// Chooses <see cref="GetToday_Local"/> as the default.
		/// </summary>
		public new DateOnly GetToday()
        {
            var today = this.GetToday_Local();
            return today;
        }

        public DateTime Get_Today_AsDateTime()
            => _L0066.Get_Today();

        public new DateOnly Get_Today()
            => this.GetToday();

        public DateOnly Get_Tomorrow()
            => this.GetTomorrow();

        public new DateOnly GetTomorrow_Local()
        {
            var todayLocalDateTime = _L0066.GetTomorrow_Local();

            var todayLocal = Instances.DateOnlyOperator.From_DateTime(todayLocalDateTime);
            return todayLocal;
        }

        public new DateOnly GetTomorrow_Utc()
        {
            var todayUtcDateTime = _L0066.GetTomorrow_Utc();

            var todayUtc = Instances.DateOnlyOperator.From_DateTime(todayUtcDateTime);
            return todayUtc;
        }

        /// <summary>
		/// Chooses <see cref="GetTomorrow_Local"/> as the default.
		/// </summary>
		public new DateOnly GetTomorrow()
            => this.GetTomorrow_Local();

        public bool Is_Weekend(DateOnly date)
        {
            var output = false
                || this.Is_Saturday(date)
                || this.Is_Sunday(date)
                ;

            return output;
        }

        public bool Is_Sunday(DateOnly date)
            => Instances.DateOnlyOperator.Is_Sunday(date);

        public bool Is_Saturday(DateOnly date)
            => Instances.DateOnlyOperator.Is_Saturday(date);

        public DateOnly Parse_Exact(
            string dateString,
            string formatString)
            => Instances.DateOnlyOperator.Parse_Exact(
                dateString,
                formatString);

        public DateOnly Get_PriorDay(DateOnly date)
            => this.Subtract_Days(date, 1);

        public DateOnly Subtract_Days(DateOnly date, int days)
            => date.AddDays(-days);

        public DateOnly Add_Days(DateOnly date, int days)
            => date.AddDays(days);

        public DateOnly Get_NextDay(DateOnly date)
            => this.Add_Days(date, 1);

        public string To_String_YYYYMMDD(DateOnly date)
            => Instances.DateOnlyOperator.To_String_YYYYMMDD(date);

        public string ToString_YYYY_MM_DD_Dashed(DateOnly date)
            => Instances.DateOnlyOperator.ToString_YYYY_MM_DD_Dashed(date);
    }
}
