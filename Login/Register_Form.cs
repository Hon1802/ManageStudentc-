using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_10_3
{
    public partial class Register_Form : Form
    {
        public Register_Form()
        {
            InitializeComponent();
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        My_DB db = new My_DB();

        bool verif()
        {
            if (
                    (textBox2.Text.Trim() == "")||
                    (textBox3.Text.Trim() == "")
                    )
            {
                MessageBox.Show("Please try again !!!!!!", "error");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        public int check_exist(TextBox idc)
        {
            int UserExist = 0;
            try
            {
                My_DB db = new My_DB();
                SqlCommand cmd = new SqlCommand();
                db.openConnection();
                SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM users WHERE (email = @id)", db.GetConnection);
                check_id.Parameters.AddWithValue("@id", idc.Text);
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
        private void buttonadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (verif())
                {

                    My_DB db = new My_DB();
                    SqlCommand cmd = new SqlCommand();
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();
                    SqlCommand check_id2 = new SqlCommand("SELECT COUNT(*) FROM users WHERE (username = @ur) or (email =@em)", db.GetConnection);
                    check_id2.Parameters.AddWithValue("@ur", textBox3.Text);
                    check_id2.Parameters.AddWithValue("@em", textBox1.Text);
                    int UserExist = (int)check_id2.ExecuteScalar();
                    db.closeConnection();
                    if (UserExist > 0)
                    {
                        //Username exist
                        MessageBox.Show(" Account had been before !!!", "Information");
                    }
                    else
                    {
                        db.openConnection();
                        cmd.CommandText = "insert into users values('" + textBox3.Text + "', '" + textBox2.Text + "', '" + textBox1.Text + "') ";
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("New Created", " Add Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }

                else
                {
                    MessageBox.Show("Empty Fields", " Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
        }

        private void Register_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
