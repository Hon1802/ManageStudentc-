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
    public partial class Remove_Score : Form
    {
        public Remove_Score()
        {
            InitializeComponent();
            try
            {
                dataremove.Rows.Clear();
                string str1 = "select id, Course_id, first_name, last_name, score, description from (Students INNER JOIN Scores ON id = Student_id) ";
                SqlCommand cmd1 = new SqlCommand(str1);
                dataremove.DataSource = sc.getScore(cmd1);
                dataremove.RowTemplate.Height = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
           
        }
        My_DB db = new My_DB();
        Score sc = new Score();
        private void Remove_Score_Load(object sender, EventArgs e)
        {
            
        }
        int idt = -1;
        int temp = -1;
        private void dataremove_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idt = Convert.ToInt32(dataremove.CurrentRow.Cells[0].Value.ToString());
                temp = Convert.ToInt32(dataremove.CurrentRow.Cells[1].Value.ToString());
                button1.Text = "Remove id " + idt;
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }
        Add_Score a1s = new Add_Score();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (idt != -1)
                {
                    sc.delete_sc2(idt, temp);
                    string str1 = "select DT.id, label, first_name, last_name, score, dt.description from (select id, Course_id, first_name, last_name, score, Scores.description from Students st INNER JOIN Scores ON st.id = Scores.Student_id) as DT INNER JOIN courses on DT.Course_id = courses.id";
                    SqlCommand cmd1 = new SqlCommand(str1);
                    dataremove.DataSource = sc.getScore(cmd1);
                    dataremove.RowTemplate.Height = 80;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if(value.Text != "")
            {
                if (id_stu.Checked)
                {
                    try
                    {
                        string str1 = "select id, Course_id, first_name, last_name, score, description from (Students INNER JOIN Scores ON id = Student_id)  where id =" + value.Text;
                        SqlCommand cmd1 = new SqlCommand(str1);
                        dataremove.DataSource = sc.getScore(cmd1);
                        dataremove.RowTemplate.Height = 80;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("check again !!!!", "information");
                    }
                    
                }
                else if (radioButton2.Checked)
                {
                    try
                    {
                        string str1 = "select id, Course_id, first_name, last_name, score, description from (Students INNER JOIN Scores ON id = Student_id)  where Course_id =" + value.Text;
                        SqlCommand cmd1 = new SqlCommand(str1);
                        dataremove.DataSource = sc.getScore(cmd1);
                        dataremove.RowTemplate.Height = 80;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("check again !!!!", "information");
                    }
                    
                }
            }
            
        }
    }
}
