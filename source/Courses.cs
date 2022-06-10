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
    class Courses
    {
        My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        public DataTable getCourse(SqlCommand cmd1)
        {
            DataTable table = new DataTable();
            try
            {
                cmd1.Connection = db.GetConnection;
                SqlDataAdapter adt = new SqlDataAdapter(cmd1);
                adt.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            return table;
        }
        public DataTable getAllCourses()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM courses ", db.GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable loadData()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("select * from courses", db.GetConnection);
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
        public int check_exist(TextBox idc)
        {
            int UserExist = 0;
            try
            {
                My_DB db = new My_DB();
                SqlCommand cmd = new SqlCommand();
                db.openConnection();
                SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM courses WHERE (id = @id)", db.GetConnection);
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
        public void Add_course(TextBox id,  TextBox label, int hours_number, TextBox description, bool verif)
        {
            try
            {
                if (verif)
                {
                    My_DB db = new My_DB();
                    SqlCommand cmd = new SqlCommand();
                    SqlCommand cmd1 = new SqlCommand();
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();
                    cmd1 = db.GetConnection.CreateCommand();
                    SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM courses WHERE (id = @id)", db.GetConnection);
                    check_id.Parameters.AddWithValue("@id", id.Text);
                    int UserExist = (int)check_id.ExecuteScalar();
                    if (UserExist > 0)
                    {
                        //Username exist
                        MessageBox.Show("Had Course Added before !!!", "Information");
                    }
                    else
                    {

                        //Username doesn't exist.
                        cmd1.CommandText = "insert into courses values('" + id.Text + "', '" + label.Text + "','" + hours_number + "', '" + description.Text + "' ) ";
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


        public void Update_st(TextBox id, TextBox label, int hours_number, TextBox description, bool verif)
        {
            try
            {
                if (verif)
                {
                    My_DB db = new My_DB();
                    //SqlCommand cmd1 = new SqlCommand();
                    //Username doesn't exist.
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();
                    cmd.CommandText = "update courses set label = '" + label.Text + "', hours_number = '" + hours_number + "', description = '" + description.Text + "' where id = '" + id.Text + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Suss", " Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Empty Fields", " Update Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
        }

        public void Update_st1(TextBox id, string label, int hours_number, TextBox description, bool verif)
        {
            try
            {
                if (verif)
                {
                    My_DB db = new My_DB();
                    //SqlCommand cmd1 = new SqlCommand();
                    //Username doesn't exist.
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();
                    cmd.CommandText = "update courses set label = '" + label + "', hours_number = '" + hours_number + "', description = '" + description.Text + "' where id = '" + id.Text + "' ";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Suss", " Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Empty Fields", " Update Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
        }
        public void delete_cs(TextBox id)
        {
            try
            {
                db.openConnection();
                cmd = db.GetConnection.CreateCommand();
                cmd.CommandText = "delete from courses where id='" + id.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Suss", " Had Errol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            

        }
        public int ctt()
        {
            int UserExist = 0;
            try
            {
                db.openConnection();
                SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM courses", db.GetConnection);
                UserExist = (int)check_id.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            return UserExist;
        }
    }
}
