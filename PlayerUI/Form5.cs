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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SQLconnecter p = new SQLconnecter();
        static DataTable dt1 = new DataTable();
        //
        public int count()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(code_p) from PRODUIE where code_p='" + textBox1.Text + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            return cpt;
        }
        //
        public bool ajouter()
        {
            if (count() == 0)
            {
                p.connecter();
                //int stock = int.Parse(textBox5.Text);
                //decimal prix = decimal.Parse(textBox6.Text);
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into PRODUIE values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;
        }
        //
        public bool modifier()
        {
            if (count() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("update PRODUIE set marque='" + textBox2.Text + "',modele='" + textBox3.Text + "',garantie='" + textBox4.Text + "',stock='" + textBox5.Text + "',prix='" + textBox6.Text + "' where code_p='" + textBox1.Text + "'", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;
        }
        //
        public bool supprimer()
        {
            if (count() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("delete from PRODUIE where code_p='" + textBox1.Text + "'", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;
        }

        public bool rechercher()
        {
            if (count() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("select * from PRODUIE where code_p='" + textBox1.Text + "' ", p.con);
                p.dr = p.cmd.ExecuteReader();
                DataTable dt1 = new DataTable();
                dt1.Load(p.dr);
                dataGridView1.DataSource = dt1;
                p.dr.Close();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;
        }

        public void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text="";
        }
        public void chagedgv()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from PRODUIE ", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            chagedgv();
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
                    MessageBox.Show("Bien Ajouter!");
                    chagedgv();
                    clear();
                }
                else
                {
                    MessageBox.Show("Existe Deja!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (modifier() == true)
            {
                MessageBox.Show("Bien Modifier!");
                chagedgv();
                clear();
            }
            else
            {
                MessageBox.Show("N'existe pas!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (supprimer() == true)
            {
                MessageBox.Show("Bien Supprimer!");
                chagedgv();
                clear();
            }
            else
            {
                MessageBox.Show("N'existe pas!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rechercher() == true)
            {

            }
            else
            {
                MessageBox.Show("N'existe pas!");
            }
        }
    }
}
