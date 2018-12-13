using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLFlow.NET.Lib.Helpers;

namespace MLFlow.NET.Tests
{
    [TestClass]
    public class UnixDateTimeHelpersTests : TestBase
    {
        [TestMethod]
        public void DateTimeFromUnixTimestampMillisecondsShouldReturnCorrectDateTime()
        {

            var timestampinmiliseconds = 1544591489027;
            var datetime = (DateTimeOffset)DateTime.Parse("12/12/2018 5:11:29 AM +00:00");
            var convertedDatetime =
                UnixDateTimeHelpers.DateTimeFromUnixTimestampMilliseconds(timestampinmiliseconds);

            Assert.AreEqual(datetime.UtcDateTime.ToString(CultureInfo.InvariantCulture), convertedDatetime.UtcDateTime.ToString(CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void GetCurrentTimestampMillisecondsShouldReturnCorrectResult()
        {
            var datetime = DateTime.UtcNow;
            var timestampinmiliseconds = UnixDateTimeHelpers.GetCurrentTimestampMilliseconds();
            var convertedDatetime =
                UnixDateTimeHelpers.DateTimeFromUnixTimestampMilliseconds(timestampinmiliseconds);
            Assert.AreEqual(datetime.ToString(CultureInfo.InvariantCulture), convertedDatetime.UtcDateTime.ToString(CultureInfo.InvariantCulture));
        }
    }
}

