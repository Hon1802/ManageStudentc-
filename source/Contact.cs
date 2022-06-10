using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace project_10_3
{
    class Contact
    {
        #region 1
        My_DB mydb = new My_DB();
        public bool insertContact(int id, string fname, string lname, string phone, string address, string email, int groupid, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Contacts (id, fname, lname, group_id , phone, email, address, pic )" +
                " VALUES (@id, @fn, @ln, @gid, @phn, @mail,@adrs,@pic)", mydb.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

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
        public bool updateContact(int id, string fname, string lname, string phone, string address, string email, int groupid, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE Contacts SET fname = @fn, lname = @ln, phone = @phn, address = @adrs, email= @mail, group_id = @gid, pic = @pic WHERE id = @uid", mydb.GetConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

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
        public bool deleteContact(int ContactID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Contacts WHERE id = @cid", mydb.GetConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = ContactID;
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
        #endregion
        public DataTable SelectContactList()
        {
            DataTable table = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("Select * From Contacts", mydb.GetConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            return table;
        }
        public DataTable GetContactByID(int ContactID)
        {   
            DataTable table = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Contacts WHERE id = @cid ", mydb.GetConnection);
                command.Parameters.Add("@cid", SqlDbType.Int).Value = ContactID;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            return table;
        }
        public bool CheckContactID(int ContactID)
        {
            DataTable table = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Contacts WHERE id = @cid", mydb.GetConnection);
                command.Parameters.Add("cid", SqlDbType.Int).Value = ContactID;
                mydb.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
           
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
        public bool CheckContactIDForEdit(int ContactID)
        {
            DataTable table = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Contacts WHERE id = @cid", mydb.GetConnection);
                command.Parameters.Add("cid", SqlDbType.Int).Value = ContactID;
                mydb.openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            if (table.Rows.Count >= 1)
            {
                if (Convert.ToInt32(table.Rows[0]["id"]) == ContactID)
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

        public DataTable GetContactAndGroup()
        {                
            DataTable table = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("SELECT Contacts.id as ContactID, Contacts.fname as FirstName , Contacts.lname as LastName, mygroup.id as GroupID, mygroup.name as GroupName From Contacts inner join mygroup on Contacts.group_id = mygroup.id order by mygroup.id", mydb.GetConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            return table;
        }
        public DataTable ContactListByUserIDandGroupID(int userID, int GroupID)
        {                
            DataTable table = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("SELECT Contacts.id as ContactID, Contacts.fname as FirstName , Contacts.lname as LastName, mygroup.id as GroupID, mygroup.name as GroupName, UserHR.id as UserID, Contacts.pic FROM Contacts inner join mygroup on Contacts.group_id = mygroup.id inner join UserHR on mygroup.userid = UserHR.id WHERE UserHR.id = @userID AND mygroup.id = @gID order by Contacts.id", mydb.GetConnection);
                command.Parameters.Add("@userID", SqlDbType.Int).Value = userID;
                command.Parameters.Add("@gID", SqlDbType.Int).Value = GroupID;
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
