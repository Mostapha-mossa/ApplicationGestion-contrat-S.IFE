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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        SQLconnecter p = new SQLconnecter();
        static DataTable dt1 = new DataTable();
        
        private void Form11_Load(object sender, EventArgs e)
        {
            p.connecter();
            p.cmd = new System.Data.SqlClient.SqlCommand("select * from CONTRAT_engagement", p.con);
            p.dr = p.cmd.ExecuteReader();
            p.dt.Load(p.dr);
            comboBox1.DataSource = p.dt;
            comboBox1.DisplayMember = "nome_entreprise";
            comboBox1.ValueMember = "CODE_C";
            p.dr.Close();
            p.deconnecter();
           
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                dt1.Clear();
                p.connecter();
                p.cmd = new System.Data.SqlClient.SqlCommand("exec p4 '" + comboBox1.SelectedValue + "'", p.con);
                p.dr = p.cmd.ExecuteReader();
                dt1.Load(p.dr);
                CrystalReport5 cr = new CrystalReport5();
                cr.SetDataSource(dt1);
                crystalReportViewer1.ReportSource = cr;
                p.deconnecter();
            }
            catch
            {

            }
        }
    }
}
