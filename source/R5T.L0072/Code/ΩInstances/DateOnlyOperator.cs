using System;


namespace R5T.L0072
{
    public class DateOnlyOperator : IDateOnlyOperator
    {
        #region Infrastructure

        public static IDateOnlyOperator Instance { get; } = new DateOnlyOperator();


        private DateOnlyOperator()
        {
        }

        #endregion
    }
}
