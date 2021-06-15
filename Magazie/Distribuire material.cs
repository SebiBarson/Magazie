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
    public partial class Distribuire_material : Form
    {
        OleDbConnection con = new OleDbConnection(Form1.conquery);
        DataTable tstoc = new DataTable();
        public Distribuire_material()
        {
            InitializeComponent();
            try
            {
                con.Open();
                OleDbCommand cp = new OleDbCommand("SELECT ID,Denumire FROM materiale WHERE Arhivat=false ORDER BY Denumire ASC", con);
                OleDbDataAdapter ap = new OleDbDataAdapter(cp);
                DataTable tp = new DataTable();
                ap.Fill(tp);
                comboBox1.DataSource = tp;
                comboBox1.DisplayMember = "Denumire";
                comboBox1.ValueMember = "ID";
                OleDbCommand cstoc = new OleDbCommand("SELECT ID, ID_material, Cantitate, Data_intr FROM Stoc WHERE Arhivat=false", con);
                OleDbDataAdapter astoc = new OleDbDataAdapter(cstoc);
                astoc.Fill(tstoc);
                despre_material();
                DataTable tangajati = new DataTable();
                OleDbCommand sangajati = new OleDbCommand("SELECT * FROM Angajati", con);
                OleDbDataAdapter aangajati = new OleDbDataAdapter(sangajati);
                aangajati.Fill(tangajati);
                comboBox2.DataSource = tangajati;
                comboBox2.DisplayMember = "Nume";
                comboBox2.ValueMember = "ID";
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

        private void despre_material()
        {
            try
            {
                foreach (DataRow r in tstoc.Rows)
                    if (Convert.ToInt32(r["ID_material"]) == Convert.ToInt32(comboBox1.SelectedValue))
                    {
                        numericUpDown1.Maximum = Convert.ToInt32(r["Cantitate"]);
                        if (Convert.ToInt32(r["Cantitate"]) > 0)
                        {
                            lb_cant.Text = "(În stoc: " + Convert.ToInt32(r["Cantitate"]) + " unități)";
                            lb_cant.ForeColor = Color.Black;
                        }
                        else
                        {
                            lb_cant.Text = "ATENȚIE! Nu mai există pe stoc!!!";
                            lb_cant.ForeColor = Color.Red;
                        }
                    }
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
        private void scade_stoc(int idp, double ca)
        {
            double canti = 0;
            OleDbCommand cstoc = new OleDbCommand("SELECT ID, ID_material, Cantitate, Data_intr FROM Stoc WHERE Arhivat=false", con);
            DataTable dt = new DataTable();
            OleDbDataAdapter addap = new OleDbDataAdapter(cstoc);
            addap.Fill(dt);
            foreach (DataRow r in dt.Rows)
                if (Convert.ToInt32(r["id_material"]) == idp)
                    canti = Convert.ToDouble(r["cantitate"]);
            OleDbCommand com = new OleDbCommand("UPDATE Stoc SET Cantitate=@c WHERE ID_material=@id ", con);
            com.Parameters.AddWithValue("@c", canti - ca);
            com.Parameters.AddWithValue("@id", idp);
            com.ExecuteNonQuery();
        }
        private string cladire(int a)
        {
            OleDbCommand sa = new OleDbCommand("SELECT * FROM Angajati", con);
            DataTable ta = new DataTable();
            OleDbDataAdapter aa = new OleDbDataAdapter(sa);
            aa.Fill(ta);
            foreach (DataRow r in ta.Rows)
                if (Convert.ToInt32(r["ID"]) == Convert.ToInt32(comboBox2.SelectedValue))
                    return r["Cladire"].ToString();
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand iconsum=new OleDbCommand("INSERT INTO Consum(ID_material, ID_angajat, Cladire, Cantitate, Data) VALUES('"+Convert.ToInt32(comboBox1.SelectedValue)+"','"+Convert.ToInt32(comboBox2.SelectedValue)+"','"+cladire(Convert.ToInt32(comboBox2.SelectedValue))+"','"+Convert.ToDouble(numericUpDown1.Value)+"','"+dateTimePicker1.Value.ToShortDateString()+"')",con);
                iconsum.ExecuteNonQuery();
                scade_stoc(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToDouble(numericUpDown1.Value));
                MessageBox.Show("Operațiunee reușită!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            despre_material();
        }
    }
}
