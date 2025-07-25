using System;

using R5T.T0132;


namespace R5T.L0072
{
    [FunctionalityMarker]
    public partial interface IDateOnlyOperator : IFunctionalityMarker
    {
        public DateOnly Add_Days(DateOnly date, int days)
            => date.AddDays(days);

        public DateOnly Add_Day(DateOnly date)
            => this.Add_Days(date, 1);

        public DateOnly Add_Years(DateOnly date, int years)
            => date.AddYears(years);

        public DateOnly Add_Year(DateOnly date)
            => this.Add_Years(date, 1);

        public DateOnly Subtract_Year(DateOnly date)
            => this.Add_Years(date, -1);

        public string Format(
            DateOnly date,
            string formatTemplate)
            => Instances.StringOperator.Format(
                formatTemplate,
                date);

        public DateOnly From_DateTime(DateTime dateTime)
        {
            var dateOnly = DateOnly.FromDateTime(dateTime);
            return dateOnly;
        }

        public DateTime To_DateTime(DateOnly date)
        {
            var output = Instances.DateTimeOperator.From(
                date.Year,
                date.Month,
                date.Day,
                0, 0, 0);

            return output;
        }

        public DateOnly Get_DateOnly(DateTime dateTime)
        {
            var output = DateOnly.FromDateTime(dateTime);
            return output;
        }

        public DateOnly GetToday_Local()
            => Instances.DateOperator.GetToday_Local();


        public DateOnly GetToday_Utc()
            => Instances.DateOperator.GetToday_Utc();

        /// <summary>
        /// Chooses <see cref="GetToday_Local"/> as the default.
        /// </summary>
        public DateOnly GetToday()
        {
            var today = this.GetToday_Local();
            return today;
        }

        public DateOnly GetTomorrow_Local()
            => Instances.DateOperator.GetTomorrow_Local();

        public DateOnly GetTomorrow_Utc()
            => Instances.DateOperator.GetTomorrow_Utc();

        /// <summary>
        /// Chooses <see cref="GetTomorrow_Local"/> as the default.
        /// </summary>
        public DateOnly GetTomorrow()
        {
            var today = this.GetTomorrow_Local();
            return today;
        }

        public bool Is_Saturday(DateOnly date)
            => this.Is_DayOfWeek(
                date,
                DayOfWeek.Saturday);

        public bool Is_Sunday(DateOnly date)
            => this.Is_DayOfWeek(
                date,
                DayOfWeek.Sunday);

        public bool Is_DayOfWeek(
            DateOnly date,
            DayOfWeek dayOfWeek)
            => date.DayOfWeek == dayOfWeek;

        public DateOnly Parse_Exact(
            string dateOnlyString,
            string formatString)
        {
            var output = DateOnly.ParseExact(
                dateOnlyString,
                formatString);

            return output;
        }

        /// <inheritdoc cref="L0066.IDateTimeFormatTemplates.YYYYMMDD"/>
        public string To_String_YYYYMMDD(DateOnly date)
            => this.Format(
                date,
                Instances.DateTimeFormatTemplates.YYYYMMDD);

        /// <inheritdoc cref="L0066.IDateTimeFormatTemplates.YYYY_MM_DD_Dashed"/>
        public string ToString_YYYY_MM_DD_Dashed(DateOnly date)
            => this.Format(
                date,
                Instances.DateTimeFormatTemplates.YYYY_MM_DD_Dashed);
    }
}
