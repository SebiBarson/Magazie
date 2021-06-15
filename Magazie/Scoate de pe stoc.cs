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
    public partial class Scoate_de_pe_stoc : Form
    {
        OleDbConnection con = new OleDbConnection(Form1.conquery);
        DataTable t_stoc = new DataTable();
        double cant;
        public Scoate_de_pe_stoc()
        {
            InitializeComponent();
            try
            {
                con.Open();
                OleDbCommand cs = new OleDbCommand("SELECT * FROM Stoc WHERE Arhivat=false", con);
                OleDbDataAdapter a_stoc = new OleDbDataAdapter(cs);
                a_stoc.Fill(t_stoc);
                OleDbCommand cp = new OleDbCommand("SELECT * FROM materiale WHERE Arhivat=false order by denumire ASC", con);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (label2.Visible == true)
            {
                label2.Visible = false;
                numericUpDown1.Visible = false;
            }
            else
            {
                label2.Visible = true;
                numericUpDown1.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (checkBox1.Checked == true)
                {
                    OleDbCommand com = new OleDbCommand("UPDATE Stoc SET Cantitate=0 WHERE ID=@id", con);
                    com.Parameters.AddWithValue("@id", Convert.ToInt32(material_e.SelectedValue));
                    com.ExecuteNonQuery();
                    MessageBox.Show("Operatie realizata cu succes.");
                }
                else
                {

                    foreach (DataRow r in t_stoc.Rows)
                        if (Convert.ToInt32(material_e.SelectedValue) == Convert.ToInt32(r["id"]))
                            cant = Convert.ToDouble(r["Cantitate"]);
                    numericUpDown1.Maximum = Convert.ToDecimal(cant);
                    OleDbCommand com2 = new OleDbCommand("UPDATE Stoc SET Cantitate=@c WHERE ID=@id", con);
                    double cc = cant - Convert.ToDouble(numericUpDown1.Value);
                    com2.Parameters.AddWithValue("@c", cc);
                    com2.Parameters.AddWithValue("@id", Convert.ToInt32(material_e.SelectedValue));
                    com2.ExecuteNonQuery();
                    MessageBox.Show("Operatie realizata cu succes.");
                }
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
}
