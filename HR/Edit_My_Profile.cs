using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_10_3.HR
{
    public partial class Edit_My_Profile : Form
    {
        public Edit_My_Profile()
        {
            InitializeComponent();
        }
        public int idmyprofile = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                //this.Text = open.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool verif()
        {
            if ((txtfirstname.Text.Trim() == "") ||
                    (txtlastname.Text.Trim() == "") ||

                    (txtuser.Text.Trim() == "") ||
                    (txtpass.Text.Trim() == ""))
            {
                MessageBox.Show("Please try again !!!!!!", "error");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Edit_My_Profile_Load(object sender, EventArgs e)
        {

        }
        Users us = new Users();
        private void button3_Click(object sender, EventArgs e)
        {
            string fname = txtfirstname.Text;
            string lname = txtlastname.Text;
            string pwd = txtpass.Text;


            try
            {
                if (us.Update_Usermy(idmyprofile, fname, lname, txtuser, pwd, verif(), pictureBox1, txtemail) == 1)
                {
                    
                    this.Close();
                    
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Please try again2 !!!!!!", "error");
            }
        }
    }
}
