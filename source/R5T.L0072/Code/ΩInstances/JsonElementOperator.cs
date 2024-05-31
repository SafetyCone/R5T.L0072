using System;


namespace R5T.L0072
{
    public class JsonElementOperator : IJsonElementOperator
    {
        #region Infrastructure

        public static IJsonElementOperator Instance { get; } = new JsonElementOperator();


        private JsonElementOperator()
        {
        }

        #endregion
    }
}
