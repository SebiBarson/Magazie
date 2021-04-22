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
    public partial class Arhivare : Form
    {
        OleDbConnection con = new OleDbConnection(Form1.conquery);
        DataTable t_materiale = new DataTable();
        public Arhivare()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            try
            {
                if (Form1.f1 == false)
                {
                    this.Text = "Dezarhivare";
                    button1.Text = "Dezarhivare";
                }
                con.Open();
                OleDbCommand cs = new OleDbCommand("SELECT Stoc.ID, Materiale.Denumire, Stoc.Cantitate, Materiale.Arhivat, Stoc.ID_material" +
                    " FROM Materiale INNER JOIN Stoc ON Materiale.ID = Stoc.ID_material WHERE(((Stoc.Cantitate) = 0) AND((Materiale.Arhivat) = @a)) ORDER BY (Materiale.Denumire)", con);
                cs.Parameters.AddWithValue("@a", !(Form1.f1));
                OleDbDataAdapter ds = new OleDbDataAdapter(cs);
                ds.Fill(t_materiale);
                comboBox1.DataSource = t_materiale;
                comboBox1.DisplayMember = "Denumire";
                comboBox1.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
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
                OleDbCommand com = new OleDbCommand("UPDATE Stoc SET Arhivat=True WHERE ID=@id", con);
                com.Parameters.AddWithValue("@id", Convert.ToInt32(comboBox1.SelectedValue));
                com.ExecuteNonQuery();
                int idu=0;
                    foreach (DataRow s in t_materiale.Rows)
                        if (Convert.ToInt32(comboBox1.SelectedValue) == Convert.ToInt32(s["ID"]))
                            idu = Convert.ToInt32(s["ID_material"]);
                OleDbCommand com2 = new OleDbCommand("UPDATE Materiale SET Arhivat=True WHERE ID=@id", con);
                com2.Parameters.AddWithValue("@id", idu);
                com2.ExecuteNonQuery();
                MessageBox.Show("Operație realizată cu succes.");
                this.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
