using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registru_Winui
{
    public partial class EditForm : Form
    {
        private Form1 parent;
        private int EditedId;
        private string ConnStr;
        private List<Product> Produse;
        private Protocol_entry toEdit;
        private Dictionary<string, float> Preturi = new Dictionary<string, float>();

        public EditForm()
        {
            InitializeComponent();
        }

        public EditForm(Form1 f1, int Id, List<Product> produse, Dictionary<string, float> _preturi, string _connStr)
        {
            InitializeComponent();
            parent = f1;
            EditedId = Id;
            Produse = produse;
            Preturi = _preturi;
            ConnStr = _connStr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.load_Protocol();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(ConnStr))
            {
                List<String> beneficiari = conn.Query<String>("SELECT Nume FROM Beneficiari").ToList();
                comboBox1.DataSource = beneficiari;
                comboBox2.DataSource = Produse;
                comboBox2.DisplayMember = "nume";
                // Why won't comboBox2 accept <string> lists?

                toEdit = conn.QueryFirst<Protocol_entry>("SELECT * FROM PROTOCOL WHERE ID = $Id", new { Id = EditedId });
                comboBox1.Text = toEdit.Beneficiar;
                comboBox2.Text = toEdit.Produs;
                numericUpDown1.Value = toEdit.Cantitate;
                comboBox3.Text = toEdit.Status;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && numericUpDown1.Value > 0)
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnStr))
                {
                    SQLiteCommand comm = new SQLiteCommand();
                    conn.Open();
                    comm.Connection = conn;
                    comm.CommandText = @"
                        UPDATE PROTOCOL
                        SET Beneficiar = $ben, Produs = $prod, Cantitate = $cant, Status = $stat, Pret = $pret
                        WHERE ID = $Id
                    ";
                    comm.Parameters.AddWithValue("$ben", comboBox1.Text.ToString());
                    comm.Parameters.AddWithValue("$prod", comboBox2.Text.ToString());
                    comm.Parameters.AddWithValue("$cant", numericUpDown1.Value);
                    comm.Parameters.AddWithValue("$stat", comboBox3.Text.ToString());
                    comm.Parameters.AddWithValue("$pret", (decimal)Preturi[comboBox2.Text.ToString()] * numericUpDown1.Value);
                    comm.Parameters.AddWithValue("$Id", EditedId);
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Înregistrarea a fost editată cu succes!");
                    this.Close();
                }
            }
            else { MessageBox.Show("Ceva nu a mers!"); }
        }
    }
}
