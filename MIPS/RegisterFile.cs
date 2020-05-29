namespace MIPS
{
    public class RegisterFile
    {
        public int[] Registers = new int[32];
        public int ReadReg1;
        public int ReadReg2;
        public int WriteReg;
        public int WrData;
        public bool RegWrite;
        public int ReadData1 => Registers[ReadReg1];
        public int ReadData2 => Registers[ReadReg2];

        public RegisterFile()
        {
            for (var i = 1; i < Registers.Length; i++)
            {
                Registers[i] = 100 + i;
            }
        }

        public void WriteData()
        {
            if (RegWrite)
                Registers[WriteReg] = WrData;
        }
    }
}