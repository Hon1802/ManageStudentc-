using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace project_10_3.DK
{
    class RT
    {
        My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        public DataTable getdata(SqlCommand command)
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
                System.Windows.MessageBox.Show("check again !!!!", "information");
            }
            return table;
        }

        public bool CheckID(TextBox ID, string str)
        {
            try
            {
                string trv = "SELECT * FROM Dangky WHERE "+str+" = @cid";
                SqlCommand command = new SqlCommand(trv, db.GetConnection);
                command.Parameters.Add("cid", SqlDbType.Int).Value = ID.Text;
                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count >= 1)
                {
                    db.closeConnection();
                    return false;
                }
                else
                {
                    db.closeConnection();
                    return true;
                }
            }
            catch (Exception exp)
            {
                System.Windows.MessageBox.Show("try again !!!", "My goup");
            }
            return true;
        }
        public bool CheckID2(TextBox ID, string str, TextBox ID2, string str2)
        {
            try
            {
                string trv = "SELECT * FROM Dangky WHERE ( " + str + " = @cid and "+str2+" = @id2 )";
                SqlCommand command = new SqlCommand(trv, db.GetConnection);
                command.Parameters.Add("cid", SqlDbType.Int).Value = ID.Text;
                command.Parameters.Add("id2", SqlDbType.Int).Value = ID2.Text;
                db.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count >= 1)
                {
                    db.closeConnection();
                    return false;
                }
                else
                {
                    db.closeConnection();
                    return true;
                }
            }
            catch (Exception exp)
            {
                System.Windows.MessageBox.Show("try again !!!", "My goup");
            }
            return true;
        }

        public bool insert(TextBox stID, TextBox courseid, TextBox userID)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO Dangky (Student_id, HR_id, Course_id)  VALUES (@gid, @name,@uid)", db.GetConnection);
                //cmd1.Parameters.Add("@id", id.Text);
                command.Parameters.Add("@gid",stID.Text);
                command.Parameters.Add("@name", userID.Text );
                command.Parameters.Add("@uid", courseid.Text);

                db.openConnection();
                if ((command.ExecuteNonQuery() == 1))
                {
                    db.closeConnection();
                    return true;
                }
                else
                {
                    db.closeConnection();
                    return false;
                }
            }
            catch (Exception exp)
            {
                return false;
            }

        }

        public bool delete(int id, int id1, int id2)
        {
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM Dangky WHERE (Student_id = @gid and HR_id = @id2 and Course_id = @id3)", db.GetConnection);
                command.Parameters.Add("@gid", SqlDbType.Int).Value = id;
                command.Parameters.Add("@id2", SqlDbType.Int).Value = id1;
                command.Parameters.Add("@id3", SqlDbType.Int).Value = id2;
                db.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    db.closeConnection();
                    return true;
                }
                else
                {
                    db.closeConnection();
                    return false;
                }
            }
            catch (Exception exp)
            {
                
            }
            return false;
        }
    }
}
