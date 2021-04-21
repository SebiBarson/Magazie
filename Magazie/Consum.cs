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
    public partial class Consum : Form
    {
        OleDbConnection con = new OleDbConnection(Form1.conquery);
        DataTable tangajati = new DataTable();
        DataTable tmateriale = new DataTable();
        DataTable dt=new DataTable();
        double pu;
        public Consum()
        {
            InitializeComponent();
            button1.Visible = false;
            if (Form1.consum == 1)
            {
                this.Text = this.Text + " per clădire";
                label1.Text = label1.Text + " clădirea:";
                comboBox1.Items.Add("Clădirea 1");
                comboBox1.Items.Add("Clădirea 2");
                dataGridView1.ReadOnly = true;
                checkBox1.Visible = false;
            }
            if (Form1.consum == 2)
            {
                this.Text = this.Text + " per persoană";
                label1.Text = label1.Text + " angajatul:";
                OleDbCommand sangajati = new OleDbCommand("SELECT * FROM Angajati WHERE Lucreaza=@l", con);
                if (checkBox1.Checked == true)
                    sangajati.Parameters.AddWithValue("@l", false);
                else
                    sangajati.Parameters.AddWithValue("@l", true);
                OleDbDataAdapter aangajati = new OleDbDataAdapter(sangajati);
                aangajati.Fill(tangajati);
                comboBox1.DataSource = tangajati;
                comboBox1.DisplayMember = "Nume";
                comboBox1.ValueMember = "ID";
                dataGridView1.ReadOnly = true;
            }
            if (Form1.consum == 3)
            {
                this.Text = this.Text + " total";
                label1.Visible = false;
                label2.Visible = false;
                comboBox1.Visible = false;
                dataGridView1.ReadOnly = true;
                checkBox1.Visible = false;
            }
            if (Form1.consum == 4)
            {
                try
                {
                    con.Open();
                    this.Text = this.Text + " per material";
                    OleDbCommand smateriale = new OleDbCommand("SELECT * FROM Materiale ORDER BY Denumire ASC",con);
                    OleDbDataAdapter amateriale = new OleDbDataAdapter(smateriale);
                    amateriale.Fill(tmateriale);
                    comboBox1.DataSource = tmateriale;
                    comboBox1.DisplayMember = "Denumire";
                    comboBox1.ValueMember = "ID";
                    label1.Text = label1.Text + " materialul:";
                    checkBox1.Visible = false;
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
        }
        private void labelrezultat(DataTable dt)
        {
            double suma = 0;
            DataTable tconsum = new DataTable();
            foreach (DataRow c in dt.Rows)
                suma = suma + (Convert.ToDouble(c["Valoare"]));
            label5.Text = "Valoare totală: " + System.Math.Round(suma,2) + " lei";
        }
        private void Consum_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Form1.consum == 1)
                {
                    if (comboBox1.Text == "")
                        MessageBox.Show("Alegeți clădirea mai întâi!");
                    if (comboBox1.Text == "Clădirea 1")
                    {
                        try
                        {
                            OleDbCommand sconsum = new OleDbCommand("SELECT * FROM Consum WHERE Cladire='" + "Cl 1" + "'AND Data<=@d1 AND Data>=@d2 AND Cantitate>0 ORDER BY Data ASC", con);
                            DateTime d1 = Convert.ToDateTime(dateTimePicker2.Value);
                            DateTime d2 = Convert.ToDateTime(dateTimePicker1.Value);
                            sconsum.Parameters.AddWithValue("@d1", d1.ToShortDateString());
                            sconsum.Parameters.AddWithValue("@d2", d2.ToShortDateString());
                            OleDbDataAdapter aconsum = new OleDbDataAdapter(sconsum);
                            DataTable tconsum = new DataTable();
                            aconsum.Fill(tconsum);
                            OleDbCommand sangajati = new OleDbCommand("SELECT * FROM Angajati", con);
                            OleDbDataAdapter aangajati = new OleDbDataAdapter(sangajati);
                            aangajati.Fill(tangajati);
                            OleDbCommand smateriale = new OleDbCommand("SELECT * FROM Materiale", con);
                            OleDbDataAdapter amateriale = new OleDbDataAdapter(smateriale);
                            amateriale.Fill(tmateriale);
                            tconsum.Columns.Add("Material", typeof(string));
                            tconsum.Columns.Add("Pret", typeof(double));
                            tconsum.Columns.Add("Valoare", typeof(double));
                            foreach (DataRow c in tconsum.Rows)
                                foreach (DataRow m in tmateriale.Rows)
                                {
                                    if (Convert.ToInt32(m["ID"]) == Convert.ToInt32(c["ID_material"]))
                                    {
                                        c["Material"] = m["Denumire"];
                                        c["Pret"] = m["Pret_unitar"];
                                        c["Valoare"] = System.Math.Round(Convert.ToDouble(m["Pret_unitar"]) * Convert.ToDouble(c["Cantitate"]), 2);
                                    }
                                }
                            tconsum.Columns.Add("Angajat", typeof(string));
                            foreach (DataRow c in tconsum.Rows)
                                foreach (DataRow a in tangajati.Rows)
                                    if (Convert.ToInt32(a["ID"]) == Convert.ToInt32(c["ID_angajat"]))
                                        c["Angajat"] = a["nume"];
                            tconsum.Columns.Remove("ID_angajat");
                            tconsum.Columns.Remove("Cladire");
                            tconsum.Columns["Angajat"].SetOrdinal(1);
                            tconsum.Columns["Material"].SetOrdinal(2);
                            tconsum.Columns["Pret"].SetOrdinal(3);
                            tconsum.Columns["Valoare"].SetOrdinal(4);
                            tconsum.Columns["Cantitate"].SetOrdinal(5);
                            tconsum.Columns["Data"].SetOrdinal(1);
                            dataGridView1.DataSource = tconsum;
                            dataGridView1.AutoResizeColumns();
                            dataGridView1.Columns["Angajat"].ReadOnly = true;
                            dataGridView1.Columns["Material"].ReadOnly = true;
                            dataGridView1.Columns["Pret"].ReadOnly = true;
                            dataGridView1.Columns["Valoare"].ReadOnly = true;
                            dataGridView1.Columns["Data"].ReadOnly = true;
                            dataGridView1.Columns["ID"].ReadOnly = true;
                            labelrezultat(tconsum);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                    }
                    if (comboBox1.Text == "Clădirea 2")
                    {
                        try
                        {
                            OleDbCommand sconsum = new OleDbCommand("SELECT * FROM Consum WHERE Cladire='" + "Cl 2" + "'AND Data<=@d1 AND Data>=@d2 AND Cantitate>0 ORDER BY Data ASC", con);
                            DateTime d1 = Convert.ToDateTime(dateTimePicker2.Value);
                            DateTime d2 = Convert.ToDateTime(dateTimePicker1.Value);
                            sconsum.Parameters.AddWithValue("@d1", d1.ToShortDateString());
                            sconsum.Parameters.AddWithValue("@d2", d2.ToShortDateString());
                            OleDbDataAdapter aconsum = new OleDbDataAdapter(sconsum);
                            DataTable tconsum = new DataTable();
                            aconsum.Fill(tconsum);
                            OleDbCommand sangajati = new OleDbCommand("SELECT * FROM Angajati", con);
                            OleDbDataAdapter aangajati = new OleDbDataAdapter(sangajati);
                            aangajati.Fill(tangajati);
                            OleDbCommand smateriale = new OleDbCommand("SELECT * FROM Materiale", con);
                            OleDbDataAdapter amateriale = new OleDbDataAdapter(smateriale);
                            amateriale.Fill(tmateriale);
                            tconsum.Columns.Add("Material", typeof(string));
                            tconsum.Columns.Add("Pret", typeof(double));
                            tconsum.Columns.Add("Valoare", typeof(double));
                            foreach (DataRow c in tconsum.Rows)
                                foreach (DataRow m in tmateriale.Rows)
                                {
                                    if (Convert.ToInt32(m["ID"]) == Convert.ToInt32(c["ID_material"]))
                                    {
                                        c["Material"] = m["Denumire"];
                                        c["Pret"] = m["Pret_unitar"];
                                        c["Valoare"] = System.Math.Round(Convert.ToDouble(m["Pret_unitar"]) * Convert.ToDouble(c["Cantitate"]), 2);
                                    }
                                }
                            tconsum.Columns.Add("Angajat", typeof(string));
                            foreach (DataRow c in tconsum.Rows)
                                foreach (DataRow a in tangajati.Rows)
                                    if (Convert.ToInt32(a["ID"]) == Convert.ToInt32(c["ID_angajat"]))
                                        c["Angajat"] = a["nume"];
                            tconsum.Columns.Remove("ID_angajat");
                            tconsum.Columns["Angajat"].SetOrdinal(1);
                            tconsum.Columns["Material"].SetOrdinal(2);
                            tconsum.Columns["Pret"].SetOrdinal(3);
                            tconsum.Columns["Valoare"].SetOrdinal(4);
                            tconsum.Columns["Cantitate"].SetOrdinal(5);
                            tconsum.Columns["Data"].SetOrdinal(1);
                            tconsum.Columns.Remove("Cladire");
                            dataGridView1.DataSource = tconsum;
                            dataGridView1.AutoResizeColumns();
                            dataGridView1.Columns["Angajat"].ReadOnly = true;
                            dataGridView1.Columns["Material"].ReadOnly = true;
                            dataGridView1.Columns["Pret"].ReadOnly = true;
                            dataGridView1.Columns["Valoare"].ReadOnly = true;
                            dataGridView1.Columns["Data"].ReadOnly = true;
                            dataGridView1.Columns["ID"].ReadOnly = true;
                            labelrezultat(tconsum);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                    }
                }
                if (Form1.consum == 2)
                    try
                    {
                        OleDbCommand sconsum = new OleDbCommand("SELECT * FROM Consum WHERE ID_angajat=@idu AND Data<=@d1 AND Data>=@d2 AND Cantitate>0 ORDER BY Data ASC", con);
                        DateTime d1 = Convert.ToDateTime(dateTimePicker2.Value);
                        DateTime d2 = Convert.ToDateTime(dateTimePicker1.Value);
                        int randomnumar = Convert.ToInt32(comboBox1.SelectedValue);
                        sconsum.Parameters.AddWithValue("@idu", randomnumar);
                        sconsum.Parameters.AddWithValue("@d1", d1.ToShortDateString());
                        sconsum.Parameters.AddWithValue("@d2", d2.ToShortDateString());
                        OleDbDataAdapter aconsum = new OleDbDataAdapter(sconsum);
                        DataTable tconsum = new DataTable();
                        aconsum.Fill(tconsum);
                        OleDbCommand smateriale = new OleDbCommand("SELECT * FROM Materiale", con);
                        OleDbDataAdapter amateriale = new OleDbDataAdapter(smateriale);
                        amateriale.Fill(tmateriale);
                        tconsum.Columns.Add("Material", typeof(string));
                        tconsum.Columns.Add("Pret", typeof(double));
                        tconsum.Columns.Add("Valoare", typeof(double));
                        foreach (DataRow c in tconsum.Rows)
                            foreach (DataRow m in tmateriale.Rows)
                            {
                                if (Convert.ToInt32(m["ID"]) == Convert.ToInt32(c["ID_material"]))
                                {
                                    c["Material"] = m["Denumire"];
                                    c["Pret"] = m["Pret_unitar"];
                                    c["Valoare"] = System.Math.Round(Convert.ToDouble(m["Pret_unitar"]) * Convert.ToDouble(c["Cantitate"]), 2);
                                }
                            }
                        tconsum.Columns.Remove("ID_angajat");
                        tconsum.Columns["Material"].SetOrdinal(2);
                        tconsum.Columns["Pret"].SetOrdinal(3);
                        tconsum.Columns["Valoare"].SetOrdinal(4);
                        tconsum.Columns["Cantitate"].SetOrdinal(5);
                        tconsum.Columns["Data"].SetOrdinal(1);
                        dataGridView1.DataSource = tconsum;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.Columns["Material"].ReadOnly = true;
                        dataGridView1.Columns["Pret"].ReadOnly = true;
                        dataGridView1.Columns["Valoare"].ReadOnly = true;
                        dataGridView1.Columns["Data"].ReadOnly = true;
                        dataGridView1.Columns["ID"].ReadOnly = true;
                        dataGridView1.Columns["Cladire"].ReadOnly = true;
                        labelrezultat(tconsum);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("" + ex);
                    }
                if (Form1.consum == 3)
                    try
                    {
                        OleDbCommand sconsum = new OleDbCommand("SELECT * FROM Consum WHERE Data<=@d1 AND Data>=@d2 AND Cantitate>0 ORDER BY Data ASC", con);
                        DateTime d1 = Convert.ToDateTime(dateTimePicker2.Value);
                        DateTime d2 = Convert.ToDateTime(dateTimePicker1.Value);
                        sconsum.Parameters.AddWithValue("@d1", d1.ToShortDateString());
                        sconsum.Parameters.AddWithValue("@d2", d2.ToShortDateString());
                        OleDbDataAdapter aconsum = new OleDbDataAdapter(sconsum);
                        DataTable tconsum = new DataTable();
                        aconsum.Fill(tconsum);
                        OleDbCommand sangajati = new OleDbCommand("SELECT * FROM Angajati", con);
                        OleDbDataAdapter aangajati = new OleDbDataAdapter(sangajati);
                        aangajati.Fill(tangajati);
                        OleDbCommand smateriale = new OleDbCommand("SELECT * FROM Materiale", con);
                        OleDbDataAdapter amateriale = new OleDbDataAdapter(smateriale);
                        amateriale.Fill(tmateriale);
                        tconsum.Columns.Add("Material", typeof(string));
                        tconsum.Columns.Add("Pret", typeof(double));
                        tconsum.Columns.Add("Valoare", typeof(double));
                        foreach (DataRow c in tconsum.Rows)
                            foreach (DataRow m in tmateriale.Rows)
                            {
                                if (Convert.ToInt32(m["ID"]) == Convert.ToInt32(c["ID_material"]))
                                {
                                    c["Material"] = m["Denumire"];
                                    c["Pret"] = m["Pret_unitar"];
                                    c["Valoare"] = System.Math.Round(Convert.ToDouble(m["Pret_unitar"]) * Convert.ToDouble(c["Cantitate"]), 2);
                                }
                            }
                        tconsum.Columns.Add("Angajat", typeof(string));
                        foreach (DataRow c in tconsum.Rows)
                            foreach (DataRow a in tangajati.Rows)
                                if (Convert.ToInt32(a["ID"]) == Convert.ToInt32(c["ID_angajat"]))
                                    c["Angajat"] = a["nume"];
                        tconsum.Columns.Remove("ID_angajat");
                        tconsum.Columns["Angajat"].SetOrdinal(1);
                        tconsum.Columns["Material"].SetOrdinal(2);
                        tconsum.Columns["Pret"].SetOrdinal(3);
                        tconsum.Columns["Valoare"].SetOrdinal(4);
                        tconsum.Columns["Cantitate"].SetOrdinal(5);
                        tconsum.Columns["Cladire"].SetOrdinal(2);
                        tconsum.Columns["Data"].SetOrdinal(1);
                        dataGridView1.DataSource = tconsum;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.Columns["Angajat"].ReadOnly = true;
                        dataGridView1.Columns["Material"].ReadOnly = true;
                        dataGridView1.Columns["Pret"].ReadOnly = true;
                        dataGridView1.Columns["Valoare"].ReadOnly = true;
                        dataGridView1.Columns["Data"].ReadOnly = true;
                        dataGridView1.Columns["ID"].ReadOnly = true;
                        dataGridView1.Columns["Cladire"].ReadOnly = true;
                        labelrezultat(tconsum);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex);
                    }
                if (Form1.consum == 4)
                {
                    try
                    {
                        OleDbCommand sangajati = new OleDbCommand("SELECT * FROM Angajati", con);
                        OleDbDataAdapter aangajati = new OleDbDataAdapter(sangajati);
                        aangajati.Fill(tangajati);
                        DateTime d1 = Convert.ToDateTime(dateTimePicker2.Value);
                        DateTime d2 = Convert.ToDateTime(dateTimePicker1.Value);
                        OleDbCommand sconsum = new OleDbCommand("SELECT * FROM Consum WHERE Data<=@d1 AND Data>=@d2 AND ID_material=@id AND Cantitate>0 ORDER BY Data ASC", con);
                        sconsum.Parameters.AddWithValue("@d1", d1.ToShortDateString());
                        sconsum.Parameters.AddWithValue("@d2", d2.ToShortDateString());
                        sconsum.Parameters.AddWithValue("@id", Convert.ToInt32(comboBox1.SelectedValue));
                        OleDbDataAdapter aconsum = new OleDbDataAdapter(sconsum);
                        DataTable tconsum = new DataTable();
                        aconsum.Fill(tconsum);
                        tconsum.Columns.Add("Valoare", typeof(double));
                        pu = 0;
                        double ca = 0;
                        string um = "";
                        foreach (DataRow c in tconsum.Rows)
                            foreach (DataRow m in tmateriale.Rows)
                            {
                                if (Convert.ToInt32(m["ID"]) == Convert.ToInt32(c["ID_material"]))
                                {
                                    c["Valoare"] = System.Math.Round(Convert.ToDouble(m["Pret_unitar"]) * Convert.ToDouble(c["Cantitate"]), 2);
                                    pu = Convert.ToDouble(m["Pret_unitar"]);
                                    ca = ca + Convert.ToDouble(c["cantitate"]);
                                    um = m["UM"].ToString();
                                }
                            }
                        tconsum.Columns.Add("Angajat", typeof(string));
                        foreach (DataRow c in tconsum.Rows)
                            foreach (DataRow a in tangajati.Rows)
                                if (Convert.ToInt32(a["ID"]) == Convert.ToInt32(c["ID_angajat"]))
                                    c["Angajat"] = a["nume"];
                        tconsum.Columns.Remove("ID_angajat");
                        tconsum.Columns["Angajat"].SetOrdinal(1);
                        tconsum.Columns["Valoare"].SetOrdinal(5);
                        tconsum.Columns["Data"].SetOrdinal(1);
                        dataGridView1.DataSource = tconsum;
                        dataGridView1.AutoResizeColumns();
                        dataGridView1.Columns["Angajat"].ReadOnly = true;
                        dataGridView1.Columns["Valoare"].ReadOnly = true;
                        dataGridView1.Columns["Data"].ReadOnly = true;
                        dataGridView1.Columns["ID"].ReadOnly = true;
                        dataGridView1.Columns["Cladire"].ReadOnly = true;
                        labelrezultat(tconsum);
                        if (pu != 0)
                            label5.Text = label5.Text + " (preț unitar: " + pu + " lei), cantitate consumată: " + ca + " " + um;
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex + "");
                    }
                }
                if (dataGridView1.DataSource != null)
                    try
                    {
                        dataGridView1.Columns.Remove("ID_material");
                    }
                    catch (Exception)
                    {

                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            con.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    OleDbCommand uconsum = new OleDbCommand("UPDATE Consum SET Cantitate=@c WHERE ID=@id", con);
                    OleDbCommand ustoc = new OleDbCommand("UPDATE Stoc SET Cantitate=@ca WHERE ID_material=@ida", con);
                    OleDbCommand sconsum = new OleDbCommand("SELECT * FROM Consum", con);
                    OleDbCommand sstoc = new OleDbCommand("SELECT * FROM Stoc", con);
                    OleDbDataAdapter aconsum = new OleDbDataAdapter(sconsum);
                    OleDbDataAdapter astoc = new OleDbDataAdapter(sstoc);
                    DataTable tconsum = new DataTable();
                    DataTable tstoc = new DataTable();
                    aconsum.Fill(tconsum);
                    astoc.Fill(tstoc);
                    bool k = false;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        foreach (DataRow c in tconsum.Rows)
                            foreach (DataRow s in tstoc.Rows)
                                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == Convert.ToInt32(c["id"]))
                                    if (Convert.ToInt32(c["id_material"]) == Convert.ToInt32(s["id_material"]))
                                        if (Convert.ToDouble(s["Cantitate"]) + Convert.ToDouble(c["Cantitate"]) >= Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value))
                                        {
                                            con.Open();
                                            uconsum.Parameters.AddWithValue("@c", Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value));
                                            uconsum.Parameters.AddWithValue("@id", Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value));
                                            uconsum.ExecuteNonQuery();
                                            ustoc.Parameters.AddWithValue("@ca", (Convert.ToDouble(s["Cantitate"]) - (Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) - Convert.ToDouble(c["Cantitate"]))));
                                            ustoc.Parameters.AddWithValue("@ida", Convert.ToInt32(s["ID_material"]));
                                            ustoc.ExecuteNonQuery();
                                            k = true;
                                            con.Close();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Se poate crește consumul materialului " + comboBox1.Text + " cu doar " + s["Cantitate"] + " unități!\nOperație eșuată!");
                                            comboBox1_SelectedIndexChanged(sender, e);
                                        }
                    }
                    if (k == true)
                    {
                        MessageBox.Show("Modificările au fost înregistrate.");
                        this.Close();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
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
                                if (cellColumnIndex == 2)
                                    worksheet.Cells[cellRowIndex, cellColumnIndex] = Convert.ToDateTime(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            }
                            cellColumnIndex++;
                        }
                        cellColumnIndex = 1;
                        cellRowIndex++;
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    workbook = null;
                    excel = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Form1.consum == 4)
                button1.Visible = true;
            DateTime d1 = Convert.ToDateTime(dateTimePicker2.Value);
            DateTime d2 = Convert.ToDateTime(dateTimePicker1.Value);
            OleDbCommand sconsum = new OleDbCommand("SELECT * FROM Consum WHERE Data<=@d1 AND Data>=@d2 AND ID_material=@id AND Cantitate>0 ORDER BY Data ASC", con);
            sconsum.Parameters.AddWithValue("@d1", d1.ToShortDateString());
            sconsum.Parameters.AddWithValue("@d2", d2.ToShortDateString());
            sconsum.Parameters.AddWithValue("@id", Convert.ToInt32(comboBox1.SelectedValue));
            OleDbDataAdapter aconsum = new OleDbDataAdapter(sconsum);
            DataTable tconsum = new DataTable();
            aconsum.Fill(tconsum);
            tconsum.Columns.Add("Valoare", typeof(double));
            foreach (DataRow c in tconsum.Rows)
                foreach (DataRow m in tmateriale.Rows)
                {
                    if (Convert.ToInt32(m["ID"]) == Convert.ToInt32(c["ID_material"]))
                        c["Valoare"] = System.Math.Round(Convert.ToDouble(m["Pret_unitar"]) * Convert.ToDouble(c["Cantitate"]), 2);
                }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                foreach (DataRow r in tconsum.Rows)
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == Convert.ToInt32(r["ID"])) 
                        if(Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value)!=Convert.ToInt32(r["Cantitate"]))
                            dataGridView1.Rows[i].Cells[4].Value = System.Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value) * pu, 2);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtt = new DataTable();
            OleDbCommand sangajati = new OleDbCommand("SELECT * FROM Angajati WHERE Lucreaza=@l", con);
            if (checkBox1.Checked == true)
                sangajati.Parameters.AddWithValue("@l", false);
            else
                sangajati.Parameters.AddWithValue("@l", true);
            OleDbDataAdapter aangajati = new OleDbDataAdapter(sangajati);
            aangajati.Fill(dtt);
            comboBox1.DataSource = dtt;
            comboBox1.DisplayMember = "Nume";
            comboBox1.ValueMember = "ID";
            comboBox1_SelectedIndexChanged(sender, e);
        }
    }
}

