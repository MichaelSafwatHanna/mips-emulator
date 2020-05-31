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
        public BitArray Rt;
        public BitArray Rd;
        public BitArray Offset;
        public bool RegWrite;
        public bool MemToReg;
        public bool Branch;
        public bool MemRead;
        public bool MemWrite;
        public bool RegDest;
        public BitArray AluOp;
        public bool AluSrc;
    }

    public class ExMem : PipelineRegister
    {
        public uint PcJump;
        public bool ZeroFlag;
        public int Result;
        public int ReadData2;
        public BitArray RegDest;
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
        public BitArray RegDest;
        public bool RegWrite;
        public bool MemToReg;
    }
}