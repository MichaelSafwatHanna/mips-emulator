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
        public bool We;
        public bool M;
        public bool Ex;
    }

    public class ExMem : PipelineRegister
    {
        public uint PcJump;
        public bool ZeroFlag;
        public int Result;
        public int ReadData2;
        public BitArray RegDest;
        public bool We;
        public bool M;
    }

    public class MemWb : PipelineRegister
    {
        public int ReadData;
        public int Result;
        public BitArray RegDest;
        public bool We;
    }
}
