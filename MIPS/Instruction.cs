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
        public BitArray Function { get; }
        public BitArray Offset { get; }

        // Intervals
        public BitArray I11_15 { get; }
        public BitArray I16_20 { get; }
        public BitArray I16_31 { get; }

        // Op Codes
        private const int ROpCode = 0;
        private const int JOpCode = 2;
        private const int JOpCode2 = 3;


        public Instruction(string instruction)
        {
            Opcode = BinaryConverter.StringToBits(instruction.Substring(0, 6));
            var opcodeComparer = BinaryConverter.BitsToInt(Opcode);

            switch (opcodeComparer)
            {
                case ROpCode:
                    Type = Format.R;
                    Rs = BinaryConverter.StringToBits(instruction.Substring(6, 5));
                    Rt = BinaryConverter.StringToBits(instruction.Substring(11, 5));
                    Rd = BinaryConverter.StringToBits(instruction.Substring(16, 5));
                    Shamt = BinaryConverter.StringToBits(instruction.Substring(21, 5));
                    Function = BinaryConverter.StringToBits(instruction.Substring(26, 6));
                    break;
                case JOpCode:
                case JOpCode2:
                    Type = Format.J;
                    Offset = BinaryConverter.StringToBits(instruction.Substring(6, 26));
                    break;
                default:
                    Type = Format.I;
                    Rs = BinaryConverter.StringToBits(instruction.Substring(6, 5));
                    Rt = BinaryConverter.StringToBits(instruction.Substring(11, 5));
                    Offset = BinaryConverter.StringToBits(instruction.Substring(16, 16));
                    break;
            }

            I11_15 = BinaryConverter.StringToBits(instruction.Substring(11, 5));
            I16_20 = BinaryConverter.StringToBits(instruction.Substring(16, 5));
            I16_31 = BinaryConverter.StringToBits(instruction.Substring(16, 16));
        }
    }

    public enum Format
    {
        R,
        I,
        J
    }
}
