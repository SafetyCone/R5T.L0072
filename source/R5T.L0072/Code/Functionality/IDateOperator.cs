using System;

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

        public DateOnly Parse_Exact(
            string dateString,
            string formatString)
            => Instances.DateOnlyOperator.Parse_Exact(
                dateString,
                formatString);

        public string ToString_YYYY_MM_DD_Dash(DateOnly date)
            => Instances.DateOnlyOperator.ToString_YYYY_MM_DD_Dash(date);
    }
}
