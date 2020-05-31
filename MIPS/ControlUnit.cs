using System.Collections;

namespace MIPS
{
    class ControlUnit
    {
        public bool RegDest { get; set; }
        public bool AluSrc;
        public bool MemToReg;
        public bool RegWrite;
        public bool MemRead;
        public bool MemWrite;
        public bool Branch;
        private bool _aluOp1;
        private bool _aluOp0;
        public BitArray AluOp;
        public bool PcSrc;

        public void Control(Instruction instruction)
        {
            var opCode = instruction.Opcode;
            var rFormat = !opCode[0] && !opCode[1] && !opCode[2] && !opCode[3] && !opCode[4] && !opCode[5];
            var lw = opCode[0] && opCode[1] && !opCode[2] && !opCode[3] && !opCode[4] && opCode[5];
            var sw = opCode[0] && opCode[1] && !opCode[2] && opCode[3] && !opCode[4] && opCode[5];
            var beq = !opCode[0] && !opCode[1] && opCode[2] && !opCode[3] && !opCode[4] && !opCode[5];

            RegDest = rFormat;
            AluSrc = lw || sw;
            MemToReg = lw;
            RegWrite = rFormat || lw;
            MemRead = lw;
            MemWrite = sw;
            Branch = beq;
            _aluOp1 = rFormat;
            _aluOp0 = beq;

            AluControl(instruction.Function);
        }

        public void AluControl(BitArray function)
        {
            AluOp = new BitArray(3);
            var or1 = function[0] || function[3];
            var and1 = function[1] && _aluOp1;
            AluOp[2] = or1 && _aluOp1;
            AluOp[1] = !function[2] || !_aluOp1;
            AluOp[0] = and1 || _aluOp0;
        }

        public void SetPcSrc(bool zeroFlag)
        {
            PcSrc = Branch && MemRead && MemWrite && zeroFlag;
        }
    }
}