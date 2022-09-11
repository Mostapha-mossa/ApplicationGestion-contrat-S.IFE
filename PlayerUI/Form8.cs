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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SQLconnecter p = new SQLconnecter();
        static DataTable dt1 = new DataTable();
        private void Form8_Load(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                dt1.Clear();
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("exec p2 '" + comboBox1.SelectedValue + "'", p.con);
                p.dr = p.cmd.ExecuteReader();
                dt1.Load(p.dr);
                CrystalReport1 cr = new CrystalReport1();
                cr.SetDataSource(dt1);
                crytViewer1.ReportSource = cr;
                p.deconnecter();
            }
            catch
            {

            }
        }

        private void crytViewer1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
