using System;


namespace R5T.L0072
{
    public class JsonOperator : IJsonOperator
    {
        #region Infrastructure

        public static IJsonOperator Instance { get; } = new JsonOperator();


        private JsonOperator()
        {
        }

        #endregion
    }
}
