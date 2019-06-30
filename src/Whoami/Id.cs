using System;
using System.Collections.Generic;
using System.Linq;

namespace Whoami
{
    public class Id
    {
        /// <summary>
        /// Generate identity which is corresponded date and time.
        /// </summary>
        public static string Generate(DateTimeOffset datetime)
        {
            var ticks = datetime.ToUniversalTime().ToUnixTimeMilliseconds();

            IEnumerable<byte> bytes = BitConverter.GetBytes(ticks);
            if (BitConverter.IsLittleEndian)
                bytes = bytes.Reverse();

            // exclude paddigs of zero.
            bytes = bytes.SkipWhile(x => x == byte.MinValue);

            // turning as xor
            bytes = bytes.Select(x => (byte)(x ^ byte.MaxValue));

            var id = BitConverter.ToString(bytes.ToArray()).Replace("-", string.Empty).ToLower();
            return id;
        }
    }
}
