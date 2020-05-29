namespace Emulator
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.userCode_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mipsRegisters_datagridview = new System.Windows.Forms.DataGridView();
            this.register = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pc_textbox = new System.Windows.Forms.TextBox();
            this.PC = new System.Windows.Forms.Label();
            this.init_button = new System.Windows.Forms.Button();
            this.RunClockCycle_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mipsRegisters_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Code";
            // 
            // userCode_textbox
            // 
            this.userCode_textbox.Location = new System.Drawing.Point(16, 46);
            this.userCode_textbox.Multiline = true;
            this.userCode_textbox.Name = "userCode_textbox";
            this.userCode_textbox.Size = new System.Drawing.Size(211, 392);
            this.userCode_textbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "MIPS Registers";
            // 
            // mipsRegisters_datagridview
            // 
            this.mipsRegisters_datagridview.AllowUserToAddRows = false;
            this.mipsRegisters_datagridview.AllowUserToDeleteRows = false;
            this.mipsRegisters_datagridview.AllowUserToResizeColumns = false;
            this.mipsRegisters_datagridview.AllowUserToResizeRows = false;
            this.mipsRegisters_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.mipsRegisters_datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mipsRegisters_datagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.register,
            this.value});
            this.mipsRegisters_datagridview.Location = new System.Drawing.Point(250, 46);
            this.mipsRegisters_datagridview.Name = "mipsRegisters_datagridview";
            this.mipsRegisters_datagridview.ReadOnly = true;
            this.mipsRegisters_datagridview.RowTemplate.Height = 24;
            this.mipsRegisters_datagridview.Size = new System.Drawing.Size(258, 392);
            this.mipsRegisters_datagridview.TabIndex = 3;
            // 
            // register
            // 
            this.register.HeaderText = "Register";
            this.register.Name = "register";
            this.register.ReadOnly = true;
            this.register.Width = 90;
            // 
            // value
            // 
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            this.value.Width = 73;
            // 
            // pc_textbox
            // 
            this.pc_textbox.Location = new System.Drawing.Point(54, 472);
            this.pc_textbox.Name = "pc_textbox";
            this.pc_textbox.Size = new System.Drawing.Size(100, 22);
            this.pc_textbox.TabIndex = 4;
            // 
            // PC
            // 
            this.PC.AutoSize = true;
            this.PC.Location = new System.Drawing.Point(16, 475);
            this.PC.Name = "PC";
            this.PC.Size = new System.Drawing.Size(26, 17);
            this.PC.TabIndex = 5;
            this.PC.Text = "PC";
            // 
            // init_button
            // 
            this.init_button.Location = new System.Drawing.Point(176, 465);
            this.init_button.Name = "init_button";
            this.init_button.Size = new System.Drawing.Size(87, 36);
            this.init_button.TabIndex = 6;
            this.init_button.Text = "Initialize";
            this.init_button.UseVisualStyleBackColor = true;
            this.init_button.Click += new System.EventHandler(this.Init_button_Click);
            // 
            // RunClockCycle_button
            // 
            this.RunClockCycle_button.Location = new System.Drawing.Point(291, 465);
            this.RunClockCycle_button.Name = "RunClockCycle_button";
            this.RunClockCycle_button.Size = new System.Drawing.Size(102, 36);
            this.RunClockCycle_button.TabIndex = 7;
            this.RunClockCycle_button.Text = "Run 1 Cycle";
            this.RunClockCycle_button.UseVisualStyleBackColor = true;
            this.RunClockCycle_button.Click += new System.EventHandler(this.RunClockCycle_button_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 519);
            this.Controls.Add(this.RunClockCycle_button);
            this.Controls.Add(this.init_button);
            this.Controls.Add(this.PC);
            this.Controls.Add(this.pc_textbox);
            this.Controls.Add(this.mipsRegisters_datagridview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userCode_textbox);
            this.Controls.Add(this.label1);
            this.Name = "Form";
            this.Text = "MIPS Emulator";
            ((System.ComponentModel.ISupportInitialize)(this.mipsRegisters_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userCode_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView mipsRegisters_datagridview;
        private System.Windows.Forms.DataGridViewTextBoxColumn register;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.TextBox pc_textbox;
        private System.Windows.Forms.Label PC;
        private System.Windows.Forms.Button init_button;
        private System.Windows.Forms.Button RunClockCycle_button;
    }
}

