using Dapper;
using NPOI.HPSF;
using NPOI.SS.UserModel;
using NPOI.SS.UserModel.Charts;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registru_Winui
{
    public partial class ReportForm : Form
    {
        private DateTime launchEProtocol = new DateTime(2025, 7, 10);
        private string ConnStr;
        private List<Product> Produse = new List<Product>();
        private List<String> Beneficiari = new List<String>();
        private List<Protocol_entry> De_raportat = new List<Protocol_entry>();
        private Dictionary<string, float> TVA = new Dictionary<string, float>();

        public ReportForm()
        {
            InitializeComponent();
        }
        public ReportForm(List<String> _beneficiari, List<Product> _produse, Dictionary<string, float> _tva, string _connStr)
        {
            InitializeComponent();
            Beneficiari = _beneficiari;
            Produse = _produse;
            TVA = _tva;
            ConnStr = _connStr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            // MessageBox.Show(dateTimePicker1.Value.ToString("d"));
            // MessageBox.Show((dateTimePicker2.Value.Date == DateTime.Today).ToString());
            dateTimePicker2.Value = DateTime.Today;
            dateTimePicker1.Value = launchEProtocol;
            comboBox1.DataSource = Beneficiari;
            comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime begin, end;
            string _begin, _end;

            if (dateTimePicker1.Checked == false) begin = launchEProtocol;
            else if (dateTimePicker1.Value < launchEProtocol || dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            { begin = launchEProtocol; dateTimePicker1.Value = begin; }
            else begin = dateTimePicker1.Value;

            if (dateTimePicker2.Checked == false) end = DateTime.Today;
            else if (dateTimePicker2.Value.Date > DateTime.Today || dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            { end = DateTime.Today; dateTimePicker2.Value = end; }
            else end = dateTimePicker2.Value;

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date) begin = launchEProtocol;
            if (dateTimePicker1.Checked == true) dateTimePicker1.Value = begin;

            if (comboBox1.Text != "")
            {
                _begin = begin.Date.ToString("yyyy-MM-dd");
                _end = end.Date.ToString("yyyy-MM-dd");
                float Total, tAchitat, tNeachitat, tBonus;

                /*
                using (SQLiteConnection conn = new SQLiteConnection(ConnStr))
                {
                    // La final, vezi sa ai numai ce coloane vei folosi aici, nu toate (desi...poate ne trebuie type now pt asta. Hmmm....)
                    string commStr = @"
                        SELECT * FROM PROTOCOL
                        WHERE Beneficiar = @ben AND (DATA >= @beg AND DATA <= @end)
                    ";
                    De_raportat = conn.Query<Protocol_entry>(commStr, new { ben = comboBox1.Text, beg = _begin, end = _end }).ToList();
                }
                De_raportat = De_raportat.OrderByDescending(i => i.Data).ToList();
                dataGridView1.DataSource = De_raportat;
                */

                using (SQLiteConnection conn = new SQLiteConnection(ConnStr))
                {
                    string commStr = @"
                        SELECT SUM(Pret) FROM PROTOCOL
                        WHERE Beneficiar = @ben AND (DATA >= @beg AND DATA <= @end)
                    ";
                    Total = conn.ExecuteScalar<float>(commStr, new { ben = comboBox1.Text, beg = _begin, end = _end });
                    commStr = @"
                        SELECT SUM(Pret) FROM PROTOCOL
                        WHERE Beneficiar = @ben AND (DATA >= @beg AND DATA <= @end) AND Status = @stat
                    ";
                    tAchitat = conn.ExecuteScalar<float>(commStr, new { ben = comboBox1.Text, beg = _begin, end = _end, stat = "Achitat" });
                    tNeachitat = conn.ExecuteScalar<float>(commStr, new { ben = comboBox1.Text, beg = _begin, end = _end, stat = "Neachitat" });
                    tBonus = conn.ExecuteScalar<float>(commStr, new { ben = comboBox1.Text, beg = _begin, end = _end, stat = "Bonus" });
                }
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Add("Total", Total);
                dataGridView1.Rows.Add("Achitat", tAchitat);
                dataGridView1.Rows.Add("Neachitat", tNeachitat);
                dataGridView1.Rows.Add("Bonus", tBonus);
                
            }
            else MessageBox.Show("Nu ai ales un beneficiar!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime begin, end;
            string _begin, _end;
            Dictionary<string, float> arr = new Dictionary<string, float>();

            if (dateTimePicker1.Checked == false) begin = launchEProtocol;
            else if (dateTimePicker1.Value < launchEProtocol || dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            { begin = launchEProtocol; dateTimePicker1.Value = begin; }
            else begin = dateTimePicker1.Value;

            if (dateTimePicker2.Checked == false) end = DateTime.Today;
            else if (dateTimePicker2.Value.Date > DateTime.Today || dateTimePicker2.Value.Date < dateTimePicker1.Value.Date)
            { end = DateTime.Today; dateTimePicker2.Value = end; }
            else end = dateTimePicker2.Value;

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date) begin = launchEProtocol;
            if (dateTimePicker1.Checked == true) dateTimePicker1.Value = begin;

            _begin = begin.Date.ToString("yyyy-MM-dd");
            _end = end.Date.ToString("yyyy-MM-dd");
            float total, c1, c2, c3;
            using (SQLiteConnection conn = new SQLiteConnection(ConnStr))
            {
                string commStr = @"
                    SELECT SUM(e.Pret) FROM PROTOCOL e
                    INNER JOIN PRODUSE p ON e.Produs = p.Nume
                    WHERE (e.DATA >= @beg AND e.DATA <= @end) AND p.TVA = @tva;
                ";
                c1 = conn.ExecuteScalar<float>(commStr, new { beg =  _begin, end = _end, tva = 0 });
                c2 = conn.ExecuteScalar<float>(commStr, new { beg = _begin, end = _end, tva = 9 });
                c3 = conn.ExecuteScalar<float>(commStr, new { beg = _begin, end = _end, tva = 19 });
                commStr = @"
                    SELECT SUM(e.Pret) FROM PROTOCOL e
                    INNER JOIN PRODUSE p ON e.Produs = p.Nume
                    WHERE (e.DATA >= @beg AND e.DATA <= @end);
                ";
                total = conn.ExecuteScalar<float>(commStr, new { beg = _begin, end = _end });
                arr.Add("Cota TVA de 0%", c1); arr.Add("Cota TVA de 9%", c2); arr.Add("Cota TVA de 19%", c3); arr.Add("Total", total);
            }

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Rapoarte-{DateTime.Today.ToString("dd-MM-yyyy")}.xlsx");

            // EXCEL Stuff

            XSSFWorkbook workbook;
            ISheet sheet;

            // Check if we already made a report file today. If so, open it. If not, make one.
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    workbook = new XSSFWorkbook(fs);
                }
                sheet = workbook.GetSheet("rapoarte");
                if (sheet == null)
                {
                    sheet = workbook.CreateSheet("rapoarte");
                }
            }
            else
            {
                workbook = new XSSFWorkbook();
                sheet = workbook.CreateSheet("rapoarte");
            }

            // MessageBox.Show(sheet.LastRowNum.ToString());
            int currentRowIndex = sheet.LastRowNum + 2; // In code, row indexing starts at 0, not 1, like excel would have you believe

            IFont boldFont = workbook.CreateFont();
            boldFont.IsBold = true;

            // Create a style for the header cells
            ICellStyle headerStyle = workbook.CreateCellStyle();
            headerStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            headerStyle.WrapText = false;
            headerStyle.SetFont(boldFont);

            // Date Interval for Report 1
            IRow dateRow1 = sheet.CreateRow(currentRowIndex);
            ICell dateCell1 = dateRow1.CreateCell(0);
            dateCell1.SetCellValue($"Report Period: {begin.ToShortDateString()} - {end.ToShortDateString()}");
            dateCell1.CellStyle = headerStyle;

            // Merge cells for the title (from Column 0, Row currentRowIndex to Column 1, Row currentRowIndex)
            sheet.AddMergedRegion(new CellRangeAddress(currentRowIndex, currentRowIndex, 0, 1));
            currentRowIndex++;

            // Create the 2 category cells on the second row
            IRow categoryRow = sheet.CreateRow(currentRowIndex);
            categoryRow.CreateCell(0).SetCellValue("Categorie");
            categoryRow.CreateCell(1).SetCellValue("Cost total");
            categoryRow.Cells[0].CellStyle = headerStyle;
            categoryRow.Cells[1].CellStyle = headerStyle;
            currentRowIndex++;

            // Populate the next 4 rows with the type of total we calculated and its value
            foreach (var item in arr)
            {
                IRow dataRow = sheet.CreateRow(currentRowIndex);
                dataRow.CreateCell(0).SetCellValue(item.Key);
                dataRow.CreateCell(1).SetCellValue(item.Value);
                currentRowIndex++;
            }

            // Fit the columns
            sheet.SetColumnWidth(0, 5000);
            sheet.SetColumnWidth(1, 5000);

            // Save the Excel file
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fileStream);
                MessageBox.Show("Raport realizat cu succes!");
                this.Close();
            }
        }
    }
}
