using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace project_10_3
{
    class Student
    {
        My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        public DataTable getStudents(SqlCommand cmd1)
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

        DataGridView dataGridView1 = new DataGridView();
        public DataTable getStudents1(SqlCommand command)
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
        public DataTable loadData()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("select * from Students", db.GetConnection);
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

        public void Add_st(string fname, string lname, DateTime bdate, string address, string gender, TextBox phonen, bool verif, TextBox id, PictureBox pictu)
        {
            try
            {
                int born_year = bdate.Year;
                int this_year = DateTime.Now.Year;
                if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
                {
                    MessageBox.Show("The Student Age Must Be Between 10 and 100", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif)
                {
                    My_DB db = new My_DB();
                    SqlCommand cmd = new SqlCommand();
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();
                    SqlCommand check_id = new SqlCommand("SELECT COUNT(*) FROM Students WHERE (id = @id)", db.GetConnection);
                    check_id.Parameters.AddWithValue("@id", id.Text);
                    int UserExist = (int)check_id.ExecuteScalar();
                    db.closeConnection();
                    if (UserExist > 0)
                    {
                        //Username exist
                        MessageBox.Show("Had Student Added before !!!", "Information");
                    }
                    else
                    {
                        //Username doesn't exist.
                        byte[] pic = ImageToByteArray(pictu.Image);
                        db.openConnection();
                        //cmd.CommandText = "insert into Students values('" + textBox1.Text + "', '" + fname + "','" + lname + "', '" + bdate + "', '" + gender + "','" + phonebox.Text + "','" + address + "','" + pic + "') ";
                        SqlCommand cmd1 = new SqlCommand("insert into Students values(@id, @first_name, @last_name, @birthday, @gender, @phone, @address, @picture)", db.GetConnection);
                        cmd1.Parameters.Add("@id", id.Text);
                        cmd1.Parameters.Add("@first_name", fname);
                        cmd1.Parameters.Add("@last_name", lname);
                        cmd1.Parameters.Add("@birthday", bdate);
                        cmd1.Parameters.Add("@gender", gender);
                        cmd1.Parameters.Add("@phone", phonen.Text);
                        cmd1.Parameters.Add("@address", address);
                        cmd1.Parameters.Add("@picture", pic);
                        cmd1.ExecuteNonQuery();

                        MessageBox.Show("New Student Added", " Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        public void Update_st(string f_name, string l_name, DateTime bdate, string adr, string gr, TextBox phonen,bool verif, TextBox id, PictureBox pictu)
        {
            try
            {
                int born_year = bdate.Year;
                int this_year = DateTime.Now.Year;
                if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
                {
                    MessageBox.Show("The Student Age Must Be Between 10 and 100", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif)
                {
                    My_DB db = new My_DB();
                    //SqlCommand cmd1 = new SqlCommand();
                    //Username doesn't exist.
                    byte[] pic = ImageToByteArray(pictu.Image);
                    db.openConnection();
                    cmd = db.GetConnection.CreateCommand();
                    cmd.CommandText = "update Students set first_name = '" + f_name + "', last_name = '" + l_name + "', birthday = '" + bdate + "', gender = '" + gr + "', phone = '" + phonen.Text + "',address ='" + adr + "' where id = '" + id.Text + "' ";
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("UPDATE Students SET picture = @pic where (id= @id1)", db.GetConnection);
                    cmd1.Parameters.Add("@id1", id.Text);
                    cmd1.Parameters.Add("@pic", pic);
                    MessageBox.Show("SUCSS !!!!!!", "OK");
                    cmd1.ExecuteNonQuery();
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

        public void delete_st(TextBox id)
        {
            try
            {
                db.openConnection();
                cmd = db.GetConnection.CreateCommand();
                cmd.CommandText = "delete from Students where id='" + id.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Suss", " Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
            
        }
        
        //}

    }
}
