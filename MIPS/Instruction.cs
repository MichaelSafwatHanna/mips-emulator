using System.Collections;
using System.Linq;
using MIPS.util;

namespace MIPS
{
    public class Instruction
    {
        public Format Type { get; }
        public BitArray Opcode { get; }
        public BitArray Rs { get; }
        public BitArray Rt { get; }
        public BitArray Rd { get; }
        public BitArray Shamt { get; }
        public BitArray Function { get; } = new BitArray(6);
        public BitArray Offset { get; }

        // Intervals
        public BitArray I15_11 { get; }
        public BitArray I20_16 { get; }
        public BitArray I15_0 { get; }

        // Op Codes
        private const int ROpCode = 0;
        private const int JOpCode = 2;
        private const int JOpCode2 = 3;


        public Instruction(string instruction)
        {
            Opcode = BinaryConverter.StringToBits(instruction.Substring(26, 6));
            var opcodeComparer = BinaryConverter.BitsToInt(Opcode);

            switch (opcodeComparer)
            {
                case ROpCode:
                    Type = Format.R;
                    Rs = BinaryConverter.StringToBits(instruction.Substring(21, 5));
                    Rt = BinaryConverter.StringToBits(instruction.Substring(16, 5));
                    Rd = BinaryConverter.StringToBits(instruction.Substring(11, 5));
                    Shamt = BinaryConverter.StringToBits(instruction.Substring(6, 5));
                    Function = BinaryConverter.StringToBits(instruction.Substring(0, 6));
                    break;
                case JOpCode:
                case JOpCode2:
                    Type = Format.J;
                    Offset = BinaryConverter.StringToBits(instruction.Substring(0, 26));
                    break;
                default:
                    Type = Format.I;
                    Rs = BinaryConverter.StringToBits(instruction.Substring(21, 5));
                    Rt = BinaryConverter.StringToBits(instruction.Substring(16, 5));
                    Offset = BinaryConverter.StringToBits(instruction.Substring(0, 16));
                    break;
            }

            I15_11 = BinaryConverter.StringToBits(instruction.Substring(11, 5));
            I20_16 = BinaryConverter.StringToBits(instruction.Substring(16, 5));
            I15_0 = BinaryConverter.StringToBits(instruction.Substring(0, 16));
        }
    }

    public enum Format
    {
        R,
        I,
        J
    }
}
