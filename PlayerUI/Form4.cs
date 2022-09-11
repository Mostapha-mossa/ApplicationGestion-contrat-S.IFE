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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SQLconnecter p = new SQLconnecter();
        static DataTable dt1 = new DataTable();
        //
        public int count()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(CODE_C) from CONTRAT where CODE_C='" + maskedTextBox1.Text + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            return cpt;
        }
        //
        public bool ajouter()
        {

            if (count() == 0)
            {
                p.connecter();
                DateTime dt = DateTime.Parse(dateTimePicker1.Text);
                DateTime dt1 = DateTime.Parse(dateTimePicker2.Text);
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into CONTRAT values ('" + maskedTextBox1.Text + "','" + dt + "','" + dt1 + "','" + comboBox1.Text+ "','','','" + comboBox2.SelectedValue + "')", p.con);
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
                p.cmd.CommandText ="update CONTRAT set date_debut='" + dateTimePicker1.Value + "',date_fin='" + dateTimePicker2.Value + "',type_c='" + comboBox1.Text + "',CIN='" + comboBox2.SelectedValue + "' where code_c='" + maskedTextBox1.Text + "'";
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
                    p.cmd = new System.Data.SqlClient.SqlCommand("delete from FACTURE where CODE_C='" + maskedTextBox1.Text + "'", p.con);
                    p.cmd.ExecuteNonQuery();
                    p.cmd = new System.Data.SqlClient.SqlCommand("delete from CONTRAT where CODE_C='" + maskedTextBox1.Text + "'", p.con);
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from CLIENT", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox2.DataSource = p.dt;
            comboBox2.DisplayMember = "CIN";
            comboBox2.ValueMember = "CIN";
            p.dr.Close();
            p.deconnecter();
        }

        public bool rechercher()
        {
            if (count() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("select * from CONTRAT where code_c = '" + maskedTextBox1.Text + "' ", p.con);
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from CONTRAT", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(p.dr);
            dataGridView1.DataSource = dt1;
            p.dr.Close();
            p.deconnecter();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            combo1();
            chagedgv();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            }
            else
            {
                MessageBox.Show("N'existe pas!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
        {
            if (supprimer() == true)
            {
                MessageBox.Show("Bien Supprimer!");
                chagedgv();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
  
    
}
