using MIPS;
using System;
using System.Windows.Forms;

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
            pc_textbox.Text = "1000";
            _cpu = new Mips(uint.Parse(pc_textbox.Text));
            RefreshRegistersGridView();
            userCode_textbox.Text = $@"{pc_textbox.Text}: ";
        }

        private void RunClockCycle_button_Click(object sender, EventArgs e)
        {
            if (_cpu == null)
            {
                MessageBox.Show("Initialize Emulator First!");
                return;
            }

            if (userCode_textbox.Text == "")
            {
                MessageBox.Show("Can't Run Emulator while user code is empty!");
                return;
            }

            if (_cpu.Clock == 0)
            {
                PopulateInstructionMemory(userCode_textbox.Text);
            }

            _cpu.RunClockCycle();
            RefreshRegistersGridView();
            RefreshDataMemoryGridView();
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

        private void RefreshRegistersGridView()
        {
            mipsRegisters_datagridview.Rows.Clear();
            for (var i = 0; i < _cpu.RegisterFile.Registers.Length; i++)
            {
                mipsRegisters_datagridview.Rows.Add($"${i}", _cpu.RegisterFile.Registers[i].ToString());
            }
        }

        private void RefreshDataMemoryGridView()
        {
            dataMemory_dataGridView.Rows.Clear();
            foreach (var pair in _cpu.DataMemory)
            {
                dataMemory_dataGridView.Rows.Add(pair.Key, pair.Value);
            }
        }
    }
}
