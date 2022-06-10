using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_10_3
{
    public partial class Update_Form : Form
    {
        My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Update_Form()
        {
            InitializeComponent();
            txtpass.Enabled = false;
            txtpass.Hide();
            label2.Hide();
        }
        int dem = 0;
        string code = "111111";
        private string xao_code()
        {
            string code1 = "";
            Random rnd = new Random();
            for(int i = 0; i <= 6; i++)
            {
                code1 = code1 + rnd.Next(0, 9);
            }
            return code1;
        }

        
        bool check_code()
        {
            if(txb_code.Text == code)
            {
                return true;
            }else
            {
                return false;
            }

        }
        public void send_code(string codesen, string tomail, string frommail, string tieude) 

        {
            try
            {
                dem = 1;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(frommail);
                mail.To.Add(tomail);
                mail.Subject = "Forget password";
                mail.Body = "<h1>" + codesen + "</h1>";
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(frommail, "2444666668888888");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

                MessageBox.Show("please check mail!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //loaddata();
            try
            {
                if (txb_code.Text.Trim() != "")
                {
                    if(check_code() && dem == 1)
                    {
                        dem--;
                        label1.Text = "Please input new pass";
                        txtpass.Show();
                        button2.Hide();
                        txtpass.Enabled = true;
                        txb_code.Hide();
                        button1.Hide();
                        button3.Show();
                    }else
                    {
                        MessageBox.Show("Please try again !!!!!!", "errol");
                    }

                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            

        }
        private void Update_Form_Load(object sender, EventArgs e)
        {
            button3.Hide();
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
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (email.Text != "")
                {
                    if (check_exist(email) == 1)
                    {
                        code = xao_code();
                        send_code(code, email.Text, "soihoang1802@gmail.com", "tieude");
                    }
                    else
                    {
                        MessageBox.Show("no exist email register", "Information");
                    }

                }
                else { MessageBox.Show("check again", "information"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                cmd.Connection = db.GetConnection;
                cmd.CommandText = "update users set password = '" + txtpass.Text + "' where email = '" + email.Text + "' ";
                MessageBox.Show("SUCSS !!!!!!", "OK");
                cmd.ExecuteNonQuery();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
        }
    }
}
