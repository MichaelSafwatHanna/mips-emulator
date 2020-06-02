using System.Collections;

namespace MIPS.util
{
    public static class BitwiseOperations
    {
        public static BitArray LogicalShl(BitArray source, int shft)
        {
            var shl2 = new BitArray(32);
            for (var i = 0; i < source.Length - shft; i++)
            {
                shl2[i + shft] = source[i];
            }

            return shl2;
        }

        public static BitArray ExtendSign(BitArray source)
        {
            var extension = new BitArray(32, source[source.Length - 1]);

            for (var i = 15; i >= 0; i--)
            {
                extension[i] = source[i];
            }

            return extension;
        }
    }
}
