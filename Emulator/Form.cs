using System;
using MIPS;

namespace Emulator
{
    public partial class Form : System.Windows.Forms.Form
    {
        private Mips _cpu;

        public Form()
        {
            InitializeComponent();
        }

        private void Init_button_Click(object sender, EventArgs e)
        {
            _cpu = new Mips();
            for (var i = 0; i < _cpu.RegisterFile.Registers.Length; i++)
            {
                mipsRegisters_datagridview.Rows.Add(i.ToString(), _cpu.RegisterFile.Registers[i].ToString());
            }
            pc_textbox.Text = _cpu.Pc.ToString();
            userCode_textbox.Text = $@"{_cpu.Pc}: ";
        }

        private void RunClockCycle_button_Click(object sender, EventArgs e)
        {
            if (_cpu.Clock == 0)
            {
                PopulateInstructionMemory(userCode_textbox.Text);
            }
        }

        private void PopulateInstructionMemory(string instructions)
        {
            var instSplit = instructions.Replace(" ", "").Replace("\r", "").Split();
            var entry = new string[] { };
            foreach (var inst in instSplit)
            {
                entry = inst.Split(':');
                var instructionCharArray = entry[1].ToCharArray();
                Array.Reverse(instructionCharArray);
                _cpu.InstructionMemory.Add(uint.Parse(entry[0]), new string(instructionCharArray));
            }

            var lastAddress = uint.Parse(entry[0]);
            for (var i = 0; i < 4; i++)
            {
                lastAddress += 4;
                _cpu.InstructionMemory.Add(lastAddress, new string('0', 32));
            }
        }
    }
}
