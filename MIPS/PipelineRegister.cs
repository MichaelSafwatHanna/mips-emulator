using System;
using MIPS.util;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MIPS
{
    public class PipelineRegister
    {
    }

    public class IfId : PipelineRegister
    {
        public uint Pc;
        public string Instruction;

        public Dictionary<string,string> Map()
        {
            var instructionCharArray = Instruction == null ? new char[] { } : Instruction.ToCharArray();
            Array.Reverse(instructionCharArray);
            return new Dictionary<string, string>
            {
                {"Pc", Pc.ToString()},
                {"Instruction", new string(instructionCharArray) }
            };
        }
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

        public Dictionary<string, string> Map()
        {
            return new Dictionary<string, string>
            {
                {"Pc", Pc.ToString()},
                {"ReadData1", ReadData1.ToString()},
                {"ReadData2", ReadData2.ToString()},
                {"Rt", BinaryConverter.BitsToInt(Rt).ToString()},
                {"Rd", BinaryConverter.BitsToInt(Rd).ToString()},
                {"Offset", BinaryConverter.BitsToInt(Offset).ToString()},
                {"RegWrite", RegWrite.ToString()},
                {"MemToReg", MemToReg.ToString()},
                {"Branch", Branch.ToString()},
                {"MemRead", MemRead.ToString()},
                {"MemWrite", MemWrite.ToString()},
                {"RegDest", RegDest.ToString()},
                {"AluOp", BinaryConverter.BitsToInt(AluOp).ToString()},
                {"AluSrc", AluSrc.ToString()}
            };
        }
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

        public Dictionary<string, string> Map()
        {
            return new Dictionary<string, string>
            {
                {"PcJump", PcJump.ToString()},
                {"ZeroFlag", ZeroFlag.ToString()},
                {"Result", Result.ToString()},
                {"ReadData2", ReadData2.ToString()},
                {"RegDest", BinaryConverter.BitsToInt(RegDest).ToString()},
                {"RegWrite", RegWrite.ToString()},
                {"MemToReg", MemToReg.ToString()},
                {"Branch", Branch.ToString()},
                {"MemRead", MemRead.ToString()},
                {"MemWrite", MemWrite.ToString()}
            };
        }
    }

    public class MemWb : PipelineRegister
    {
        public int ReadData;
        public int Result;
        public BitArray RegDest = new BitArray(5);
        public bool RegWrite;
        public bool MemToReg;

        public Dictionary<string, string> Map()
        {
            return new Dictionary<string, string>
            {
                {"ReadData", ReadData.ToString()},
                {"Result", Result.ToString()},
                {"RegDest", BinaryConverter.BitsToInt(RegDest).ToString()},
                {"RegWrite", RegWrite.ToString()},
                {"MemToReg", MemToReg.ToString()}
            };
        }
    }
}