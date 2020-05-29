using System.Collections.Generic;

namespace MIPS
{
    public class RegisterFile
    {
        private List<int> _registers = new List<int>(32);
        public static int ReadReg1;
        public static int ReadReg2;
        public static int WriteReg;
        public static bool RegWrite;
        public int ReadData1 => _registers[ReadReg1];
        public int ReadData2 => _registers[ReadReg2];

        public RegisterFile()
        {
            for (var i = 1; i < _registers.Count -1; i++)
            {
                _registers[i] = 100 + i;
            }
        }

        public void WriteData(int data)
        {
            if (RegWrite)
                _registers[WriteReg] = data;
        }
    }
}
