using System;

using R5T.T0132;


namespace R5T.L0072
{
    [FunctionalityMarker]
    public partial interface IDateTimeOperator : IFunctionalityMarker,
        L0066.IDateTimeOperator
    {
        public DateTime From_DateAndTime(DateOnly dateOnly, TimeOnly timeOnly)
        {
            var dateTime = dateOnly.ToDateTime(timeOnly);
            return dateTime;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="From_DateAndTime(DateOnly, TimeOnly)"/>.
        /// </summary>
        public DateTime To_DateTime(DateOnly dateOnly, TimeOnly timeOnly)
        {
            var dateTime = this.From_DateAndTime(dateOnly, timeOnly);
            return dateTime;
        }
    }
}
