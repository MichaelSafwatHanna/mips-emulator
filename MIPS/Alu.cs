using System.Collections;

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
            if (operation.Equals(AluOps.OR))
            {
                Result = Data1 | Data2;
            }
            else if (operation.Equals(AluOps.SUB))
            {
                Result = Data1 - Data2;
            }

            ZeroFlag = (Result == 0);
        }
    }
}
