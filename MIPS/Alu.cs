using System.Collections;
using MIPS.util;

namespace MIPS
{
    class Alu
    {
        public int Data1 { get; set; }
        public int Data2 { get; set; }
        public bool ZeroFlag { get; set; }
        public int Result { get; set; }

        public void Compute(BitArray operation)
        {
            var opToInt = BinaryConverter.BitsToInt(operation);
            if (opToInt == BinaryConverter.BitsToInt(AluOps.AND))
            {
                Result = Data1 & Data2;
            }
            else if(opToInt == BinaryConverter.BitsToInt(AluOps.OR))
            {
                Result = Data1 | Data2;
            }
            else if (opToInt == BinaryConverter.BitsToInt(AluOps.ADD))
            {
                Result = Data1 + Data2;
            }
            else if (opToInt == BinaryConverter.BitsToInt(AluOps.SUB))
            {
                Result = Data1 - Data2;
            }

            ZeroFlag = (Result == 0);
        }
    }

    internal class AluOps
    {
        public static readonly BitArray AND = new BitArray(new[] { false, false, false });
        public static readonly BitArray OR = new BitArray(new[] { true, false, false });
        public static readonly BitArray ADD = new BitArray(new[] { false, true, false });
        public static readonly BitArray SUB = new BitArray(new[] { false, true, true });
    }
}
