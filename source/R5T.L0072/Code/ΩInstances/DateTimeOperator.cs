using System;


namespace R5T.L0072
{
    public class DateTimeOperator : IDateTimeOperator
    {
        #region Infrastructure

        public static IDateTimeOperator Instance { get; } = new DateTimeOperator();


        private DateTimeOperator()
        {
        }

        #endregion
    }
}
