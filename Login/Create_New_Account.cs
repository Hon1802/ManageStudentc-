using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_10_3
{
    public partial class Create_New_Account : Form
    {
        public Create_New_Account()
        {
            InitializeComponent();
        }
        Users us = new Users();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
        }
        public int check_exist(int idc)
        {
            int UserExist = 0;
            try
            {
                My_DB db = new My_DB();
                SqlCommand cmd = new SqlCommand();
                db.openConnection();
                SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM UserHR WHERE (id = @id)", db.GetConnection);
                check_id.Parameters.AddWithValue("@id", idc);
                UserExist = (int)check_id.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            if (UserExist > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private int idt()
        {
            for(int i = 0; i< 999; i++)
            { 
                if(check_exist(i) == 0)
                {
                    return i;
                }
            }
            return 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string fname = txtfirstname.Text;
            string lname = txtlastname.Text;
            string pwd = txtpass.Text;

            int idc = idt();
            try
            {
                if (us.Create_user(idc, fname, lname, txtuser, pwd, verif(), pictureBox1, txtemail)==1)
                {
                    Form1 f = new Form1();
                    this.Close();
                    f.ShowDialog();
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Please try again2 !!!!!!", "error");
            }
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

        private void Create_New_Account_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                //this.Text = open.FileName;
            }
        }
    }
}
