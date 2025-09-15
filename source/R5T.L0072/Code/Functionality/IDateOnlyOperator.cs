using System;

using F10Y.T0011;

using R5T.T0132;


namespace R5T.L0072
{
    [FunctionalityMarker]
    public partial interface IDateOnlyOperator : IFunctionalityMarker,
        F10Y.L0060.IDateOnlyOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0060.IDateOnlyOperator _F10Y_L0060 => F10Y.L0060.DateOnlyOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


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
    }
}
