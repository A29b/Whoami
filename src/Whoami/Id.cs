using System;
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

            var bytes = BitConverter.GetBytes(ticks);
            if (BitConverter.IsLittleEndian)
                bytes = bytes.Reverse().ToArray();

            // exclude paddigs of zero.
            bytes = bytes.SkipWhile(x => x == byte.MinValue).ToArray();

            // turning
            var xor = bytes.Select(x => (byte)(x ^ byte.MaxValue)).ToArray();

            var id = BitConverter.ToString(xor).Replace("-", string.Empty).ToLower();
            return id;
        }
    }
}
