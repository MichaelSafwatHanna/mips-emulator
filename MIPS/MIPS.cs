using MIPS.util;
using System.Collections.Generic;

namespace MIPS
{
    public class Mips
    {
        public Dictionary<uint, string> InstructionMemory { get; set; }
        public IfId IfId { get; set; }
        public IdEx IdEx { get; set; }
        public ExMem ExMem { get; set; }
        public MemWb MemWb { get; set; }
        public int Clock { get; set; }
        public int Pc = 1000;
        public RegisterFile RegisterFile;
        private Alu _alu;

        public Mips()
        {
            Clock = 0;
            RegisterFile = new RegisterFile();
            _alu = new Alu();
            InstructionMemory = new Dictionary<uint, string>();
            IfId = new IfId();
            IdEx = new IdEx();
            ExMem = new ExMem();
            MemWb = new MemWb();
        }

    }
}
