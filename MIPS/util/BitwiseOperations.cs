using System.Collections;

namespace MIPS.util
{
    public static class BitwiseOperations
    {
        public static BitArray LogicalShl(BitArray source, int shft)
        {
            var shl2 = new BitArray(16);
            for (var i = 0; i < source.Length - shft; i++)
            {
                shl2[i + shft] = source[i];
            }

            return shl2;
        }
    }
}
