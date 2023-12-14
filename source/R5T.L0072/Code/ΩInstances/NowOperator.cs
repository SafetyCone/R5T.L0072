using System;


namespace R5T.L0072
{
    public class NowOperator : INowOperator
    {
        #region Infrastructure

        public static INowOperator Instance { get; } = new NowOperator();


        private NowOperator()
        {
        }

        #endregion
    }
}
