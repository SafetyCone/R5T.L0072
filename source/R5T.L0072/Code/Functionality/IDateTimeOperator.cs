using System;

using F10Y.T0011;

using R5T.T0132;


namespace R5T.L0072
{
    [FunctionalityMarker]
    public partial interface IDateTimeOperator : IFunctionalityMarker,
        L0066.IDateTimeOperator,
        F10Y.L0060.IDateTimeOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        L0066.IDateTimeOperator _L0066 => L0066.DateTimeOperator.Instance;

        [Ignore]
        F10Y.L0060.IDateTimeOperator _F10Y_L0060 => F10Y.L0060.DateTimeOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// Quality-of-life overload for <see cref="F10Y.L0060.IDateTimeOperator.From_DateAndTime(DateOnly, TimeOnly)"/>.
        /// </summary>
        DateTime To_DateTime(DateOnly dateOnly, TimeOnly timeOnly)
        {
            var dateTime = this.From_DateAndTime(dateOnly, timeOnly);
            return dateTime;
        }
    }
}
