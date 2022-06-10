using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_10_3
{
    class Score
    {
        My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        public DataTable getScore(SqlCommand command)
        {
            DataTable table = new DataTable();
            try
            {
                command.Connection = db.GetConnection;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                
                adapter.Fill(table);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            return table;
        }
        public DataTable getStudentScore()
        {
            SqlCommand command = new SqlCommand();
            command.Connection = db.GetConnection;
            command.CommandText = "SELECT Scores.Student_id, Students.first_name, Students.last_name, Scores.Course_id, courses.label, round(Scores.score,3) as student_score " +
                                  "FROM Students INNER JOIN Scores on Students.id = Scores.Student_id INNER JOIN courses on Scores.Course_id = courses.id order by courses.label";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;

        }
        Courses course = new Courses();
        public DataTable getAllCourseScoreAndResult()
        {
            SqlCommand command = new SqlCommand("SELECT id , first_name , last_name  FROM Students", db.GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            DataTable tableCourse = new DataTable();
            tableCourse = course.getAllCourses();

            //lấy khóa học theo chiều ngang
            for (int i = 0; i < tableCourse.Rows.Count; i++)
            {
                DataColumn CourseNamecolumn = new DataColumn();
                CourseNamecolumn.ColumnName = tableCourse.Rows[i]["label"].ToString();
                table.Columns.Add(CourseNamecolumn);
            }
            //lấy điểm của từng khóa học dựa theo id của học sinh
            DataTable tableScore = new DataTable();
            tableScore = this.getStudentScore();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int c = 0; c < tableScore.Rows.Count; c++)
                {
                    if (table.Rows[i]["id"].ToString() == tableScore.Rows[c]["Student_id"].ToString())
                    {
                        for (int k = 3; k < table.Columns.Count; k++)
                        {
                            if (table.Columns[k].ColumnName == tableScore.Rows[c]["label"].ToString())
                            {
                                table.Rows[i][k] = tableScore.Rows[c]["score"].ToString();
                                break;
                            }
                        }
                    }
                }
            }

            table.Columns.Add("AVG_Score", typeof(float));
            table.Columns.Add("Result", typeof(string));
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int count = 0;
                float sum = 0;
                for (int j = 3; j < table.Columns.Count - 2; j++)
                {
                    float temp;
                    string coursename = table.Columns[j].ColumnName;
                    if (float.TryParse(table.Rows[i][coursename].ToString(), out temp))
                    {
                        sum += temp;
                        count++;
                    }
                }

                float avg = sum / count;
                Math.Round(avg, 2);
                table.Rows[i]["AVG_Score"] = Math.Round(avg, 2);

                if (avg < 5) table.Rows[i]["Result"] = "Fail";
                if (avg >= 5 && avg <= 6.5) table.Rows[i]["Result"] = "Average";
                if (avg > 6.5 && avg <= 7.9) table.Rows[i]["Result"] = "Good";
                if (avg >= 8) table.Rows[i]["Result"] = "Excellent";
                if (count == 0) table.Rows[i]["Result"] = "Drop Out Of University!";
                if (avg.ToString() == "NaN") table.Rows[i]["AVG_Score"] = 0;
            }

            return table;
        }
        public DataTable loadData()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("select * from Scores", db.GetConnection);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
            return dt;
        }
        int idr;
        public int checkid(string cm)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("select id from courses where (label = @label)", db.GetConnection);
                cmd.Parameters.AddWithValue("@label", cm);
                idr = (int)cmd.ExecuteScalar();
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
            return idr;
        }

        public bool check_exist(TextBox idc, int id2)
        {
            int UserExist = 0;
            try
            {
                My_DB db = new My_DB();
                SqlCommand cmd = new SqlCommand();
                db.openConnection();
                SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM Scores WHERE (Student_id = @Student_id and Course_id = @Course_id)", db.GetConnection);
                check_id.Parameters.AddWithValue("@Student_id", idc.Text);
                check_id.Parameters.AddWithValue("@Course_id", id2);
                UserExist = (int)check_id.ExecuteScalar();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            if (UserExist > 0)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public void Add_course(TextBox id, string label, TextBox score, TextBox description, bool verif)
        {
            try
            {
                if (verif)
                {
                    My_DB db = new My_DB();
                    SqlCommand cmd1 = new SqlCommand();
                    db.openConnection();
                    cmd1 = db.GetConnection.CreateCommand();
                    int id2 = checkid(label);
                    if (check_exist(id, id2))
                    {
                        //Username exist
                        MessageBox.Show("Had Course Added before !!!", "Information");
                    }
                    else
                    {

                        //Username doesn't exist.
                        cmd1.CommandText = "insert into Scores values('" + id.Text + "', '" + id2 + "','" + score.Text + "', '" + description.Text + "' ) ";
                        cmd1.ExecuteNonQuery();

                        MessageBox.Show("New Course Added", " Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        
        public void delete_sc2(int id, int id2)
        {
            try
            {
                My_DB db = new My_DB();
                SqlCommand cmd1 = new SqlCommand();
                cmd = db.GetConnection.CreateCommand();
                db.openConnection();
                cmd.CommandText = "delete from Scores where Student_id =" + id + " and Course_id =" + id2;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Suss", " Had Errol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            

        }
        public int check_exist_label(ComboBox idc)
        {
            int UserExist = 0;
            try
            {
                My_DB db = new My_DB();
                SqlCommand cmd = new SqlCommand();
                db.openConnection();
                SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM courses WHERE (label = @id)", db.GetConnection);
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
        public int check_exist_st(TextBox idc)
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

    }
}
