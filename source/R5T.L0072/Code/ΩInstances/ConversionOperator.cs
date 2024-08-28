using System;


namespace R5T.L0072
{
    public class ConversionOperator : IConversionOperator
    {
        #region Infrastructure

        public static IConversionOperator Instance { get; } = new ConversionOperator();


        private ConversionOperator()
        {
        }

        #endregion
    }
}
