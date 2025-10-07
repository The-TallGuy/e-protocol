using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Dapper;

namespace Registru_Winui
{
    public partial class AddForm : Form
    {
        private Form1 parent;
        private string ConnStr;
        private List<Product> Produse = new List<Product>();
        private List<String> Beneficiari = new List<String>();
        Dictionary<string, float> Preturi = new Dictionary<string, float>();
        Dictionary<string, float> TVA = new Dictionary<string, float>();

        public AddForm()
        {
            InitializeComponent();
        }
        public AddForm(List<Product> _produse, Form1 parentForm, List<String> _beneficiari, Dictionary<string, float> _preturi, string _connStr)
        {
            InitializeComponent();
            // this.comboBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.comboBox1_MouseWheel);
            parent = parentForm;
            Produse.Clear();
            Produse = _produse;
            Preturi = _preturi;
            ConnStr = _connStr;
            Beneficiari = _beneficiari;
        }

        // public SQLiteConnection conn = new SQLiteConnection($"Data Source = {Path.GetFullPath("registruTest.db")}; FailIfMissing = True");   // USELESS, only refferenced when created. Too afraid to delete it tho

        /*
        private void comboBox1_MouseWheel(object sender, MouseEventArgs e)  // this SHOULD stop the mouse wheel from changing the selected option from the combobox
                                                                            // it does not
        {
            HandledMouseEventArgs hmea = e as HandledMouseEventArgs;
            if (!(sender as ComboBox).DroppedDown)
            {
                if (hmea != null) { hmea.Handled = true; }
            }
        }
        */

        private void AddForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Beneficiari;
            comboBox1.SelectedIndex = -1;
            comboBox2.DataSource = Produse;
            comboBox2.DisplayMember = "nume";
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = 1;
            numericUpDown1.Value = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && numericUpDown1.Value > 0)
            {
                using (SQLiteConnection localconn = new SQLiteConnection(ConnStr))
                {
                    localconn.Open();
                    SQLiteCommand command = localconn.CreateCommand();
                    command.CommandText = @"
                    INSERT INTO Protocol (beneficiar, data, produs, cantitate, status, pret)
                    VALUES ($beneficiar, $data, $produs, $cantitate, $status, $pret);
                    ";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("$beneficiar", comboBox1.SelectedValue.ToString()); // Puteam pune si .Text, era acelasi lucru, ca avem un DataSource
                    command.Parameters.AddWithValue("$data", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("$produs", comboBox2.Text.ToString());  // Puteam pune si .SelectedValue, era acelasi lucru, ca avem un DataSource
                    command.Parameters.AddWithValue("$cantitate", numericUpDown1.Value);
                    command.Parameters.AddWithValue("$status", comboBox3.Text.ToString());  // DOAR .Text merge, pentru ca nu avem un DataSource, am dat elementele ca string in designer
                    command.Parameters.AddWithValue("$pret", (decimal)Preturi[comboBox2.Text.ToString()] * numericUpDown1.Value);
                    // MessageBox.Show(((decimal)Preturi[comboBox2.Text.ToString()] * numericUpDown1.Value).ToString());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Înregistrat cu succes!");
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = 1;
                    numericUpDown1.Value = 1;
                    parent.load_Protocol();
                    // this.Close();
                }
            }
            else
            { MessageBox.Show("Ceva nu e corect."); }
        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.load_Protocol();
        }
    }
}
