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
    public partial class Form6 : Form
    {
        public Form6()
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(CODE_C) from detal_contrat where CODE_C='" + comboBox1.SelectedValue + "' AND CODE_P='" + comboBox2.SelectedValue + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            return cpt;
        }
        //
        public bool ajouter()
        {

            if (count() == 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("insert into detal_contrat values ('"  + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue+"','" + textBox3.Text + "')", p.con);
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
                p.cmd.CommandText = "update detal_contrat set CODE_p='" + comboBox2.SelectedValue + "',que='" + textBox3.Text  + "' where code_c='" + comboBox1.SelectedValue + "'";
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
                p.cmd = new System.Data.SqlClient.SqlCommand("delete from detal_contrat where CODE_C='" + comboBox1.SelectedValue + "'", p.con);
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from CONTRAT", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox1.DataSource = p.dt;
            comboBox1.DisplayMember = "CODE_C";
            comboBox1.ValueMember = "CODE_C";
            p.dr.Close();
            p.deconnecter();
        }
        public void combo2()
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from PRODUIE", p.con);
            p.dr = p.cmd.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(p.dr);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "marque";
            comboBox2.ValueMember = "CODE_P";
            p.dr.Close();
            p.deconnecter();
        }
        public bool rechercher()
        {
            if (count() != 0)
            {
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("select * from detal_contrat where code_c = '" + comboBox1.SelectedValue + "' ", p.con);
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
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from detal_contrat", p.con);
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
        public void clear()
        {
            textBox3.Text= "";
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            combo1();
            combo2();
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