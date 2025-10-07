namespace Registru_Winui
{
    partial class ReportForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            label4 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            Criteriu = new DataGridViewTextBoxColumn();
            Sumă = new DataGridViewTextBoxColumn();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label4.Location = new Point(12, 153);
            label4.Name = "label4";
            label4.Size = new Size(143, 17);
            label4.TabIndex = 24;
            label4.Text = "Dată încheiere raport:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(139, 17);
            label2.TabIndex = 22;
            label2.Text = "Dată începere raport:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(152, 23);
            comboBox1.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(74, 17);
            label1.TabIndex = 20;
            label1.Text = "Beneficiar:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.Location = new Point(12, 99);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowCheckBox = true;
            dateTimePicker1.Size = new Size(227, 23);
            dateTimePicker1.TabIndex = 26;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(12, 173);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.ShowCheckBox = true;
            dateTimePicker2.Size = new Size(227, 23);
            dateTimePicker2.TabIndex = 27;
            // 
            // button2
            // 
            button2.BackColor = Color.LightCoral;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button2.Location = new Point(217, 381);
            button2.Name = "button2";
            button2.Size = new Size(199, 35);
            button2.TabIndex = 29;
            button2.Text = "Anulează";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(197, 180, 227);
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button1.Location = new Point(12, 381);
            button1.Name = "button1";
            button1.Size = new Size(199, 35);
            button1.TabIndex = 28;
            button1.Text = "Generează Raport";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Criteriu, Sumă });
            dataGridView1.Location = new Point(12, 227);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.Size = new Size(404, 127);
            dataGridView1.TabIndex = 30;
            // 
            // Criteriu
            // 
            Criteriu.HeaderText = "CRITERIU";
            Criteriu.Name = "Criteriu";
            Criteriu.ReadOnly = true;
            Criteriu.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // Sumă
            // 
            Sumă.HeaderText = "SUMĂ";
            Sumă.Name = "Sumă";
            Sumă.ReadOnly = true;
            Sumă.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(192, 255, 192);
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button3.Location = new Point(12, 422);
            button3.Name = "button3";
            button3.Size = new Size(404, 35);
            button3.TabIndex = 31;
            button3.Text = "Export\r\n";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(428, 473);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReportForm";
            Load += ReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private Label label2;
        private ComboBox comboBox1;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Criteriu;
        private DataGridViewTextBoxColumn Sumă;
        private Button button3;
    }
}