using System;


namespace R5T.L0072
{
    public class TimeOnlyOperator : ITimeOnlyOperator
    {
        #region Infrastructure

        public static ITimeOnlyOperator Instance { get; } = new TimeOnlyOperator();


        private TimeOnlyOperator()
        {
        }

        #endregion
    }
}
