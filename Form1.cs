using Dapper;
using System.CodeDom;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Registru_Winui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        string txtPath = "dbLocation.txt";
        string dbPath = "";
        string ConnStr = "";
        SQLiteConnection conn = new SQLiteConnection();

        List<Product> Produse = new List<Product>();
        List<Protocol_entry> Protocol_Entries = new List<Protocol_entry>();
        List<String> Beneficiari = new List<String>();
        Dictionary<string, float> Preturi = new Dictionary<string, float>();
        Dictionary<string, float> TVA = new Dictionary<string, float>();

        private void Form1_Load(object sender, EventArgs e)
        {
            if(!File.Exists(txtPath)) using (File.Create(txtPath)) { }
            using (StreamReader sr = new StreamReader(txtPath)) { dbPath = sr.ReadLine(); }
            if (dbPath == "" || !File.Exists(dbPath)) 
            {
                // OpenFileDialog
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "SQL Database (*.db)|*.db";
                ofd.Multiselect = false;
                ofd.InitialDirectory = Environment.CurrentDirectory;
                DialogResult dr = new DialogResult();
                do
                {
                    dr = ofd.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        dbPath = ofd.FileName;                    
                    }
                    else
                    {
                        DialogResult exitConfirmation = MessageBox.Show("Nu ai selectat baza de date. Vrei să închizi programul?",
                            "Exit Program?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(exitConfirmation == DialogResult.Yes) Application.Exit();
                    }
                } while (dr != DialogResult.OK);

                // Save to the txt file
                using (StreamWriter sw = new StreamWriter(txtPath)) { sw.WriteLine(dbPath); }
            }
            ConnStr = $"Data Source = {dbPath};FailIfMissing = True";
            conn.ConnectionString = ConnStr;

            Produse = conn.Query<Product>("SELECT * FROM PRODUSE").ToList();
            Beneficiari = conn.Query<String>("SELECT Nume FROM Beneficiari").ToList();
            Preturi = Produse.ToDictionary(entry => entry.nume, entry => entry.pret);
            TVA = Produse.ToDictionary(entry => entry.nume, entry => entry.tva);
            load_Protocol();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm(Produse, this, Beneficiari, Preturi, ConnStr);
            addForm.ShowDialog();
            addForm.Dispose();
        }

        public void load_Protocol()
        {
            Protocol_Entries.Clear();
            Protocol_Entries = conn.Query<Protocol_entry>("SELECT * FROM PROTOCOL").ToList();
            dataGridView1.DataSource = Protocol_Entries;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("We're editing the recording where ID = " + (dataGridView1.SelectedCells[0].RowIndex + 1).ToString());
            /* 
             * Get the whole protocol table
             * Make a list of <Protocol_entry> where you store everything, ID included
             * Hide the ID from the tableGridView
             * When the user selects one or multiple rows, get the ID of the Protocol_entry object in the first selected row and use that for the modification (pass to Editform through constructor)
             * ...
            */
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
                int dbId = Protocol_Entries[selectedRow].ID;
                var EditForm = new EditForm(this, dbId, Produse, Preturi, ConnStr);
                EditForm.ShowDialog();
                EditForm.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection tempConn = new SQLiteConnection(ConnStr))
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    HashSet<int> uniqueNumbers = new HashSet<int>();
                    foreach (DataGridViewTextBoxCell cell in dataGridView1.SelectedCells)
                    {
                        uniqueNumbers.Add(cell.RowIndex);
                    }

                    // int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
                    int i = 0;
                    foreach (int selectedRow in uniqueNumbers)
                    {
                        int deleteId = Protocol_Entries[selectedRow].ID;
                        tempConn.Execute("DELETE FROM Protocol WHERE ID = @Id", new { Id = deleteId });
                        i++;
                    }
                    load_Protocol();
                    if (i == 1) MessageBox.Show("Înregistrare ștearsă cu succes!");
                    else if (i > 1) MessageBox.Show("Înregistrări șterse cu succes!");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection tempConn = new SQLiteConnection(ConnStr))
            {
                if (dataGridView1.SelectedCells.Count > 0)
                {
                    // int rows = dataGridView1.SelectedCells.Count;
                    HashSet<int> uniqueNumbers = new HashSet<int>();
                    foreach (DataGridViewTextBoxCell cell in dataGridView1.SelectedCells)
                    {
                        uniqueNumbers.Add(cell.RowIndex);
                    }

                    // int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
                    int i = 0, j = 0; ;
                    foreach (int selectedRow in uniqueNumbers)
                    {
                        int payId = Protocol_Entries[selectedRow].ID;
                        if (Protocol_Entries[selectedRow].Status == "Neachitat")
                        {
                            tempConn.Execute("UPDATE Protocol SET Status = 'Achitat' WHERE ID = @Id", new { Id = payId });
                            i++;
                        }
                        else j++;
                    }
                    load_Protocol();
                    if (i == 1) { MessageBox.Show("Achitarea a fost înregistrată cu succes!"); }
                    else if (i>1) { MessageBox.Show("Achitările au fost înregistrate cu succes!");  }
                    else if (j == 1) { MessageBox.Show("Nu trebuie să fie achitată."); }
                    else if (j > 1) { MessageBox.Show("Nu trebuie să fie achitate."); }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var ReportForm = new ReportForm(Beneficiari, Produse, TVA, ConnStr);
            ReportForm.ShowDialog();
            ReportForm.Dispose();
        }
    }
}
