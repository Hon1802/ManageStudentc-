using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace project_10_3
{
    class Group
    {
        My_DB mydb = new My_DB();
        public bool insertGroup(int GroupID, string GroupName, int userID)
        {
            try
            {
                SqlCommand command = new SqlCommand("INSERT INTO mygroup (id, name, userid)  VALUES (@gid, @name,@uid)", mydb.GetConnection);
                command.Parameters.Add("@gid", SqlDbType.Int).Value = GroupID;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = GroupName;
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userID;

                mydb.openConnection();
                if ((command.ExecuteNonQuery() == 1))
                {
                    mydb.closeConnection();
                    return true;
                }
                else
                {
                    mydb.closeConnection();
                    return false;
                }
            }
            catch (Exception exp)
            {
                return false;
                MessageBox.Show("0x0001", "information");
            }
            
        }
        public bool updateGroupName(int GroupID, string GroupName)
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE mygroup SET name=@name WHERE id=@gid", mydb.GetConnection);
                command.Parameters.Add("@gid", SqlDbType.Int).Value = GroupID;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = GroupName;

                mydb.openConnection();
                if ((command.ExecuteNonQuery() == 1))
                {
                    mydb.closeConnection();
                    return true;
                }
                else
                {
                    mydb.closeConnection();
                    return false;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("try again !!!", "My goup");
            }
            return false;
        }
        public bool deleteGroup(int GroupID)
        {
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM mygroup WHERE id = @gid", mydb.GetConnection);
                command.Parameters.Add("@gid", SqlDbType.Int).Value = GroupID;
                mydb.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    mydb.closeConnection();
                    return true;
                }
                else
                {
                    mydb.closeConnection();
                    return false;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("try again !!!", "My goup");
            }
            return false;
        }
        public bool CheckGroupID(int GroupID)
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM mygroup WHERE id = @cid", mydb.GetConnection);
                command.Parameters.Add("cid", SqlDbType.Int).Value = GroupID;
                mydb.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count >= 1)
                {
                    mydb.closeConnection();
                    return false;
                }
                else
                {
                    mydb.closeConnection();
                    return true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("try again !!!", "My goup");
            }
            return true;
        }
        public bool CheckGroupName(string GroupName)
        {
            try
            {
                //Id <> @cID để phân biệt sự tồn tại của khóa học trong database và 1 khóa có khả năng trùng
                SqlCommand command = new SqlCommand("SELECT * FROM mygroup WHERE name =@gName ", mydb.GetConnection);
                command.Parameters.Add("@gName", SqlDbType.VarChar).Value = GroupName;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if ((table.Rows.Count > 0))
                {
                    //phát hiện có 1 DÒNG tồn tại trùng tên
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("try again !!!", "My goup");
            }
            return true;
        }
        public bool CheckGroupIDForEdit(int GroupID)
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM mygroup WHERE id = @cid", mydb.GetConnection);
                command.Parameters.Add("cid", SqlDbType.Int).Value = GroupID;
                mydb.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count >= 1)
                {
                    if (Convert.ToInt32(table.Rows[0]["id"]) == GroupID)
                    {
                        mydb.closeConnection();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    mydb.closeConnection();
                    return true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("try again !!!", "My goup");
            }
            return true;
        }
        public DataTable GetAllGroups()
        {
            DataTable table = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM mygroup ", mydb.GetConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            } catch (Exception exp )
            {
                MessageBox.Show("try again !!!", "My goup");
            }
            
            return table;
        }
        public DataTable GetUserGroups(int UserID)
        {
            DataTable table = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM mygroup WHERE userid = @uid ", mydb.GetConnection);
                command.Parameters.Add("@uid", SqlDbType.Int).Value = UserID;
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            return table;
        }
        //Lấy List Contact dựa theo user ID
        public DataTable ContactListByUserID(int userID)
        {
            DataTable table = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("SELECT Contacts.id as ContactID, Contacts.fname as FirstName , Contacts.lname as LastName, mygroup.id as GroupID, mygroup.name as GroupName, UserHR.id as UserID, Contacts.pic FROM Contacts inner join mygroup on Contacts.group_id = mygroup.id inner join UserHR on mygroup.userid = UserHR.id WHERE UserHR.id = @userID order by Contacts.id", mydb.GetConnection);
                command.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
            
                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            return table;
        }
    }
}
