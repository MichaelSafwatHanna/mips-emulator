using System;
using MIPS.util;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MIPS
{
    public class Mips
    {
        public Dictionary<uint, string> InstructionMemory { get; set; }
        public Dictionary<uint, string> DataMemory { get; set; }
        public IfId IfId { get; set; }
        public IdEx IdEx { get; set; }
        public ExMem ExMem { get; set; }
        public MemWb MemWb { get; set; }
        public int Clock { get; set; }
        public int InstructionsCount { get; set; }
        public uint Pc = 1000;
        public RegisterFile RegisterFile;
        private Alu _alu;
        private ControlUnit _controlUnit;

        public Mips(uint pc)
        {
            Clock = 0;
            RegisterFile = new RegisterFile();
            _alu = new Alu();
            _controlUnit = new ControlUnit();
            InstructionMemory = new Dictionary<uint, string>();
            DataMemory = new Dictionary<uint, string>();
            IfId = new IfId();
            IdEx = new IdEx();
            ExMem = new ExMem();
            MemWb = new MemWb();
            Pc = pc - 4;
        }

        public void LoadCode(string code)
        {
            var rgx = new Regex("[^0-9:\\n]");
            var instSplit = rgx.Replace(code, "").Split();
            var entry = new string[] { };
            foreach (var inst in instSplit)
            {
                entry = inst.Split(':');
                var instructionCharArray = entry[1].ToCharArray();
                Array.Reverse(instructionCharArray);
                InstructionMemory.Add(uint.Parse(entry[0]), new string(instructionCharArray));
            }

            var lastAddress = uint.Parse(entry[0]);
            for (var i = 0; i < 4; i++)
            {
                lastAddress += 4;
                InstructionMemory.Add(lastAddress, new string('0', 32));
            }

            InstructionsCount = instSplit.Length;
        }

        public void Fetch()
        {
            Pc = _controlUnit.PcSrc ? ExMem.PcJump : Pc + 4;
            IfId.Instruction = InstructionMemory[Pc];
            IfId.Pc = Pc + 4;
        }

        public void Decode()
        {
            if (IfId.Instruction == null)
                return;
            var instruction = new Instruction(IfId.Instruction);
            RegisterFile.ReadReg1 = BinaryConverter.BitsToInt(instruction.Rs);
            RegisterFile.ReadReg2 = BinaryConverter.BitsToInt(instruction.Rt);

            _controlUnit.Control(instruction);

            // Execution Stage Control lines
            IdEx.RegDest = _controlUnit.RegDest;
            IdEx.AluSrc = _controlUnit.AluSrc;
            IdEx.AluOp = _controlUnit.AluOp;

            // Memory access Stage control lines
            IdEx.Branch = _controlUnit.Branch;
            IdEx.MemRead = _controlUnit.MemRead;
            IdEx.MemWrite = _controlUnit.MemWrite;

            // Write back Stage control lines
            IdEx.RegWrite = _controlUnit.RegWrite;
            IdEx.MemToReg = _controlUnit.MemToReg;

            IdEx.Pc = IfId.Pc;
            IdEx.ReadData1 = RegisterFile.ReadData1;
            IdEx.ReadData2 = RegisterFile.ReadData2;
            IdEx.Rd = instruction.I15_11;
            IdEx.Rt = instruction.I20_16;
            IdEx.Offset = instruction.I15_0; //TODO: Sign Extension
        }

        public void Execute()
        {
            _alu.Data1 = IdEx.ReadData1;
            _alu.Data2 = IdEx.AluSrc ? BinaryConverter.BitsToInt(IdEx.Offset) : IdEx.ReadData2;
            _alu.Compute(IdEx.AluOp);

            // Memory access Stage control lines
            ExMem.Branch = IdEx.Branch;
            ExMem.MemRead = IdEx.MemRead;
            ExMem.MemWrite = IdEx.MemWrite;

            // Write back Stage control lines
            ExMem.RegWrite = IdEx.RegWrite;
            ExMem.MemToReg = IdEx.MemToReg;

            ExMem.PcJump = IdEx.Pc + (uint)BinaryConverter.BitsToInt(BitwiseOperations.LogicalShl(IdEx.Offset, 2));
            ExMem.ZeroFlag = _alu.ZeroFlag;
            ExMem.Result = _alu.Result;
            ExMem.ReadData2 = IdEx.ReadData2;
            ExMem.RegDest = IdEx.RegDest ? IdEx.Rd : IdEx.Rt;
        }

        public void MemoryAccess()
        {
            _controlUnit.SetPcSrc(ExMem.ZeroFlag);

            if (ExMem.MemRead)
            {
                if (!DataMemory.ContainsKey((uint)ExMem.Result))
                {
                    DataMemory[(uint)ExMem.Result] = "99";
                }

                MemWb.ReadData = int.Parse(DataMemory[(uint)ExMem.Result]);
            }

            if (ExMem.MemWrite)
            {
                DataMemory[(uint) ExMem.Result] = ExMem.ReadData2.ToString();
            }

            // Write back Stage control lines
            MemWb.RegWrite = ExMem.RegWrite;
            MemWb.MemToReg = ExMem.MemToReg;

            MemWb.Result = ExMem.Result;
            MemWb.RegDest = ExMem.RegDest;
        }

        public void WriteBack()
        {
            RegisterFile.WriteReg = BinaryConverter.BitsToInt(MemWb.RegDest);
            RegisterFile.WrData = MemWb.MemToReg ? MemWb.ReadData : MemWb.Result;
            RegisterFile.RegWrite = MemWb.RegWrite;
            RegisterFile.WriteData();
        }

        public void RunClockCycle()
        {
            WriteBack();
            MemoryAccess();
            Execute();
            Decode();
            Fetch();
            Clock++;
        }

    }
}
