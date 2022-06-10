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
    public partial class Add_Score : Form
    {
        public Add_Score()
        {
            InitializeComponent();
            try
            {
                string str = "select id, first_name, last_name from Students";
                SqlCommand cmd1 = new SqlCommand(str);
                dataGridView1.DataSource = sc.getScore(cmd1);
                dataGridView1.RowTemplate.Height = 80;
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
        }
        My_DB db = new My_DB();
        Student st = new Student();
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
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (score.Text != "")
                {
                    var sourceValue = score.Text;
                    double doubleValue;
                    if (double.TryParse(sourceValue, out doubleValue))
                    {
                        if (doubleValue  > 10.0)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        DataGridView data = new DataGridView();

        private void Add_Score_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ids.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chekc = verif();
            sc.Add_course(ids, selectc.Text, score, descrip, chekc);
        }
        Add_Student_Form ads = new Add_Student_Form();
        private void score_KeyPress(object sender, KeyPressEventArgs e)
        {
            ads.textBox1_KeyPress(sender, e);
        }


        int id2;
        public int get1()
        {
            try
            {
                if (selectc.Text != "")
                {
                    //Remove_Score rm = new Remove_Score();
                    Remove_Score re = new Remove_Score();
                    id2 = sc.checkid(selectc.Text);
                    return id2;
                }return 1; 
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
                return 1;
            }
               
        }
        public void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectc.Text != "")
                {
                    //Remove_Score rm = new Remove_Score();
                    Remove_Score re = new Remove_Score();
                    int id2 = sc.checkid(selectc.Text);

                    string str1 = "select id, Course_id, first_name, last_name, score, description from (Students INNER JOIN Scores ON id = Student_id) where Course_id =" +id2 ;
                
                
                    SqlCommand cmd1 = new SqlCommand(str1);
                    re.dataremove.DataSource = sc.getScore(cmd1);
                    re.dataremove.RowTemplate.Height = 80;
                    re.ShowDialog();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            
        }

        private void selectc_DisplayMemberChanged(object sender, EventArgs e)
        {

        }

        private void selectc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) )
            //{
            //    e.Handled = true;
            //}
        }
        int temp1 = 0;
        
        DataGridView d1 = new DataGridView();
        private int check_exist_bb(ComboBox label)
        {
            try
            {
                string str = "select * from courses where label = '" + label.Text + "'";
                SqlCommand cmd1 = new SqlCommand(str);
                d1.DataSource = sc.getScore(cmd1);
                temp1 = d1.RowCount - 1;
                
            } catch(Exception ex)
            {
                MessageBox.Show("check again!!!", "infor");
            }
            return temp1;
        }
        
        private void selectc_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //string str3 ="label";
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
            
        }
    }
}
