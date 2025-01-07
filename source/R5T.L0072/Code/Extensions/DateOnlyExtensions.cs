using System;


namespace R5T.L0072.Extensions
{
    public static class DateOnlyExtensions
    {
        public static bool Is_Saturday(this DateOnly date)
            => Instances.DateOnlyOperator.Is_Saturday(date);

        public static bool Is_Sunday(this DateOnly date)
            => Instances.DateOnlyOperator.Is_Sunday(date);
    }
}
