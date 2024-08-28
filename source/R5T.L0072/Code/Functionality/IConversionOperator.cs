using System;

using R5T.T0132;


namespace R5T.L0072
{
    [FunctionalityMarker]
    public partial interface IConversionOperator : IFunctionalityMarker,
        L0066.IConversionOperator
    {
        public DateOnly ToDate(string dateString)
        {
            var output = DateOnly.Parse(dateString);
            return output;
        }
    }
}
