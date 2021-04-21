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
    public partial class Stergere_material : Form
    {
        OleDbConnection con = new OleDbConnection(Form1.conquery);
        public Stergere_material()
        {
            InitializeComponent();
            incarcare();
        }

        private void incarcare()
        {
            try
            {
                OleDbCommand cp = new OleDbCommand("SELECT ID,Denumire FROM materiale where arhivat=false Order by denumire ASC", con);
                DataTable t_materiale = new DataTable();
                OleDbDataAdapter a_materiale = new OleDbDataAdapter(cp);
                a_materiale.Fill(t_materiale);
                comboBox1.DataSource = t_materiale;
                comboBox1.DisplayMember = "Denumire";
                comboBox1.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Stergere_material_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                int c=Convert.ToInt32(comboBox1.SelectedValue);
                OleDbCommand cm = new OleDbCommand("DELETE * FROM Materiale WHERE ID=@id", con);
                cm.Parameters.AddWithValue("@id", c);
                cm.ExecuteNonQuery();
                OleDbCommand cs = new OleDbCommand("DELETE * FROM Stoc WHERE ID_material=@id", con);
                cs.Parameters.AddWithValue("@id", c);
                cs.ExecuteNonQuery();
                OleDbCommand cc = new OleDbCommand("DELETE * FROM Consum WHERE ID_material=@id", con);
                cc.Parameters.AddWithValue("@id", c);
                cc.ExecuteNonQuery();
                MessageBox.Show("Operatiune reusita!");
                incarcare();
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
