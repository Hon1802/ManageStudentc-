using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace project_10_3
{
    public partial class Avr_Score_By_Course : Form
    {
        public Avr_Score_By_Course()
        {
            InitializeComponent();
            My_DB db = new My_DB();
            Score sc = new Score();
            Courses cr = new Courses();
            
            loa();
        }
        My_DB db = new My_DB();
        Score sc = new Score();
        Courses cr = new Courses();
        int temp = 0;
        DataGridView dt = new DataGridView();
        //My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        private int cml(int value_id)
        {
            int UserExist = 0;
            db.openConnection();
            cmd = db.GetConnection.CreateCommand();
            if (value_id == -1)
            {
                
                try
                {
                    SqlCommand check_id = new SqlCommand("select Count(DISTINCT Student_id) from  (Select Student_id, ROUND(AVG(score) , 2) as 'average' From Scores Inner JOIN  courses on Course_id = id Group by Student_id, label) as DT where DT.average >= 5", db.GetConnection);
                    UserExist = (int)check_id.ExecuteScalar();
                    db.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("check again !!!!", "information");
                }
                
               
            }
            else
            {
                try
                {
                    SqlCommand check_id = new SqlCommand("select Count(DISTINCT Student_id) from  (Select Course_id, Student_id, ROUND(AVG(score) , 2) as 'average' From Scores Inner JOIN  courses on Course_id = id Group by Course_id,Student_id, label) as DT where DT.average >= 5 and Course_id = " + value_id, db.GetConnection);
                    UserExist = (int)check_id.ExecuteScalar();
                    db.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("check again !!!!", "information");
                }
            }
            return UserExist;
        }
        private int cml2(int value_id)
        {
            int UserExist = 0;
            db.openConnection();
            cmd = db.GetConnection.CreateCommand();
            if (value_id == -1)
            {
                try
                {
                    SqlCommand check_id = new SqlCommand("select Count(DISTINCT Student_id) from  (Select Student_id, ROUND(AVG(score) , 2) as 'average' From Scores Inner JOIN  courses on Course_id = id Group by Student_id, label) as DT where DT.average < 5", db.GetConnection);
                    UserExist = (int)check_id.ExecuteScalar();
                    db.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("check again !!!!", "information");
                }
                
                
            }
            else
            {
                try
                {
                    SqlCommand check_id = new SqlCommand("select Count(DISTINCT Student_id) from  (Select Course_id, Student_id, ROUND(AVG(score) , 2) as 'average' From Scores Inner JOIN  courses on Course_id = id Group by Course_id,Student_id, label) as DT where DT.average < 5 and Course_id = " + value_id, db.GetConnection);
                    UserExist = (int)check_id.ExecuteScalar();
                    db.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("check again !!!!", "information");
                }
                
                
            }
            return UserExist;
        }
        int value_t = -1;
        private void loa()
        {
            try
            {
                string str1 = "Select label, Course_id, ROUND(AVG(score) , 2) as 'average' From Scores Inner JOIN  courses on Course_id = id Group by Course_id, label ";
                SqlCommand cmd1 = new SqlCommand(str1);
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
                        //chart1.Series["s1"].Points.AddXY("Very Good", dataGridView1.Rows[i].Cells[end - 1].Value.ToString());
                        a1 += Convert.ToDouble( dataGridView1.Rows[i].Cells[end - 1].Value);
                    }
                    else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value) >= 8)
                    {
                        a2 += Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value);
                        //chart1.Series["s1"].Points.AddXY("Good", dataGridView1.Rows[i].Cells[end - 1].Value.ToString());
                    }
                    else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value) >= 5)
                    {
                        a3 += Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value);
                        //chart1.Series["s1"].Points.AddXY("Pass", dataGridView1.Rows[i].Cells[end - 1].Value.ToString());
                    }   
                    else
                    {
                        a4 += Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 1].Value);
                        //chart1.Series["s1"].Points.AddXY("Failled", dataGridView1.Rows[i].Cells[end - 1].Value.ToString());
                    }
                }
                chart1.Series["s1"].Points.AddXY("Very Good", a1.ToString());
                chart1.Series["s1"].Points.AddXY("Good", a2.ToString());
                chart1.Series["s1"].Points.AddXY("Pass", a3.ToString());
                chart1.Series["s1"].Points.AddXY("Falled", a4.ToString());
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

        private void Avr_Score_By_Course_Load(object sender, EventArgs e)
        {
        }
        DataGridView data1 = new DataGridView();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
           
        }

        //private string insert_co()
        //{

        //    string str2 = "select label from courses";
        //    string chuoi = "";
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(str2);
        //        DataGridView dataload = new DataGridView();
        //        dataGridView2.DataSource = cr.getCourse(cmd);
        //        dataload.DataSource = cr.getCourse(cmd);
        //        temp = dataGridView2.RowCount - 2;
        //        for (int i = 0; i < temp; i++)
        //        {
        //            chuoi = chuoi + "[" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "], ";
        //        }
        //        chuoi += dataGridView2.Rows[temp].Cells[0].Value.ToString();
        //    }
        //    catch (Exception exp)
        //    {
        //        MessageBox.Show("0x0001", "information");
        //    }

        //    //MessageBox.Show(chuoi);
        //    return chuoi;
        //}
        //private string insert_co2()
        //{
        //    string str2 = "select label from courses";
        //    string chuoi = "";
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(str2);
        //        DataGridView dataload = new DataGridView();
        //        dataGridView1.DataSource = cr.getCourse(cmd);
        //        dataload.DataSource = cr.getCourse(cmd);
        //        temp = dataGridView2.RowCount - 2;
        //        for (int i = 0; i < temp; i++)
        //        {
        //            chuoi = chuoi + "ROUND([" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "],1) as " + dataGridView2.Rows[i].Cells[0].Value.ToString() + ", ";
        //        }
        //        chuoi = chuoi + "ROUND([" + dataGridView2.Rows[temp].Cells[0].Value.ToString() + "],1) as " + dataGridView2.Rows[temp].Cells[0].Value.ToString() + "";
        //    }
        //    catch (Exception exp)
        //    {
        //        MessageBox.Show("0x0001", "information");
        //    }

        //    return chuoi;
        //}
        //private void loaddata()
        //{
        //    string str3 = insert_co();
        //    string str1 = "SELECT id, first_name, last_name, " + insert_co2() + " ,ROUND(GOOD.[Average Score],2) as [Average Course] FROM (Select * FROM(select  DTB.[label], DTB.score, first_name, last_name, id from(Select[label],[student_id], course_id, score  From Scores Inner JOIN  courses on course_id = id Group by score, course_id, [label], Student_id) as DTB Inner JOIN Students on DTB.Student_id = id) as OK PIVOT(SUM(score) FOR OK.[label] IN(" + str3 + ")) AS PVTTable) AS MUCH INNER JOIN (Select student_id, AVG(Scores.score) AS [Average Score] FROM Scores Group by student_id) AS GOOD ON student_id = MUCH.id";
        //    try
        //    {
        //        SqlCommand cmd1 = new SqlCommand(str1);
        //        dataGridView1.DataSource = sc.getScore(cmd1);
        //        dataGridView1.RowTemplate.Height = 80;
        //    }
        //    catch (Exception exp)
        //    {
        //        MessageBox.Show("0x0001", "information");
        //    }
        //}
        //private void loaddatare()
        //{

        //    try
        //    {
        //        DataColumn col = new DataColumn((dataGridView1.ColumnCount + 1).ToString());
        //        dataGridView1.Columns.Add("Result", "Result");
        //        //           dataGridView1.Columns.Add("...", "...");
        //        //dataGridView1.Rows[1].Cells[1].Value = 6.5;
        //        //start region
        //        int end = dataGridView1.Columns.Count;
        //        //MessageBox.Show(end.ToString());
        //        for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //        {
        //            if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 2].Value) >= 9)
        //                dataGridView1.Rows[i].Cells[end - 1].Value = "Very Good";
        //            else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 2].Value) >= 8)
        //                dataGridView1.Rows[i].Cells[end - 1].Value = "Good";
        //            else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 2].Value) >= 5)
        //                dataGridView1.Rows[i].Cells[end - 1].Value = "Pass";
        //            else
        //                dataGridView1.Rows[i].Cells[end - 1].Value = "Faller";

        //        }
        //        for (int i = 0; i < dataGridView1.Columns.Count; i++)
        //        {
        //            dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Has errol!!!!", "information");
        //    }
        //}

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
