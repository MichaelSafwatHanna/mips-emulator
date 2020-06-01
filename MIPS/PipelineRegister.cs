using System.Collections;

namespace MIPS
{
    public class PipelineRegister
    {
    }

    public class IfId : PipelineRegister
    {
        public uint Pc;
        public string Instruction;
    }

    public class IdEx : PipelineRegister
    {
        public uint Pc;
        public int ReadData1;
        public int ReadData2;
        public BitArray Rt = new BitArray(5);
        public BitArray Rd = new BitArray(5);
        public BitArray Offset = new BitArray(5);
        public bool RegWrite;
        public bool MemToReg;
        public bool Branch;
        public bool MemRead;
        public bool MemWrite;
        public bool RegDest;
        public BitArray AluOp = new BitArray(5);
        public bool AluSrc;
    }

    public class ExMem : PipelineRegister
    {
        public uint PcJump;
        public bool ZeroFlag;
        public int Result;
        public int ReadData2;
        public BitArray RegDest = new BitArray(5);
        public bool RegWrite;
        public bool MemToReg;
        public bool Branch;
        public bool MemRead;
        public bool MemWrite;
    }

    public class MemWb : PipelineRegister
    {
        public int ReadData;
        public int Result;
        public BitArray RegDest = new BitArray(5);
        public bool RegWrite;
        public bool MemToReg;
    }
}