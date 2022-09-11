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
    public partial class Form2 : Form
    {
        public Form2()
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(CIN) from CLIENT where CIN='" + maskedTextBox1.Text + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            return cpt;
        }
        //
        public bool ajouter()
        {
            if (count() == 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into CLIENT values ('" + textBox1.Text + "','" + maskedTextBox1.Text + "','" + maskedTextBox2.Text + "','" + comboBox1.SelectedValue + "')", p.con);
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
                p.cmd = new System.Data.SqlClient.SqlCommand("update CLIENT set nom_prenom='" + textBox1.Text + "',N_Telephone='" + maskedTextBox2.Text + "',code_v='" + comboBox1.SelectedValue + "' where CIN='" + maskedTextBox1.Text + "'", p.con);
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
                p.cmd = new System.Data.SqlClient.SqlCommand("delete from CLIENT where CIN='" + maskedTextBox1.Text + "'", p.con);
                p.cmd.ExecuteNonQuery();
                p.deconnecter();
                return true;
            }
            p.deconnecter();
            return false;
        }

        
        public void combo1()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from VILLE", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox1.DataSource = p.dt;
            comboBox1.DisplayMember = "nom_ville";
            comboBox1.ValueMember = "CODE_v";
            p.dr.Close();
            p.deconnecter();
        }

        public bool rechercher()
        {
            if (count() != 0)
            {
                p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from CLIENT where CIN = '" + maskedTextBox1.Text + "' ", p.con);
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


        public void chagedgv()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select CLIENT.CIN,CLIENT.nom_prenom,CLIENT.N_Telephone,ville.nom_ville from CLIENT ,ville where CLIENT.code_v=ville.code_v ", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }

        //btn close childForm
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void clear()
        {
            textBox1.Text = maskedTextBox1.Text  = maskedTextBox2.Text = "";
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            combo1();
      
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
            try {
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
            catch { }
            
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

        private void Form2_Enter(object sender, EventArgs e)
        {

        }
    }
}
