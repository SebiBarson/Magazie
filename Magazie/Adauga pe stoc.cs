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
    public partial class Adauga_pe_stoc : Form
    {
        OleDbConnection con = new OleDbConnection(Form1.conquery);
        DataTable t_stoc = new DataTable();
        double cant;
        public Adauga_pe_stoc()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            try
            {
                con.Open();
                OleDbCommand cs = new OleDbCommand("SELECT ID, ID_material, Cantitate FROM Stoc WHERE Arhivat=false", con);
                OleDbDataAdapter a_stoc = new OleDbDataAdapter(cs);
                a_stoc.Fill(t_stoc);
                OleDbCommand cp = new OleDbCommand("SELECT ID, Denumire, Pret_unitar FROM materiale WHERE Arhivat=false order by denumire ASC", con);
                DataTable t_materiale = new DataTable();
                OleDbDataAdapter a_materiale = new OleDbDataAdapter(cp);
                a_materiale.Fill(t_materiale);
                t_materiale.Columns.Add("cantitate", typeof(string));
                t_materiale.Columns.Add("ids", typeof(int));
                foreach (DataRow m in t_materiale.Rows)
                    foreach (DataRow s in t_stoc.Rows)
                        if (Convert.ToInt32(m["ID"]) == Convert.ToInt32(s["ID_material"]))
                        {
                            m["cantitate"] = s["cantitate"];
                            m["ids"] = s["id"];
                        }
                material_e.DataSource = t_materiale;
                material_e.DisplayMember = "denumire";
                material_e.ValueMember = "ids";
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
            try
            {
                con.Open();
                foreach (DataRow r in t_stoc.Rows)
                    if (Convert.ToInt32(material_e.SelectedValue) == Convert.ToInt32(r["id"]))
                        cant = Convert.ToDouble(r["Cantitate"]);
                cant = cant + Convert.ToDouble(numericUpDown1.Value);
                OleDbCommand com = new OleDbCommand("UPDATE Stoc SET Cantitate=@ca WHERE ID=@id", con);
                com.Parameters.AddWithValue("@ca", cant);
                com.Parameters.AddWithValue("@id", Convert.ToInt32(material_e.SelectedValue));
                com.ExecuteNonQuery();
                MessageBox.Show("Adaugare realizata cu succes.");
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
