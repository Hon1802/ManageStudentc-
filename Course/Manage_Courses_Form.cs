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

namespace project_10_3
{
    public partial class Manage_Courses_Form : Form
    {
        public Manage_Courses_Form()
        {
            InitializeComponent();
        }
        My_DB db = new My_DB();
        Courses sr = new Courses();
        SqlConnection con;
        SqlCommand cmd;
        bool check = true;
        int index;
        int pos;
        private void load()
        {
            try
            {
                listBox.DataSource = sr.loadData();
                listBox.ValueMember = "id";
                listBox.DisplayMember = "label";
                label5.Text = "Total Courses: " + sr.ctt();
                idc.Text = "";
                noh.Text = "";
                desbox.Text = "";
                label.Text = "";
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
        }
        private void check_noh()
        {
            try
            {
                int noh1 = Convert.ToInt32(noh.Text.ToString());
                if (noh1 < 10)
                {
                    button4.Enabled = false;
                    button1.Enabled = false;
                    MessageBox.Show("Number Of Hours must be more 10 , try again !!!!!!", "error");
                }
                else
                {
                    button4.Enabled = true;
                    button1.Enabled = true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }
        private void Manage_Courses_Form_Load(object sender, EventArgs e)
        {
            load();

        }
        bool verif()
        {
            if ((idc.Text.Trim() == "") ||
                    (noh.Text.Trim() == "") ||
                    (label.Text.Trim() == "") ||
                    (desbox.Text.Trim() == ""))
            {
                MessageBox.Show("Please try again !!!!!!", "error");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            check = verif();
            int noh1 = Convert.ToInt32(noh.Text.ToString());
            sr.Add_course(idc, label, noh1, desbox, check);
            load();
        }
        private void ShowData(int index)
        {
            try
            {
                DataRow dr = sr.loadData().Rows[index];
                idc.Text = dr.ItemArray[0].ToString();
                label.Text = dr.ItemArray[1].ToString();
                noh.Text = dr.ItemArray[2].ToString();
                desbox.Text = dr.ItemArray[3].ToString();
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sr.delete_cs(idc);
            load();
        }
        
        private void listBox_Click(object sender, EventArgs e)
        {
            try
            {
                pos = listBox.SelectedIndex;
                ShowData(pos);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                pos = 0;
                ShowData(pos);
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if ((sr.loadData().Rows.Count - 1) > pos)
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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                pos = sr.loadData().Rows.Count - 1;
                ShowData(pos);
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
                check = verif();
                int noh1 = Convert.ToInt32(noh.Text.ToString());
                sr.Update_st(idc, label, noh1, desbox, check);
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
           
        }

        private void idc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void noh_ValueChanged(object sender, EventArgs e)
        {
            check_noh();
        }

        private void noh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
