namespace sw
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.startBtn = new MetroFramework.Controls.MetroButton();
            this.processNameLabel = new MetroFramework.Controls.MetroLabel();
            this.solverComboBox = new MetroFramework.Controls.MetroComboBox();
            this.freqComboBox = new MetroFramework.Controls.MetroComboBox();
            this.resGrid = new MetroFramework.Controls.MetroGrid();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyProcess = new MetroFramework.Controls.MetroProgressBar();
            this.solverLabel = new MetroFramework.Controls.MetroLabel();
            this.freqLabel = new MetroFramework.Controls.MetroLabel();
            this.analysisLabel = new MetroFramework.Controls.MetroLabel();
            this.nameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.nameLabel = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.resGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.startBtn.Location = new System.Drawing.Point(23, 233);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(496, 48);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start analysis";
            this.startBtn.UseCustomBackColor = true;
            this.startBtn.UseSelectable = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // processNameLabel
            // 
            this.processNameLabel.AutoSize = true;
            this.processNameLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.processNameLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.processNameLabel.Location = new System.Drawing.Point(105, 205);
            this.processNameLabel.Name = "processNameLabel";
            this.processNameLabel.Size = new System.Drawing.Size(0, 0);
            this.processNameLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.processNameLabel.TabIndex = 1;
            this.processNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.processNameLabel.UseStyleColors = true;
            this.processNameLabel.Visible = false;
            // 
            // solverComboBox
            // 
            this.solverComboBox.FormattingEnabled = true;
            this.solverComboBox.ItemHeight = 23;
            this.solverComboBox.Items.AddRange(new object[] {
            "Automatic",
            "FFEPlus",
            "Direct sparse solver",
            "Intel Direct Sparse"});
            this.solverComboBox.Location = new System.Drawing.Point(365, 69);
            this.solverComboBox.Name = "solverComboBox";
            this.solverComboBox.Size = new System.Drawing.Size(154, 29);
            this.solverComboBox.TabIndex = 2;
            this.solverComboBox.UseSelectable = true;
            this.solverComboBox.SelectedIndexChanged += new System.EventHandler(this.solverComboBox_SelectedIndexChanged);
            // 
            // freqComboBox
            // 
            this.freqComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.freqComboBox.DisplayFocus = true;
            this.freqComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.freqComboBox.FormattingEnabled = true;
            this.freqComboBox.ItemHeight = 23;
            this.freqComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.freqComboBox.Location = new System.Drawing.Point(365, 110);
            this.freqComboBox.Name = "freqComboBox";
            this.freqComboBox.Size = new System.Drawing.Size(154, 29);
            this.freqComboBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.freqComboBox.TabIndex = 4;
            this.freqComboBox.UseSelectable = true;
            this.freqComboBox.SelectedIndexChanged += new System.EventHandler(this.freqComboBox_SelectedIndexChanged);
            // 
            // resGrid
            // 
            this.resGrid.AllowUserToAddRows = false;
            this.resGrid.AllowUserToDeleteRows = false;
            this.resGrid.AllowUserToResizeColumns = false;
            this.resGrid.AllowUserToResizeRows = false;
            this.resGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.resGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.resGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.resGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.resGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.Max});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.resGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.resGrid.EnableHeadersVisualStyles = false;
            this.resGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.resGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.resGrid.Location = new System.Drawing.Point(23, 330);
            this.resGrid.Name = "resGrid";
            this.resGrid.ReadOnly = true;
            this.resGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.resGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.resGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resGrid.Size = new System.Drawing.Size(496, 215);
            this.resGrid.TabIndex = 5;
            // 
            // NO
            // 
            this.NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NO.FillWeight = 50F;
            this.NO.HeaderText = "№ аналізу";
            this.NO.Name = "NO";
            this.NO.ReadOnly = true;
            this.NO.Width = 78;
            // 
            // Max
            // 
            this.Max.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Max.FillWeight = 50F;
            this.Max.HeaderText = "Максимальна амплітуда (мм)";
            this.Max.Name = "Max";
            this.Max.ReadOnly = true;
            // 
            // studyProcess
            // 
            this.studyProcess.Location = new System.Drawing.Point(23, 255);
            this.studyProcess.Name = "studyProcess";
            this.studyProcess.Size = new System.Drawing.Size(496, 48);
            this.studyProcess.Style = MetroFramework.MetroColorStyle.Blue;
            this.studyProcess.TabIndex = 6;
            // 
            // solverLabel
            // 
            this.solverLabel.AutoSize = true;
            this.solverLabel.Location = new System.Drawing.Point(26, 74);
            this.solverLabel.Name = "solverLabel";
            this.solverLabel.Size = new System.Drawing.Size(179, 19);
            this.solverLabel.TabIndex = 7;
            this.solverLabel.Text = "Finite element method solver";
            // 
            // freqLabel
            // 
            this.freqLabel.AutoSize = true;
            this.freqLabel.Location = new System.Drawing.Point(26, 115);
            this.freqLabel.Name = "freqLabel";
            this.freqLabel.Size = new System.Drawing.Size(105, 19);
            this.freqLabel.TabIndex = 8;
            this.freqLabel.Text = "Frequency count";
            // 
            // analysisLabel
            // 
            this.analysisLabel.AutoSize = true;
            this.analysisLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.analysisLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.analysisLabel.Location = new System.Drawing.Point(19, 205);
            this.analysisLabel.Name = "analysisLabel";
            this.analysisLabel.Size = new System.Drawing.Size(80, 25);
            this.analysisLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.analysisLabel.TabIndex = 9;
            this.analysisLabel.Text = "Analysis:";
            this.analysisLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.analysisLabel.Visible = false;
            // 
            // nameTextBox
            // 
            // 
            // 
            // 
            this.nameTextBox.CustomButton.Image = null;
            this.nameTextBox.CustomButton.Location = new System.Drawing.Point(126, 1);
            this.nameTextBox.CustomButton.Name = "";
            this.nameTextBox.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.nameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nameTextBox.CustomButton.TabIndex = 1;
            this.nameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nameTextBox.CustomButton.UseSelectable = true;
            this.nameTextBox.CustomButton.Visible = false;
            this.nameTextBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.nameTextBox.Lines = new string[] {
        "Freq_Cantilever"};
            this.nameTextBox.Location = new System.Drawing.Point(365, 151);
            this.nameTextBox.MaxLength = 32767;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.PasswordChar = '\0';
            this.nameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nameTextBox.SelectedText = "";
            this.nameTextBox.SelectionLength = 0;
            this.nameTextBox.SelectionStart = 0;
            this.nameTextBox.ShortcutsEnabled = true;
            this.nameTextBox.Size = new System.Drawing.Size(154, 29);
            this.nameTextBox.TabIndex = 10;
            this.nameTextBox.Text = "Freq_Cantilever";
            this.nameTextBox.UseSelectable = true;
            this.nameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(26, 156);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(91, 19);
            this.nameLabel.TabIndex = 11;
            this.nameLabel.Text = "Analysis name";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 322);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.analysisLabel);
            this.Controls.Add(this.freqLabel);
            this.Controls.Add(this.solverLabel);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.studyProcess);
            this.Controls.Add(this.resGrid);
            this.Controls.Add(this.freqComboBox);
            this.Controls.Add(this.solverComboBox);
            this.Controls.Add(this.processNameLabel);
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "Frequency analysis of a cantilever beam";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton startBtn;
        private MetroFramework.Controls.MetroLabel processNameLabel;
        private MetroFramework.Controls.MetroComboBox solverComboBox;
        private MetroFramework.Controls.MetroComboBox freqComboBox;
        private MetroFramework.Controls.MetroGrid resGrid;
        private MetroFramework.Controls.MetroProgressBar studyProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max;
        private MetroFramework.Controls.MetroLabel solverLabel;
        private MetroFramework.Controls.MetroLabel freqLabel;
        private MetroFramework.Controls.MetroLabel analysisLabel;
        private MetroFramework.Controls.MetroTextBox nameTextBox;
        private MetroFramework.Controls.MetroLabel nameLabel;
    }
}

