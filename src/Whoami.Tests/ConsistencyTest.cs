using System;
using Xunit;

namespace Whoami.Tests
{
    public class ConsistencyTest
    {
        [Theory]
        [InlineData("2019/07/01 10:00:00 +09:00", "fe9454f4497f")]
        [InlineData("0001/01/01 0:00:00 +00:00", "00003883122cd7ff")]
        [InlineData("9999/12/31 23:59:59 +00:00", "19882de027e7")]
        public void IdIsDateTime(string dateTimeString, string expected)
        {
            var dateTime = DateTimeOffset.Parse(dateTimeString);
            var id = Id.Generate(dateTime);

            Assert.Equal(expected, id);
        }
    }
}
