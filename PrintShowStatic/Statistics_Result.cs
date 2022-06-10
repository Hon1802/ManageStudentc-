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
    public partial class Statistic_Result : Form
    {
        public Statistic_Result()
        {
            InitializeComponent();
            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Hide();
            load();

        }
        My_DB db = new My_DB();
        Score sc = new Score();
        Courses cr = new Courses();
        int temp = 0;
        SqlCommand cmd = new SqlCommand();
        private string insert_co()
        {
            string str2 = "select label from courses";
            string chuoi = "";
            try
            {
                
                SqlCommand cmd = new SqlCommand(str2);
                DataGridView dataload = new DataGridView();
                dataGridView2.DataSource = cr.getCourse(cmd);
                dataload.DataSource = cr.getCourse(cmd);
                temp = dataGridView2.RowCount - 2;
                for (int i = 0; i < temp; i++)
                {
                    chuoi = chuoi + "[" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "], ";
                }
                chuoi += dataGridView2.Rows[temp].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
            //MessageBox.Show(chuoi);
            return chuoi;
        }
        private string insert_co2()
        {
            string str2 = "select label from courses";
            string chuoi = "";
            try
            {
                SqlCommand cmd = new SqlCommand(str2);
                DataGridView dataload = new DataGridView();
                dataGridView1.DataSource = cr.getCourse(cmd);
                dataload.DataSource = cr.getCourse(cmd);
                temp = dataGridView2.RowCount - 2;
                for (int i = 0; i < temp; i++)
                {
                    chuoi = chuoi + "ROUND([" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "],1) as " + dataGridView2.Rows[i].Cells[0].Value.ToString() + ", ";
                }
                chuoi = chuoi + "ROUND([" + dataGridView2.Rows[temp].Cells[0].Value.ToString() + "],1) as " + dataGridView2.Rows[temp].Cells[0].Value.ToString() + "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            //MessageBox.Show(chuoi);
            return chuoi;
        }
        private int cml(int value_id)
        {
            int UserExist = 0;
            try
            {
                db.openConnection();
                cmd = db.GetConnection.CreateCommand();
                if (value_id == -1)
                {
                    SqlCommand check_id = new SqlCommand("select Count(DISTINCT Student_id) from  (Select Student_id, ROUND(AVG(score) , 2) as 'average' From Scores Inner JOIN  courses on Course_id = id Group by Student_id, label) as DT where DT.average >= 5", db.GetConnection);
                    UserExist = (int)check_id.ExecuteScalar();
                    //double ex = UserExist * 100 / ctt();
                    db.closeConnection();
                    
                }
                else
                {
                    SqlCommand check_id = new SqlCommand("select Count(DISTINCT Student_id) from  (Select Course_id, Student_id, ROUND(AVG(score) , 2) as 'average' From Scores Inner JOIN  courses on Course_id = id Group by Course_id,Student_id, label) as DT where DT.average >= 5 and Course_id = " + value_id, db.GetConnection);
                    UserExist = (int)check_id.ExecuteScalar();
                    //double ex = UserExist * 100 / ctt();
                    db.closeConnection();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            return UserExist;
        }
        private int cml2(int value_id)
        {
            int UserExist = 0;
            try
            {
                db.openConnection();
                cmd = db.GetConnection.CreateCommand();
                if (value_id == -1)
                {
                    SqlCommand check_id = new SqlCommand("select Count(DISTINCT Student_id) from  (Select Student_id, ROUND(AVG(score) , 2) as 'average' From Scores Inner JOIN  courses on Course_id = id Group by Student_id, label) as DT where DT.average < 5", db.GetConnection);
                    UserExist = (int)check_id.ExecuteScalar();
                    //double ex = UserExist * 100 / ctt();
                    db.closeConnection();
                    
                }
                else
                {
                    SqlCommand check_id = new SqlCommand("select Count(DISTINCT Student_id) from  (Select Course_id, Student_id, ROUND(AVG(score) , 2) as 'average' From Scores Inner JOIN  courses on Course_id = id Group by Course_id,Student_id, label) as DT where DT.average < 5 and Course_id = " + value_id, db.GetConnection);
                    UserExist = (int)check_id.ExecuteScalar();
                    //double ex = UserExist * 100 / ctt();
                    db.closeConnection();
                    return UserExist;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            return UserExist;

        }
        int value_t = -1;
        private void Static_Result_Load(object sender, EventArgs e)
        {

        }
        private void load()
        {
            try
            {
                
                string str1 = "Select label, ROUND(AVG(score) , 2) as 'average' From Scores Inner JOIN  courses on Course_id = id Group by Course_id, label ";
                SqlCommand cmd1 = new SqlCommand(str1);
                dataGridView1.DataSource = sc.getScore(cmd1);
                int temp2 = dataGridView1.RowCount - 1;
                
                string bien;
                for (int i = 0; i < temp2; i++)
                {
                    bien = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    double t = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    this.chart1.Series["by course"].Points.AddXY(bien, t);
                }



                string str4 = "Select label, Course_id, ROUND(AVG(score) , 2) as 'average' From Scores Inner JOIN  courses on Course_id = id Group by Course_id, label ";
                SqlCommand cmd4 = new SqlCommand(str1);
                dataGridView1.DataSource = sc.getScore(cmd1);
                dataGridView1.RowTemplate.Height = 80;
                temp = dataGridView1.Rows.Count;
                double a1 = 0;
                double a2 = 0;
                double a3 = 0;
                double a4 = 0;
                int end = dataGridView1.Columns.Count;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value) >= 9)
                    {
                        a1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value);
                    }
                    else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value) >= 8)
                    {
                        a2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value);
                    }
                    else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value) >= 5)
                    {
                        a3 += Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value);
                    }
                    else
                    {
                        a4 += Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value);
                    }
                }
                double totalst = a1 + a2 + a3 + a4;
                double PExcellentStudent = Math.Round((a1 / totalst) * 100, 2);
                double PGoodStudent = Math.Round((a2 / totalst) * 100, 2);
                double PAverageStudent = Math.Round((a3 / totalst) * 100, 2);
                double PFailStudent = Math.Round((a4 / totalst) * 100, 2);
                //double POutStudent = Math.Round((OutStudent / totalStudent) * 100, 2);
                labelvg.Text = "Excellent Student: " + PExcellentStudent.ToString() +" %";
                labelg.Text = "Good Student: " + PGoodStudent.ToString() + " %";
                labelp.Text = "Average Student: " + PAverageStudent.ToString() + " %";
                labelf.Text = "Falled Student: "+ PFailStudent.ToString() + " %";
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
