using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class Update_Delete_Student_Form : Form
    {
        public Update_Delete_Student_Form()
        {
            InitializeComponent();
        }
        My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        bool verif()
        {
            if ((fname.Text.Trim() == "") ||
                    (lname.Text.Trim() == "") ||
                    (phone.Text.Trim() == "") ||
                    (address.Text.Trim() == "") ||
                    (id.Text.Trim() == ""))
            {
                MessageBox.Show("Please try again !!!!!!", "error");
                return false;
            }
            else
            {
                return true;
            }
        }
        int pos;

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
        private void btcan_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                cmd = db.GetConnection.CreateCommand();
                cmd.CommandText = "delete from Students where id='" + id.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete Suss", " Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                id.Text = "";
                fname.Text = "";
                lname.Text = "";
                bd.Text = "";
                gender.Text = "";
                phone.Text = "";
                address.Text = "";
                pictureBox1.Image = null;
                this.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
           
        }
        Student_List_Form st = new Student_List_Form();
        private void btadd_Click(object sender, EventArgs e)
        {
            try
            {
                string f_name = fname.Text;
                string l_name = lname.Text;
                DateTime bdate = bd.Value;
                string adr = address.Text;
                string gr = gender.Text;
                string phonen = lname.Text;

                int born_year = bd.Value.Year;
                int this_year = DateTime.Now.Year;
                if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
                {
                    MessageBox.Show("The Student Age Must Be Between 10 and 100", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (verif())
                {
                    My_DB db = new My_DB();
                    //SqlCommand cmd1 = new SqlCommand();

                    //Username doesn't exist.
                    byte[] pic = ImageToByteArray(pictureBox1.Image);
                    db.openConnection();

                    cmd = db.GetConnection.CreateCommand();
                    cmd.CommandText = "update Students set first_name = '" + fname.Text + "', last_name = '" + lname.Text + "', birthday = '" + bdate + "', gender = '" + gender.Text + "', phone = '" + phone.Text + "',address ='" + address.Text + "' where id = '" + id.Text + "' ";

                    cmd.ExecuteNonQuery();



                    SqlCommand cmd1 = new SqlCommand("UPDATE Students SET picture = @pic where (id= @id1)", db.GetConnection);
                    cmd1.Parameters.Add("@id1", id.Text);
                    cmd1.Parameters.Add("@pic", pic);
                    MessageBox.Show("SUCSS !!!!!!", "OK");
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Update Suss", " Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    id.Text = "";
                    fname.Text = "";
                    lname.Text = "";
                    bd.Text = "";
                    gender.Text = "";
                    phone.Text = "";
                    address.Text = "";
                    pictureBox1.Image = null;
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

        private void Update_Delete_Student_Form_Load(object sender, EventArgs e)
        {

        }

        private void gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = db.GetConnection.CreateCommand();
                db.openConnection();
                SqlCommand ncmd = new SqlCommand("SELECT * FROM Students WHERE (id = @id)", db.GetConnection);
                ncmd.Parameters.AddWithValue("@id", id.Text);
                SqlDataReader mdr = ncmd.ExecuteReader();
                if (mdr.Read())
                {
                    fname.Text = mdr.GetInt32(0).ToString();
                    fname.Text = mdr.GetString(1).ToString();
                    lname.Text = mdr.GetString(2).ToString();
                    bd.Text = mdr.GetDateTime(3).ToString();
                    gender.Text = mdr.GetString(4).ToString();
                    address.Text = mdr.GetString(6).ToString();
                    phone.Text = mdr.GetInt32(5).ToString();
                    byte[] b = (byte[])mdr.GetValue(7);
                    pictureBox1.Image = ByteArrayToImage(b);
                }
                else
                {
                    MessageBox.Show("Empty Fields", " Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                mdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
           
        }

        public void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }


       
        private void ShowData(int index)
        {
            try
            {
                Student_List_Form f = new Student_List_Form();
                id.Text = f.dataGridView1.Rows[index].Cells[0].Value.ToString();
                fname.Text = f.dataGridView1.Rows[index].Cells[1].Value.ToString();
                lname.Text = f.dataGridView1.Rows[index].Cells[2].Value.ToString();
                bd.Value = (DateTime)f.dataGridView1.Rows[index].Cells[3].Value;
                gender.Text = f.dataGridView1.Rows[index].Cells[4].Value.ToString();
                phone.Text = f.dataGridView1.Rows[index].Cells[5].Value.ToString();
                address.Text = f.dataGridView1.Rows[index].Cells[6].Value.ToString();
                byte[] pic;
                pic = (byte[])f.dataGridView1.Rows[index].Cells[7].Value;
                MemoryStream picture = new MemoryStream();
                pictureBox1.Image = ByteArrayToImage(pic);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pos = 0;
            ShowData(pos);

        }
        public DataTable getCourses()
        {
            DataTable table = new DataTable();
            try
            {
                cmd = db.GetConnection.CreateCommand();
                SqlCommand check_id = new SqlCommand("SELECT * FROM Students ", db.GetConnection);
                SqlDataAdapter adt = new SqlDataAdapter(check_id);
                adt.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
           
            return table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                pos = getCourses().Rows.Count - 1;
                ShowData(pos);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (pos > 0)
                {
                    pos = pos - 1;
                    ShowData(pos);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if ((getCourses().Rows.Count - 1) > pos)
                {
                    pos = pos + 1;
                    ShowData(pos);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void Update_Delete_Student_Form_Click(object sender, EventArgs e)
        {
            try
            {
                if (id.Text != "")
                {
                    pos = int.Parse(id.Text);
                }   
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
             
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        Add_Student_Form q = new Add_Student_Form();
        private void fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            q.txtfirstname_KeyPress(sender, e);
        }

        private void lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            q.txtfirstname_KeyPress(sender, e);
        }

        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                AVG_Result_By_Score avg = new AVG_Result_By_Score();
            
                avg.txtsearch.Text = id.Text;
                avg.dataGridView1.Columns.Add("Result", "Result");
                avg.button3_Click(sender, e);
                avg.txtsearch.Hide();
                avg.bsearch.Hide();
                //this.Hide();
                avg.ShowDialog();
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            

        }

    }
}
