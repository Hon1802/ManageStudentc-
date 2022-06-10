using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_10_3.DK
{
    public partial class Register_St : Form
    {
        public Register_St()
        {
            InitializeComponent();
            load();
        }
        RT rt = new RT();
        private void load()
        {
            try
            {
                string str1 = "select id, first_name, last_name from Students ";
                SqlCommand cmd1 = new SqlCommand(str1);
                dataGridView1.DataSource = rt.getdata(cmd1);
                dataGridView1.RowTemplate.Height = 80;
                string str2 = "select id, label from courses ";
                SqlCommand cmd2 = new SqlCommand(str2);
                dataGridView2.DataSource = rt.getdata(cmd2);
                dataGridView2.RowTemplate.Height = 80;
                string str3 = "select id, f_name, l_name from UserHR ";
                SqlCommand cmd3 = new SqlCommand(str3);
                dataGridView3.DataSource = rt.getdata(cmd3);
                dataGridView3.RowTemplate.Height = 80;
                string str4 = "select * from Dangky ";
                SqlCommand cmd4 = new SqlCommand(str4);
                dataGridView4.DataSource = rt.getdata(cmd4);
                dataGridView4.RowTemplate.Height = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
        }
        private void Register_St_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }
        bool verif()
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
                return false;
            else
                return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (verif())
                {
                    int num = -1;

                    {
                        string a = "Student_id";
                        string a1 = "HR_id";
                        string a2 = "Course_id";
                        if ((rt.CheckID2(textBox1, a,textBox2, a2) ))
                        {
                            if (rt.insert(textBox1, textBox2,textBox3))
                            {
                                MessageBox.Show("Group Added!", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Register_St_Load(null, null);
                            }
                            else
                            {
                                MessageBox.Show("Can Not Add !", "Add ST", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Student had Exist!", "Add ST", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0003", "Information");
            }
        }
        int biendexoa = -1;
        int biendexoa1 = -1;
        int biendexoa2 = -1;
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            biendexoa = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
            biendexoa1 = Convert.ToInt32(dataGridView4.CurrentRow.Cells[1].Value);
            biendexoa2 = Convert.ToInt32(dataGridView4.CurrentRow.Cells[2].Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if ((MessageBox.Show("Are you sure want to delete this ?", "Delete ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    
                    //int GroupID = (int)cbb_EditGroup.SelectedIndex;
                    if (rt.delete(biendexoa, biendexoa1, biendexoa2))
                    {
                        MessageBox.Show(" Deleted", "Delete ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Register_St_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Can Not Delete !", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x00001", "Information");
            }
        }
    }
}
