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
    public partial class Manage_score : Form
    {
        public Manage_score()
        {
            InitializeComponent();
            loa();
        }
        My_DB db = new My_DB();
        Score sc = new Score();
        Courses cr = new Courses();
        bool chekc;
        bool verif()
        {
            if ((ids.Text.Trim() == "") ||
                    (selectc.Text.Trim() == "")
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
        private void loa()
        {
            try
            {
                string str1 = "select DT.id, label, first_name, last_name, score, dt.description from (select id, Course_id, first_name, last_name, score, Scores.description from Students st INNER JOIN Scores ON st.id = Scores.Student_id) as DT INNER JOIN courses on DT.Course_id = courses.id ";
                SqlCommand cmd1 = new SqlCommand(str1);
                dataGridView1.DataSource = sc.getScore(cmd1);
                dataGridView1.RowTemplate.Height = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
        }
        private void Manage_score_Load(object sender, EventArgs e)
        {
            try
            {
                selectc.DataSource = cr.loadData();
                selectc.DisplayMember = "label";
                selectc.ValueMember = "id";
                selectc.SelectedItem = null;
                ids.Text = "";
                selectc.Text = "";
                score.Text = "";
                descrip.Text = "";
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }
        int idt = -1;
        int temp2 = -1;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idt = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                ids.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                selectc.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                score.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                descrip.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            //selectc 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chekc = verif();
            int tem = sc.checkid(selectc.Text);
            sc.Add_course(ids, selectc.Text, score, descrip, chekc);
            loa();
   
        }

        private void score_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (score.Text != "")
                {
                    var sourceValue = score.Text;
                    double doubleValue;
                    if (double.TryParse(sourceValue, out doubleValue))
                    {
                        if (doubleValue > 10.0)
                        {
                            score.Text = "";
                        }
                        else if (doubleValue < 8.0 && doubleValue >= 5.0)
                        {
                            descrip.Text = "Pass ";
                        }
                        else if (doubleValue >= 8.0)
                        {
                            descrip.Text = "Good";
                        }
                        else
                        {
                            descrip.Text = "see you again ";
                        }
                    }
                    else
                    {
                        score.Text = "";
                        // Here you can display an error message like 'Invalid value'
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void selectc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void selectc_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (selectc.Text == "")
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    selectc.BackColor = Color.White;
                }
                else if (sc.check_exist_label(selectc) == 0)
                {
                    //selectc.Text = sc.check_exist_label(selectc).ToString();
                    button1.Enabled = false;
                    button2.Enabled = false;
                    selectc.BackColor = Color.Red;

                }

                else
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    selectc.BackColor = Color.White;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            //string str3 ="label";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                chekc = verif();
                int temp2 = sc.checkid(selectc.Text);
                if (idt != -1)
                {
                    sc.delete_sc2(idt, temp2);
                }
                loa();
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ids.Text != "")
                {
                    string str1 = "select DT.id, label, first_name, last_name, score, dt.description from (select id, Course_id, first_name, last_name, score, Scores.description from Students st INNER JOIN Scores ON st.id = Scores.Student_id) as DT INNER JOIN courses on DT.Course_id = courses.id where DT.id = " + ids.Text;
                    SqlCommand cmd1 = new SqlCommand(str1);
                    dataGridView1.DataSource = sc.getScore(cmd1);
                    dataGridView1.RowTemplate.Height = 80;
                }
                else loa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectc.Text != "")
                {
                    string str1 = "select DT.id, label, first_name, last_name, score, dt.description from (select id, Course_id, first_name, last_name, score, Scores.description from Students st INNER JOIN Scores ON st.id = Scores.Student_id) as DT INNER JOIN courses on DT.Course_id = courses.id where label = '" + selectc.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(str1);
                    dataGridView1.DataSource = sc.getScore(cmd1);
                    dataGridView1.RowTemplate.Height = 80;
                }
                else loa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loa();
        }

        private void ids_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (ids.Text == "")
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    ids.BackColor = Color.White;
                }
                else if (sc.check_exist_st(ids) == 0)
                {
                    //selectc.Text = sc.check_exist_label(selectc).ToString();
                    button1.Enabled = false;
                    button2.Enabled = false;
                    ids.BackColor = Color.Red;

                }

                else
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    ids.BackColor = Color.White;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void ids_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AVG_Result_By_Score avr = new AVG_Result_By_Score();
            avr.ShowDialog();
        }
    }
}
