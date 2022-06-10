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
    public partial class Statistics_Student : Form
    {
        public Statistics_Student()
        {
            InitializeComponent();
            Loadsta();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Statistics_Student st = new Statistics_Student();
            this.Hide();
            st.ShowDialog();
        }
        Color panttcl;
        Color panmlcl;
        Color panfmlcl;
        My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        private int ctt()
        {
            int UserExist = 0;
            try
            {
                db.openConnection();
                cmd = db.GetConnection.CreateCommand();
                SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM Students", db.GetConnection);
                UserExist = (int)check_id.ExecuteScalar();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
           
            return UserExist;

        }
        private double cml()
        {
            double ex = 0;
            try
            {
                db.openConnection();
                cmd = db.GetConnection.CreateCommand();
                SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM Students where gender = 'Male'", db.GetConnection);
                int UserExist = (int)check_id.ExecuteScalar();
                ex = UserExist * 100 / ctt();
                db.closeConnection();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
            return ex;

        }
        private double cfml()
        {
            double ex = 0;
            try
            {
                db.openConnection();
                cmd = db.GetConnection.CreateCommand();
                SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM Students where gender = 'Female'", db.GetConnection);
                int UserExist = (int)check_id.ExecuteScalar();
                ex = UserExist * 100 / ctt();
                db.closeConnection();
            }
            catch (Exception ex1)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
            return ex;
        }
        private void Static_Student_Load(object sender, EventArgs e)
        {
            try
            {
                panttcl = panel1.BackColor;
                panmlcl = panel2.BackColor;
                panfmlcl = panel3.BackColor;

                labeltt.Text = "Total Students: " + ctt();
                labelml.Text = "Males : " + cml() + " % ";
                labelfml.Text = "Fmales : " + cfml() + " % ";
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
           
        }
        private void Loadsta()
        {
            try
            {
                chart1.Series["s1"].Points.AddXY("Male", cml());
                chart1.Series["s1"].Points.AddXY("Female ", cfml());
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }
        private void labeltt_Click(object sender, EventArgs e)
        {

        }

        private void labeltt_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Black;
            labeltt.ForeColor = panttcl;
        }

        private void labeltt_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = panttcl;
            labeltt.ForeColor = Color.Black;
        }

        private void labelml_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Black;
            labelml.ForeColor = panmlcl;
        }

        private void labelml_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = panmlcl;
            labelml.ForeColor = Color.Black;
        }

        private void labelfml_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Black;
            labelfml.ForeColor = panfmlcl;
        }

        private void labelfml_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = panfmlcl;
            labelfml.ForeColor = Color.Black;
        }
    }
}
