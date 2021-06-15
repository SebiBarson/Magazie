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
    public partial class Form1 : Form
    {
        public static string conquery = @"Provider=Microsoft.ACE.OleDb.12.0; Data Source=BAZAx.accdb";//Access 2007/2010/2013
        OleDbConnection con = new OleDbConnection(conquery);
        public static int consum;
        public static bool f1;
        public Form1()
        {
            InitializeComponent();
            load1();
            load2();
        }
        private void load1()
        {
			try{
				con.Open();
			}catch (Exception ex)
            {
                conquery = @"Provider=Microsoft.ACE.OleDb.16.0; Data Source=BAZAx.accdb";//Access 2016
            }
			finally
            {
                con.Close();
            }
            try
            {
				con.Open();
                OleDbCommand cs = new OleDbCommand("SELECT ID, ID_material, Cantitate FROM Stoc WHERE Cantitate<=1 AND Cantitate>0 AND Arhivat=false order by cantitate asc", con);
                DataTable t_stoc = new DataTable();
                OleDbDataAdapter a_stoc = new OleDbDataAdapter(cs);
                a_stoc.Fill(t_stoc);
                OleDbCommand cp = new OleDbCommand("SELECT ID,Denumire FROM materiale WHERE Arhivat=false", con);
                DataTable t_materiale = new DataTable();
                OleDbDataAdapter a_materiale = new OleDbDataAdapter(cp);
                a_materiale.Fill(t_materiale);
                t_stoc.Columns.Add("Material", typeof(string));
                foreach (DataRow s in t_stoc.Rows)
                    foreach (DataRow p in t_materiale.Rows)
                        if (Convert.ToInt32(p["ID"]) == Convert.ToInt32(s["ID_material"]))
                            s["material"] = p["denumire"];
                t_stoc.Columns.Remove("ID_material");
                t_stoc.Columns["Material"].SetOrdinal(1);
                dataGridView1.DataSource = t_stoc;
                dataGridView1.AutoResizeColumn(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            finally
            {
                con.Close();
            }
        }
        private void load2()
        {
            try
            {
                con.Open();
                OleDbCommand cs = new OleDbCommand("SELECT ID, ID_material, Cantitate FROM Stoc WHERE Cantitate=0 AND Arhivat=false", con);
                DataTable t_stoc = new DataTable();
                OleDbDataAdapter a_stoc = new OleDbDataAdapter(cs);
                a_stoc.Fill(t_stoc);
                OleDbCommand cp = new OleDbCommand("SELECT ID,Denumire FROM materiale WHERE Arhivat=false", con);
                DataTable t_materiale = new DataTable();
                OleDbDataAdapter a_materiale = new OleDbDataAdapter(cp);
                a_materiale.Fill(t_materiale);
                t_stoc.Columns.Add("Material", typeof(string));
                foreach (DataRow s in t_stoc.Rows)
                    foreach (DataRow p in t_materiale.Rows)
                        if (Convert.ToInt32(p["ID"]) == Convert.ToInt32(s["ID_material"]))
                            s["material"] = p["denumire"];
                t_stoc.Columns.Remove("ID_material");
                t_stoc.Columns["Material"].SetOrdinal(1);
                t_stoc.DefaultView.Sort = "Material";
                t_stoc = t_stoc.DefaultView.ToTable();
                dataGridView2.DataSource = t_stoc;
                dataGridView2.AutoResizeColumn(1);
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
        private void Form1_Load(object sender, EventArgs e)
        {
            Autentificare a = new Autentificare();
            a.ShowDialog();
        }
        
        private void valoareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand cs = new OleDbCommand("SELECT ID, ID_material, Cantitate FROM Stoc WHERE Arhivat=false", con);
                DataTable t_stoc = new DataTable();
                OleDbDataAdapter a_stoc = new OleDbDataAdapter(cs);
                a_stoc.Fill(t_stoc);
                OleDbCommand cp = new OleDbCommand("SELECT * FROM materiale WHERE Arhivat=false", con);
                DataTable t_materiale = new DataTable();
                OleDbDataAdapter a_materiale = new OleDbDataAdapter(cp);
                a_materiale.Fill(t_materiale);
                double suma = 0;
                foreach (DataRow s in t_stoc.Rows)
                    foreach (DataRow p in t_materiale.Rows)
                        if (Convert.ToInt32(p["Id"]) == Convert.ToInt32(s["ID_material"]))
                            suma = suma + System.Math.Round(Convert.ToDouble(p["Pret_unitar"]) * Convert.ToDouble(s["cantitate"]),2);
                MessageBox.Show("Valoarea totală a stocului: " + suma);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex+"");
            }
            finally
            {
                con.Close();
            }
        }

        private void cladirea1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consum = 1;
            Consum a = new Consum();
            a.ShowDialog();
            load1();
            load2();
        }

        private void totalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consum = 2;
            Consum a = new Consum();
            a.ShowDialog();
            load1();
            load2();
        }

        private void perPersoanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consum = 3;
            Consum a = new Consum();
            a.ShowDialog();
            load1();
            load2();
        }

        private void afisareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stoc s = new Stoc();
            s.ShowDialog();
            load1();
            load2();
        }

        private void adaugareProdusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Adaugare_material a = new Adaugare_material();
            a.ShowDialog();
            load1();
            load2();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Distribuire_material d = new Distribuire_material();
            d.ShowDialog();
            load1();
            load2();
        }
        private static int Modec(int a, int b)
        {
            return (a % b + b) % b;
        }

        private static string Cipher(string input, string key, bool encipher)
        {
            for (int i = 0; i < key.Length; ++i)
                if (!char.IsLetter(key[i]))
                    return null; // Error

            string output = string.Empty;
            int nonAlphaCharCount = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (char.IsLetter(input[i]))
                {
                    bool cIsUpper = char.IsUpper(input[i]);
                    char offset = cIsUpper ? 'A' : 'a';
                    int keyIndex = (i - nonAlphaCharCount) % key.Length;
                    int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                    k = encipher ? k : -k;
                    char ch = (char)((Modec(((input[i] + k) - offset), 26)) + offset);
                    output += ch;
                }
                else
                {
                    output += input[i];
                    ++nonAlphaCharCount;
                }
            }

            return output;
        }

        public static string Encipher(string input, string key)
        {
            return Cipher(input, key, true);
        }

        public static string Decipher(string input, string key)
        {
            return Cipher(input, key, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void perMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consum = 4;
            Consum c = new Consum();
            c.ShowDialog();
            load1();
            load2();
        }

        private void arhivareMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {

            f1 = true;
            Arhivare a = new Arhivare();
            a.ShowDialog();
            load1();
            load2();
        }

        private void dezarhivareMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {

            f1 = false;
            Arhivare a = new Arhivare();
            a.ShowDialog();
            load1();
            load2();
        }

        private void schimbareParolaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Schimbare_parola s = new Schimbare_parola();
            s.ShowDialog();
            load1();
            load2();
        }
        
        private void stergereMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stergere_material s = new Stergere_material();
            s.ShowDialog();
            load1();
            load2();
        }
    }
}
