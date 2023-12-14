using System;

using R5T.T0132;


namespace R5T.L0072
{
    [FunctionalityMarker]
    public partial interface INowOperator : IFunctionalityMarker,
        L0066.INowOperator
    {
#pragma warning disable IDE1006 // Naming Styles
        public L0066.INowOperator _NetStandard2_1 => L0066.NowOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Chooses <see cref="Get_Now_Local"/> as the default.
        /// </summary>
        public new TimeOnly Get_Now()
        {
            var output = this.Get_Now_Local();
            return output;
        }

        public new TimeOnly Get_Now_Local()
        {
            var dateTime = _NetStandard2_1.Get_Now_Local();

            var output = Instances.TimeOnlyOperator.Get_TimeOnly(dateTime);
            return output;
        }

        public new TimeOnly Get_Now_Utc()
        {
            var dateTime = _NetStandard2_1.Get_Now_Utc();

            var output = Instances.TimeOnlyOperator.Get_TimeOnly(dateTime);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_Today_Local"/> as the default.
        /// </summary>
        public new DateOnly Get_Today()
        {
            var output = this.Get_Today_Local();
            return output;
        }

        public new DateOnly Get_Today_Local()
        {
            var dateTime = _NetStandard2_1.Get_Now_Local();

            var output = Instances.DateOnlyOperator.Get_DateOnly(dateTime);
            return output;
        }

        public new DateOnly Get_Today_Utc()
        {
            var dateTime = _NetStandard2_1.Get_Now_Utc();

            var output = Instances.DateOnlyOperator.Get_DateOnly(dateTime);
            return output;
        }
    }
}
