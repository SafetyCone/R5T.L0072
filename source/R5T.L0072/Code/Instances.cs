using System;


namespace R5T.L0072
{
    public static class Instances
    {
        public static IDateOnlyOperator DateOnlyOperator => L0072.DateOnlyOperator.Instance;
        public static L0066.IFileOperator FileOperator => L0066.FileOperator.Instance;
        public static L0066.IFileStreamOperator FileStreamOperator => L0066.FileStreamOperator.Instance;
        public static ITimeOnlyOperator TimeOnlyOperator => L0072.TimeOnlyOperator.Instance;
    }
}