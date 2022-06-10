using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project_10_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                try
                {
                    My_DB db = new My_DB();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = db.GetConnection;
                    cmd.CommandText = "select* from users where username = '" + textBoxusername.Text + "' and password = '" + textBoxpassword.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        textBoxusername.Clear();
                        textBoxpassword.Clear();
                        timer1.Enabled = true;


                    }
                    else
                    {
                        MessageBox.Show("Please check Username or Password again !!!!", "ERROL");
                        textBoxusername.Focus();
                        //textBoxpassword.Focus();
                    }
                } catch(Exception exp)
                {
                    MessageBox.Show("0x00001", "Information");
                }
                
            }else
            {
                try
                {
                    My_DB db = new My_DB();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = db.GetConnection;
                    cmd.CommandText = "select* from UserHR where uname = '" + textBoxusername.Text + "' and pwd = '" + textBoxpassword.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    //
                    SqlCommand command = new SqlCommand("select* from UserHR where uname = '" + textBoxusername.Text + "' and pwd = '" + textBoxpassword.Text + "'", db.GetConnection);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    DataTable table = new DataTable();
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    //
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        int HRID = Convert.ToInt16(table.Rows[0][0].ToString());
                        Global.SetGlobalUserId(HRID);
                        UserHR us = new UserHR();
                        Users ur = new Users();
                        string str2 = "select* from UserHR where uname = '" + textBoxusername.Text + "' and pwd = '" + textBoxpassword.Text + "'";

                        SqlCommand cmd2 = new SqlCommand(str2);
                        DataGridView dataload = new DataGridView();
                        us.dataGridView1.DataSource = ur.getScore(cmd2);
                        us.motbientam = Convert.ToInt32(us.dataGridView1.Rows[0].Cells[0].Value);
                        us.Name.Text = us.dataGridView1.Rows[0].Cells[1].Value.ToString() + " " + us.dataGridView1.Rows[0].Cells[2].Value.ToString();
                        byte[] b = (byte[])us.dataGridView1.Rows[0].Cells[5].Value;
                        us.pictureBox1.Image = us.ByteArrayToImage(b);
                        us.ShowDialog();
                        Hide();
                        textBoxusername.Clear();
                        textBoxpassword.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Please check Username or Password again !!!!", "ERROL");
                        textBoxusername.Focus();
                    }
                }
                
                 catch (Exception exp)
                {
                    MessageBox.Show("0x00001", "Information");
                }
            }    


        }
        private void F_Outpr(object sender, EventArgs e)
        {
            (sender as Main).isExit = false;
            (sender as Main).Close();
            this.Show();
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Register_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                Register_Form h = new Register_Form();
                h.ShowDialog();
            }
            else
            {
                Create_New_Account n = new Create_New_Account();
                n.ShowDialog();
            }

        }

        private void button_up_Click(object sender, EventArgs e)
        {
            try
            {
                if(radioButton1.Checked)
                {
                    Update_Form h = new Update_Form();
                    h.ShowDialog();
                }
                else
                {
                    HR.Forget_Password u = new HR.Forget_Password();
                    u.ShowDialog();
                }
            } catch (Exception exp)
            {
                MessageBox.Show("0x00001","Information");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(5);
            if(progressBar1.Value >= progressBar1.Maximum)
            {
                this.Hide();
                Main h = new Main();
                h.Show();
                h.Outpr += F_Outpr;
                timer1.Enabled = false;
            }    
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
