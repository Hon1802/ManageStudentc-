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
    public partial class Student_List_Form : Form
    {
        public Student_List_Form()
        {
            InitializeComponent();
            loadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] b = null; 
            this.Refresh();
            loadData();
        }
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        Student st = new Student();
        My_DB db = new My_DB();
        private void Student_List_Form_Load(object sender, EventArgs e)
        {
        }

        void loadData()
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("select * from Students", db.GetConnection);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.RowTemplate.Height = 80;
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
        }
        //fix loi
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if(!((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dataGridView1.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
              
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //pos = dataGridView1.SelectedRows.;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        public int pos;
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Update_Delete_Student_Form h = new Update_Delete_Student_Form();
                //h.ShowDialog();
                h.id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                h.fname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                h.lname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                h.bd.Value = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
                h.gender.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                h.phone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                h.address.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                byte[] pic;
                pic = (byte[])dataGridView1.CurrentRow.Cells[7].Value;
                MemoryStream picture = new MemoryStream();
                h.pictureBox1.Image = h.ByteArrayToImage(pic);
            

                h.ShowDialog();
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}
