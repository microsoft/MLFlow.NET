using System;
using System.Collections.Generic;
using System.Text;

namespace MLFlow.NET.Lib.Helpers
{
    public static class UnixDateTimeHelpers
    {
        public static long GetCurrentTimestampMilliseconds()
        {
            return ((DateTimeOffset) DateTime.UtcNow).ToUnixTimeMilliseconds();
        }

        public static DateTimeOffset DateTimeFromUnixTimestampMilliseconds(long milliseconds)
        {
            return DateTimeOffset.FromUnixTimeMilliseconds(milliseconds);
        }

    }
}
