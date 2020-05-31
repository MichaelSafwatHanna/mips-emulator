using System;
using System.Collections;
using System.Linq;

namespace MIPS.util
{
    public static class BinaryConverter
    {
        public static BitArray StringToBits(string str)
        {
            return new BitArray(str.Reverse().Select(c => c == '1').ToArray());
        }

        public static int BitsToInt(BitArray binary)
        {
            if (binary == null)
                throw new ArgumentNullException();

            if (binary.Length > 32)
                throw new ArgumentException("Must be at most 32 bits long");

            var result = new int[1];
            binary.CopyTo(result, 0);
            return result[0];
        }
    }
}
