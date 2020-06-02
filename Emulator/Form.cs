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
            RefreshDataMemoryGridView();
            RefreshPipelineRegisterGridView();
            userCode_textbox.Text = $@"{pc_textbox.Text}: ";
            RunClockCycle_button.Enabled = true;
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

            if (_cpu.Clock == _cpu.InstructionsCount + 4)
            {
                MessageBox.Show("End of user code, Initialize emulator to continue!");
                RunClockCycle_button.Enabled = false;
                return;
            }

            if (_cpu.Clock == 0)
            {
                _cpu.LoadCode(userCode_textbox.Text);
            }

            _cpu.RunClockCycle();
            RefreshRegistersGridView();
            RefreshDataMemoryGridView();
            RefreshPipelineRegisterGridView();
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

        private void RefreshPipelineRegisterGridView()
        {
            pipelineRegisters_dataGirdView.Rows.Clear();
            foreach (var pair in _cpu.IfId.Map())
            {
                pipelineRegisters_dataGirdView.Rows.Add($"IF/ID -> {pair.Key}", pair.Value);
            }

            foreach (var pair in _cpu.IdEx.Map())
            {
                pipelineRegisters_dataGirdView.Rows.Add($"ID/EX -> {pair.Key}", pair.Value);
            }

            foreach (var pair in _cpu.ExMem.Map())
            {
                pipelineRegisters_dataGirdView.Rows.Add($"EX/MEM -> {pair.Key}", pair.Value);
            }

            foreach (var pair in _cpu.MemWb.Map())
            {
                pipelineRegisters_dataGirdView.Rows.Add($"MEM/WB -> {pair.Key}", pair.Value);
            }
        }
    }
}
