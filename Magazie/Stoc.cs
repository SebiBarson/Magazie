using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Magazie
{
    public partial class Stoc : Form
    {
        OleDbConnection con = new OleDbConnection(Form1.conquery);
        public Stoc()
        {
            InitializeComponent();
            incarcare();
        }
        private void incarcare()
        {
            try
            {
                con.Open();
                OleDbCommand cs = new OleDbCommand("SELECT ID, ID_material, Cantitate,data_intr FROM Stoc WHERE Arhivat=false", con);
                OleDbDataAdapter a_stoc = new OleDbDataAdapter(cs);
                DataTable t_stoc = new DataTable();
                a_stoc.Fill(t_stoc);
                OleDbCommand cp = new OleDbCommand("SELECT ID, Denumire, Pret_unitar FROM materiale WHERE Arhivat=false order by denumire ASC", con);
                DataTable t_materiale = new DataTable();
                OleDbDataAdapter a_materiale = new OleDbDataAdapter(cp);
                a_materiale.Fill(t_materiale);
                t_materiale.Columns.Add("Cantitate", typeof(string));
                t_materiale.Columns.Add("ids", typeof(int));
                t_materiale.Columns.Add("Valoare stoc", typeof(double));
                t_materiale.Columns.Add("Data intrarii", typeof(DateTime));
                foreach (DataRow s in t_stoc.Rows)
                    for (int i = t_materiale.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow m = t_materiale.Rows[i];
                        if (Convert.ToInt32(m["ID"]) == Convert.ToInt32(s["ID_material"]))
                        {
                            m["cantitate"] = s["cantitate"];
                            m["ids"] = s["id"];
                            m["Valoare stoc"] = System.Math.Round(Convert.ToDouble(m["Pret_unitar"]) * Convert.ToDouble(m["cantitate"]), 2);
                            m["Data intrarii"] = Convert.ToDateTime(s["Data_intr"]).ToLongDateString();
                            if (Convert.ToDouble(m["cantitate"]) == 0)
                                m.Delete();
                            t_materiale.AcceptChanges();
                        }
                    }
                t_materiale.Columns.Remove("ids");
                dataGridView1.DataSource = t_materiale;
                dataGridView1.AutoResizeColumn(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Adauga_pe_stoc a = new Adauga_pe_stoc();
            a.ShowDialog();
            incarcare();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Scoate_de_pe_stoc s = new Scoate_de_pe_stoc();
            s.ShowDialog();
            incarcare();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                excel.Visible = true;
                var xlNewSheet = excel.Worksheets.Add(Type.Missing);
                xlNewSheet.Name = "Foaie";
                excel.Visible = true;
                worksheet = workbook.Sheets["Foaie"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = this.Text;
                try
                {
                    int cellRowIndex = 1;
                    int cellColumnIndex = 1;

                    //Loop through each row and read value from each column. 
                    for (int i = -1; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                            if (cellRowIndex == 1)
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Columns[j].HeaderText;
                            }
                            else
                            {
                                worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                                if (cellColumnIndex == dataGridView1.Columns.Count)
                                    worksheet.Cells[cellRowIndex, cellColumnIndex] = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            }
                            cellColumnIndex++;
                        }
                        cellColumnIndex = 1;
                        cellRowIndex++;
                    }
                    workbook = null;
                    excel = null;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
