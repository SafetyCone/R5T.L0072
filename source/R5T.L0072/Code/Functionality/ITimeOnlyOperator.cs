using System;

using R5T.T0132;


namespace R5T.L0072
{
    [FunctionalityMarker]
    public partial interface ITimeOnlyOperator : IFunctionalityMarker
    {
        public TimeOnly From_DateTime(DateTime dateTime)
        {
            var timeOnly = TimeOnly.FromDateTime(dateTime);
            return timeOnly;
        }

        public TimeOnly Get_TimeOnly(DateTime dateTime)
        {
            var output = TimeOnly.FromDateTime(dateTime);
            return output;
        }
    }
}
