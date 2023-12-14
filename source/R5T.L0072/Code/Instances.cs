using System;


namespace R5T.L0072
{
    public static class Instances
    {
        public static IDateOnlyOperator DateOnlyOperator => L0072.DateOnlyOperator.Instance;
        public static ITimeOnlyOperator TimeOnlyOperator => L0072.TimeOnlyOperator.Instance;
    }
}