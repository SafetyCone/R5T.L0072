using System;

using R5T.T0132;


namespace R5T.L0072
{
    [FunctionalityMarker]
    public partial interface IDateOnlyOperator : IFunctionalityMarker
    {
        public DateOnly From_DateTime(DateTime dateTime)
        {
            var dateOnly = DateOnly.FromDateTime(dateTime);
            return dateOnly;
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

        public DateOnly Parse_Exact(
            string dateOnlyString,
            string formatString)
        {
            var output = DateOnly.ParseExact(
                dateOnlyString,
                formatString);

            return output;
        }

        public string ToString_YYYY_MM_DD_Dash(DateOnly date)
        {
            var representation = $"{date:yyyy-MM-dd}";
            return representation;
        }
    }
}
