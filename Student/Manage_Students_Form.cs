using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project_10_3
{
    public partial class Manage_Students_Form : Form
    {
        public Manage_Students_Form()
        {
            InitializeComponent();
            try
            {
                dataGridView1.DataSource = st.loadData();
                dataGridView1.RowTemplate.Height = 80;
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }
        My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            st.load_image(picture1);
        }
        Student st = new Student();

        private void Manage_Students_Form_Load(object sender, EventArgs e)
        {
            //gender.Enabled = true;
        }
        bool verif()
        {
            if ((fname.Text.Trim() == "") ||
                    (lname.Text.Trim() == "") ||
                    (phone.Text.Trim() == "") ||
                    (bd.Text.Trim() == "") ||
                    (address.Text.Trim() == "") ||
                    (tbid.Text.Trim() == ""))
            {
                MessageBox.Show("Please try again !!!!!!", "error");
                return false;
            }
            else
            {
                return true;
            }
        }
        void cls()
        {
            tbid.Text = "";
            fname.Text = "";
            lname.Text = "";
            bd.Text = "";
            gender.Text = "";
            phone.Text = "";
            address.Text = "";
            tb_search.Text = "";
            picture1.Image = null;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        Update_Delete_Student_Form up = new Update_Delete_Student_Form();
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                fname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                lname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                bd.Text = dataGridView1.CurrentRow.Cells[3].FormattedValue.ToString();
                //bd.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
                gender.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                phone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                address.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                byte[] pic;
                pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
                MemoryStream picture = new MemoryStream();
                picture1.Image = up.ByteArrayToImage(pic);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string f_name = fname.Text;
                string l_name = lname.Text;
                DateTime bdate = bd.Value;
                string adr = address.Text;
                string gr = gender.Text;
            
                bool check1 = verif();
                st.Add_st(f_name, l_name, bdate, adr, gr, phone, check1, tbid, picture1);
                cls();
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = st.loadData();
                dataGridView1.RowTemplate.Height = 80;
                cls();
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string f_name = fname.Text;
                string l_name = lname.Text;
                DateTime bdate = bd.Value;
                string adr = address.Text;
                string gr = gender.Text;
                bool check1 = verif();
                st.Update_st(f_name, l_name, bdate, adr, gr, phone, check1, tbid, picture1);
                cls();
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            st.delete_st(tbid);
        }
        SqlDataAdapter adt = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                db.openConnection();
                cmd = db.GetConnection.CreateCommand();
                cmd.CommandText = "select * from Students where id Like '%" + tb_search.Text + "%' or first_name Like '%" + tb_search.Text + "%' or last_name LiKE '%" + tb_search.Text + "%' or birthday LIKE '%" + tb_search.Text + "%' or gender LIKE '%" + tb_search.Text + "%' or phone Like '%" + tb_search.Text + "%' or address LIKE '%" + tb_search.Text + "%' or id LIKE '%" + tb_search.Text + "%' ";
                adt.SelectCommand = cmd;
                table.Clear();
                adt.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
        }
        Add_Student_Form q = new Add_Student_Form();
        private void tbid_KeyPress(object sender, KeyPressEventArgs e)
        {
            q.Add_Student_Form_KeyPress(sender, e);
        }

        private void fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            q.txtfirstname_KeyPress(sender, e);
        }

        private void lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            q.txtfirstname_KeyPress(sender, e);
        }

        private void gender_KeyPress(object sender, KeyPressEventArgs e)
        {
            q.txtfirstname_KeyPress(sender, e);

        }

        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            q.Add_Student_Form_KeyPress(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DK.Register_St rt = new DK.Register_St();
            rt.ShowDialog();
        }
    }
}
