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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
     
        //btn contra
        private void btnContra_Click(object sender, EventArgs e)
        {    
            openChildForm(new Form4());
        }

        //btn ville
        private void btnville_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
        }
        //btn produit
        private void btnProduit_Click(object sender, EventArgs e)
        {
            openChildForm(new Form5());
        }
        //btn client
        private void btnClient_Click(object sender, EventArgs e)
        {
            openChildForm(new Form2());   
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            openChildForm(new Form6());
        }

        private void btnFacture_Click(object sender, EventArgs e)
        {
            openChildForm(new Form7());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Form8());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form9());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Form10());
        }

        
    }
}
