namespace Registru_Winui
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            numericUpDown1 = new NumericUpDown();
            comboBox3 = new ComboBox();
            label4 = new Label();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            comboBox2 = new ComboBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(12, 173);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 20;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Achitat", "Neachitat", "Bonus" });
            comboBox3.Location = new Point(12, 252);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(152, 23);
            comboBox3.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label4.Location = new Point(12, 232);
            label4.Name = "label4";
            label4.Size = new Size(50, 17);
            label4.TabIndex = 18;
            label4.Text = "Status:";
            // 
            // button2
            // 
            button2.BackColor = Color.LightCoral;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button2.Location = new Point(170, 317);
            button2.Name = "button2";
            button2.Size = new Size(141, 35);
            button2.TabIndex = 17;
            button2.Text = "Anulează";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightSkyBlue;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button1.Location = new Point(12, 317);
            button1.Name = "button1";
            button1.Size = new Size(152, 35);
            button1.TabIndex = 16;
            button1.Text = "Editează";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label3.Location = new Point(12, 153);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 15;
            label3.Text = "Cantitate:";
            // 
            // comboBox2
            // 
            comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 99);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(247, 23);
            comboBox2.Sorted = true;
            comboBox2.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(55, 17);
            label2.TabIndex = 13;
            label2.Text = "Produs:";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 29);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(152, 23);
            comboBox1.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(74, 17);
            label1.TabIndex = 11;
            label1.Text = "Beneficiar:";
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 364);
            Controls.Add(numericUpDown1);
            Controls.Add(comboBox3);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "EditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editează înregistrare";
            FormClosed += EditForm_FormClosed;
            Load += EditForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDown1;
        private ComboBox comboBox3;
        private Label label4;
        private Button button2;
        private Button button1;
        private Label label3;
        private ComboBox comboBox2;
        private Label label2;
        private ComboBox comboBox1;
        private Label label1;
    }
}