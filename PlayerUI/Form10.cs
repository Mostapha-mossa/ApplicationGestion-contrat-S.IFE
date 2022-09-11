using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SQLconnecter p = new SQLconnecter();
        static DataTable dt1 = new DataTable();
        //
        public string code_c;
        public int count()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(CODE_C) from CONTRAT_engagement where CODE_C='" + textBox1.Text + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            return cpt;
        }
        //
        public bool ajouter()
        {

            if (count() == 0)
            {
                p.connecter();

                p.cmd = new System.Data.SqlClient.SqlCommand("insert into CONTRAT_engagement values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'," + textBox8.Text + ")", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool vide = false;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox && ((TextBox)c).Text == "")
                {
                    vide = true;
                }
            }
            if (vide)
            {
                MessageBox.Show("Merci de Remplir Tous les champs");
            }
            else
            {
                if (ajouter() == true)
                {
                    code_c = textBox1.Text;
                    MessageBox.Show("Bien Ajouter!");
                    Form11 q2 = new Form11();
                    q2.Show();
                    
                }
                else
                {
                    p.code_c = textBox1.Text;
                    MessageBox.Show("Existe Deja!");
                    Form11 q2 = new Form11();
                    q2.Show();
                }
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }
    }
}
