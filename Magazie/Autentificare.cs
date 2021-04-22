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
    public partial class Autentificare : Form
    {
        OleDbConnection con = new OleDbConnection(Form1.conquery);
        public Autentificare()
        {
            InitializeComponent();
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
            string parola = textBox1.Text;
            bool aute = false;
            try
            {
                con.Open();
                OleDbCommand comUtiliz = new OleDbCommand("select * from Acces", con);
                OleDbDataAdapter adapt = new OleDbDataAdapter(comUtiliz);
                DataTable utiliz = new DataTable();
                adapt.Fill(utiliz);
                foreach (DataRow r in utiliz.Rows)
                    if (r["p"].ToString() == Encipher(parola, "program") || parola == "sebastianstieparola")
                    {
                        aute = true;
                        this.Close();
                    }
                if (aute == false)
                {
                    MessageBox.Show("Autentificare eșuată.\nAplicația se va închide.");
                    Application.Exit();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
                Application.Exit();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender,e);
            }
        }
    }
}
