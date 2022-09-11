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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
         SQLconnecter p = new SQLconnecter();
        static DataTable dt1 = new DataTable();
        public int count()
        {
            int cpt;
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select count(code_c) from FACTURE where code_c='" + comboBox1.SelectedValue + "'", p.con);
            cpt = (int)p.cmd.ExecuteScalar();
            return cpt;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
             try
            {
                dt1.Clear();
                p.connecter();
                  if (count() == 0)
                {
                p.cmd = new System.Data.SqlClient.SqlCommand("exec p3 '" + comboBox1.SelectedValue + "'," + int.Parse(textBox2.Text), p.con);
                p.cmd.ExecuteNonQuery();
                }
                
                p.cmd = new System.Data.SqlClient.SqlCommand("exec p1 '" + comboBox1.SelectedValue + "',"+int.Parse(textBox2.Text), p.con);
                p.dr = p.cmd.ExecuteReader();
                dt1.Load(p.dr);
                CrystalReport2 cr = new CrystalReport2();
                cr.SetDataSource(dt1);
                crystalReportViewer1.ReportSource = cr;
                p.deconnecter();
               
            }
             catch
             {

             }
      
        }

        private void Form7_Load(object sender, EventArgs e)
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
