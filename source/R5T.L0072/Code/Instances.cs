using System;


namespace R5T.L0072
{
    public static class Instances
    {
        public static IDateOnlyOperator DateOnlyOperator => L0072.DateOnlyOperator.Instance;
        public static IDateOperator DateOperator => L0072.DateOperator.Instance;
        public static L0066.IDateTimeFormats DateTimeFormats => L0066.DateTimeFormats.Instance;
        public static IDateTimeOperator DateTimeOperator => L0072.DateTimeOperator.Instance;
        public static L0066.IDefaultOperator DefaultOperator => L0066.DefaultOperator.Instance;
        public static L0066.IFileOperator FileOperator => L0066.FileOperator.Instance;
        public static L0066.IFileStreamOperator FileStreamOperator => L0066.FileStreamOperator.Instance;
        public static L0066.IStringOperator StringOperator => L0066.StringOperator.Instance;
        public static ITimeOnlyOperator TimeOnlyOperator => L0072.TimeOnlyOperator.Instance;
        public static L0066.ITypeNameOperator TypeNameOperator => L0066.TypeNameOperator.Instance;
    }
}