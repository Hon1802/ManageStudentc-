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
    public partial class Add_Student_Form : Form
    {
        public Add_Student_Form()
        {
            InitializeComponent();
        }

        bool verif()
        {
            if ((txtfirstname.Text.Trim() == "") ||
                    (txtlastname.Text.Trim() == "") ||
                    (phonebox.Text.Trim() == "") ||
                    (addressbox.Text.Trim() == "") ||
                    (labelid.Text.Trim() == ""))
            {
                MessageBox.Show("Please try again !!!!!!", "error");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Add_Student_Form_Load(object sender, EventArgs e)
        {

        }
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        private void buttonadd_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //add new student
            string fname = txtfirstname.Text;
            string lname = txtlastname.Text;
            DateTime bdate = birthday.Value;
            string address = addressbox.Text;
            string gender = "Male";


            if (female.Checked)
            {
                gender = "Female";
            }

            int born_year = birthday.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The Student Age Must Be Between 10 and 100", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                try
                {
                    My_DB db = new My_DB();
                    SqlCommand cmd = new SqlCommand();
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();

                    SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM Students WHERE (id = @id)", db.GetConnection);
                    check_id.Parameters.AddWithValue("@id", textBox1.Text);
                    int UserExist = (int)check_id.ExecuteScalar();
                    db.closeConnection();
                    if (UserExist > 0)
                    {
                        //Username exist
                        MessageBox.Show("Had Student Added before !!!", "Information");
                    }
                    else
                    {
                        //Username doesn't exist.
                        byte[] pic = ImageToByteArray(pictureBox1.Image);
                        db.openConnection();
                        //cmd.CommandText = "insert into Students values('" + textBox1.Text + "', '" + fname + "','" + lname + "', '" + bdate + "', '" + gender + "','" + phonebox.Text + "','" + address + "','" + pic + "') ";
                        SqlCommand cmd1 = new SqlCommand("insert into Students values(@id, @first_name, @last_name, @birthday, @gender, @phone, @address, @picture)", db.GetConnection);
                        cmd1.Parameters.Add("@id", textBox1.Text);
                        cmd1.Parameters.Add("@first_name", fname);
                        cmd1.Parameters.Add("@last_name", lname);
                        cmd1.Parameters.Add("@birthday", bdate);
                        cmd1.Parameters.Add("@gender", gender);
                        cmd1.Parameters.Add("@phone", phonebox.Text);
                        cmd1.Parameters.Add("@address", address);
                        cmd1.Parameters.Add("@picture", pic);
                        cmd1.ExecuteNonQuery();

                        MessageBox.Show("New Student Added", " Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("check again!!!", "infor");
                }
                
            }
            else
            {
                MessageBox.Show("Empty Fields", " Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public void Add_Student_Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!char.IsDigit(ch) && ch!=8 && ch!=46)
            {
                e.Handled = true;
            }    
        }

        public void txtfirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private int check_exist(TextBox idc)
        {
            int UserExist = 0;
            try
            {
                My_DB db = new My_DB();
                SqlCommand cmd = new SqlCommand();
                db.openConnection();
                SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM Students WHERE (id = @id)", db.GetConnection);
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
            private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.White;
            }
            else if (check_exist(textBox1) == 1)
            {
                textBox1.BackColor = Color.Red;
                label7.Text = "!!!";
            }
            else
            {
                textBox1.BackColor = Color.White;
                label7.Text = "OK";
            }
        }
    }
}
