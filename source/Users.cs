using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_10_3
{
    class Users
    {
        My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();

        public DataTable GetAllGroups()
        {
            DataTable table = new DataTable();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM MyGroups ", db.GetConnection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
           
            return table;
        }
        public DataTable getScore(SqlCommand command)
        { 
            DataTable table = new DataTable();
            try
            {
                command.Connection = db.GetConnection;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            return table;
        }

        public DataTable loadData()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("select * from mygroup", db.GetConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                db.closeConnection();
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
           
            return dt;
        }
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        public Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }
        byte[] PathToByteA(string path)
        {
            MemoryStream m = new MemoryStream();
            Image img = Image.FromFile(path);
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        PictureBox pictureBox1 = new PictureBox();
        public void load_image(PictureBox pictureBox1)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                //this.Text = open.FileName;
            }
        }
        public int Create_user(int idc, string fname, string lname, TextBox usname, string pwp, bool verif, PictureBox pictu, TextBox email)
        {
            int tam = 0;
            try
            {
                if (verif)
                {
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();
                    SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM UserHR WHERE ( uname = @un or email = @id)", db.GetConnection);
                    check_id.Parameters.AddWithValue("@id", email.Text);
                    check_id.Parameters.AddWithValue("@un", usname.Text);
                    int UserExist = (int)check_id.ExecuteScalar();
                    db.closeConnection();
                    if (UserExist > 0)
                    {
                        //Username exist
                        MessageBox.Show("Had User Added before !!!", "Information");
                    }
                    else
                    {
                        //Username doesn't exist.
                        byte[] pic = ImageToByteArray(pictu.Image);
                        db.openConnection();
                        //cmd.CommandText = "insert into Students values('" + textBox1.Text + "', '" + fname + "','" + lname + "', '" + bdate + "', '" + gender + "','" + phonebox.Text + "','" + address + "','" + pic + "') ";
                        SqlCommand cmd1 = new SqlCommand("insert into UserHR values(@id, @f_name, @l_name, @uname, @pwd, @pig, @email)", db.GetConnection);
                        cmd1.Parameters.Add("@id", idc);
                        cmd1.Parameters.Add("@f_name", fname);
                        cmd1.Parameters.Add("@l_name", lname);
                        cmd1.Parameters.Add("@uname", usname.Text);
                        cmd1.Parameters.Add("@pwd", pwp);
                        cmd1.Parameters.Add("@pig", pic);
                        cmd1.Parameters.Add("@email", email.Text);
                        cmd1.ExecuteNonQuery();
                        tam = 1;
                        MessageBox.Show("New Student Added", " Create User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return tam;
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", " Create User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Had errol !!!", " Create User", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return tam;
        }

        public int Update_Usermy(int idc, string fname, string lname, TextBox usname, string pwp, bool verif, PictureBox pictu, TextBox email)
        {
            int tam = 0;
            try
            {
                if (verif)
                {
                    byte[] pic = ImageToByteArray(pictu.Image);
                    //SqlCommand cmd1 = new SqlCommand();
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();
                    cmd.CommandText = "update UserHR set f_name = '" + fname + "', l_name = '" + lname + "', uname = '" + usname.Text + "',pwd = '" + pwp + "' where id ='" + idc + "'";
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("UPDATE UserHR SET fig = @pic where (id= @id1)", db.GetConnection);
                    cmd1.Parameters.Add("@id1", idc);
                    cmd1.Parameters.Add("@pic", pic);
                    cmd1.ExecuteNonQuery();
                    tam = 1;
                    MessageBox.Show("Update Suss", " Edit SuS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return tam;

                }
                else
                {
                    MessageBox.Show("Empty Fields", " Update Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            return tam ;
        }
        // contact

        public void Add_contact(string fname, string lname, int group, TextBox phone, string email, string addre, TextBox idct , PictureBox pictu, bool verif)
        {
            try
            {
                if (verif)
                {
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();
                    SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM Contacts WHERE (id = @id)", db.GetConnection);
                    check_id.Parameters.AddWithValue("@id", idct.Text);
                    int UserExist = (int)check_id.ExecuteScalar();
                    db.closeConnection();
                    if (UserExist > 0)
                    {
                        //Username exist
                        MessageBox.Show("Had Contact Added before !!!", "Information");
                    }
                    else
                    {
                       
                        //Username doesn't exist.
                        byte[] pic = ImageToByteArray(pictu.Image);
                        db.openConnection();
                        //cmd.CommandText = "insert into Students values('" + textBox1.Text + "', '" + fname + "','" + lname + "', '" + bdate + "', '" + gender + "','" + phonebox.Text + "','" + address + "','" + pic + "') ";
                        SqlCommand cmd1 = new SqlCommand("insert into Contacts values(@id, @fname, @lname, @group_id, @phone, @email, @address, @pic, @userid)", db.GetConnection);
                        cmd1.Parameters.Add("@id", idct.Text);
                        cmd1.Parameters.Add("@fname", fname);
                        cmd1.Parameters.Add("@lname", lname);
                        cmd1.Parameters.Add("@group_id", SqlDbType.Int).Value = group;
                        cmd1.Parameters.Add("@phone", phone.Text);
                        cmd1.Parameters.Add("@email", email);
                        cmd1.Parameters.Add("@address", addre);
                        cmd1.Parameters.Add("@pic", pic);
                        cmd1.Parameters.Add("@userid", -1);
                        cmd1.ExecuteNonQuery();

                        MessageBox.Show("New Contact Added", " Add contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", " Add contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Had errol !!!", " Add contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }




        //group
        public void Add_group(string name, TextBox id, bool verif)
        {
            try
            {
                if (verif)
                {
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();
                    SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM mygroup WHERE (id = @id)", db.GetConnection);
                    check_id.Parameters.AddWithValue("@id", id.Text);
                    int UserExist = (int)check_id.ExecuteScalar();
                    db.closeConnection();
                    if (UserExist > 0)
                    {
                        //Username exist
                        MessageBox.Show("Had Group Added before !!!", "Information");
                    }
                    else
                    {
                        //Username doesn't exist.
                       
                        db.openConnection();
                        //cmd.CommandText = "insert into Students values('" + textBox1.Text + "', '" + fname + "','" + lname + "', '" + bdate + "', '" + gender + "','" + phonebox.Text + "','" + address + "','" + pic + "') ";
                        SqlCommand cmd1 = new SqlCommand("insert into mygroup values(@id, @name, @userid)", db.GetConnection);
                        cmd1.Parameters.Add("@id", id.Text);
                        cmd1.Parameters.Add("@name", name);
                        cmd1.Parameters.Add("@userid", 1);
                        cmd1.ExecuteNonQuery();

                        MessageBox.Show("New Group Added", " Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", " Add Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Had errol !!!", " Add group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void Update_group(int id, string nname, bool verif)
        {
            try
            {
                if (verif)
                {
                    My_DB db = new My_DB();
                    //SqlCommand cmd1 = new SqlCommand();
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();
                    cmd.CommandText = "update mygroup set name = '" + nname + "' where id ="+id;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Suss", " Update Group", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Empty Fields", " Update Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        public void delete_group(int id)
        {
            try
            {
                db.openConnection();
                cmd = db.GetConnection.CreateCommand();
                cmd.CommandText = "delete from mygroup where id='" + id + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Suss", " Remove group", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            

        }


    }
}
