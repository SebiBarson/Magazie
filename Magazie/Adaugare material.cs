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
    public partial class Adaugare_material : Form
    {
        OleDbConnection con = new OleDbConnection(Form1.conquery);
        public Adaugare_material()
        {
            InitializeComponent();
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
                OleDbCommand imat = new OleDbCommand("INSERT INTO materiale(denumire, UM, Pret_unitar) VALUES(@d, @um, @p)", con);
                imat.Parameters.AddWithValue("@d", textBox1.Text);
                imat.Parameters.AddWithValue("@um", comboBox1.Text);
                imat.Parameters.AddWithValue("@p",Convert.ToDouble(numericUpDown2.Value));
                imat.ExecuteNonQuery();
                OleDbCommand smat = new OleDbCommand("SELECT * FROM materiale ORDER BY ID ASC", con);
                DataTable t_mat = new DataTable();
                OleDbDataAdapter a_mat = new OleDbDataAdapter(smat);
                a_mat.Fill(t_mat);
                int idmat = 0;
                foreach (DataRow r in t_mat.Rows)
                    idmat = Convert.ToInt32(r["ID"]);
                OleDbCommand istoc = new OleDbCommand("INSERT INTO Stoc(ID_material, Cantitate, Data_intr) VALUES(@idmaterial, @cant, @d)", con);
                istoc.Parameters.AddWithValue("@idmaterial", idmat);
                istoc.Parameters.AddWithValue("@cant", Convert.ToDouble(numericUpDown1.Value));
                istoc.Parameters.AddWithValue("@d", dateTimePicker1.Value.ToShortDateString());
                istoc.ExecuteNonQuery();
                MessageBox.Show("Adaugare reusita!");
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
