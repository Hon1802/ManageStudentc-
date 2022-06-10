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
    public partial class Update_Course_Form : Form
    {
        public Update_Course_Form()
        {
            InitializeComponent();
        }
        My_DB db = new My_DB();
        Courses cr = new Courses();
        bool check;

        private void idc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void check_noh()
        {
            try
            {
                int noh1 = Convert.ToInt32(noh.Text.ToString());
                if (noh1 < 10)
                {
                    button1.Enabled = false;
                    MessageBox.Show("Number Of Hours must be more 10 , try again !!!!!!", "error");
                    noh.Text = "";
                }
                else
                {
                    button1.Enabled = true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }
        bool verif()
        {
            if ((idc.Text.Trim() == "") ||
                    (noh.Text.Trim() == "") ||
                    (selectc.Text.Trim() == "") ||
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
        private void button2_Click(object sender, EventArgs e)
        {
            cr.delete_cs(idc);
            idc.Text = "";
            selectc.Text = "";
            noh.Text = "";
            desbox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                check = verif();
                int noh1 = Convert.ToInt32(noh.Text.ToString());
                string selec = selectc.Text.ToString();
                cr.Update_st1(idc, selec, noh1, desbox, check);
                idc.Text = "";
                selectc.Text = "";
                noh.Text = "";
                desbox.Text = "";
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
        }

        private void idc_TextChanged(object sender, EventArgs e)
        {
            
        }

        
        private void noh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                check = false;
                db.openConnection();
                SqlCommand cmd;
                cmd = db.GetConnection.CreateCommand();

                SqlCommand ncmd = new SqlCommand("SELECT * FROM courses WHERE (id = @id)", db.GetConnection);
                ncmd.Parameters.AddWithValue("@id", idc.Text);
                SqlDataReader mdr1 = ncmd.ExecuteReader();
                if (mdr1.Read())
                {
                    selectc.Text = mdr1.GetString(1).ToString();
                    //int temp =
                    noh.Text = mdr1.GetInt32(2).ToString();
                    desbox.Text = mdr1.GetString(3).ToString();
                    MessageBox.Show("FIND IT !!!!!!", "OK");
                    db.closeConnection();
                    mdr1.Close();
                    check = true;
                }
                else
                {
                    MessageBox.Show("DON't FIND IT !!!!!!", "ERROL");
                    selectc.Text = "";
                    noh.Text = "";
                    desbox.Text = "";
                    db.closeConnection();
                    mdr1.Close();
                    check = true;
                }
                mdr1.Close();

                check = true;
                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
           
        }

        private void Update_Course_Form_Load(object sender, EventArgs e)
        {
            try
            {
                selectc.DataSource = cr.loadData();
                selectc.DisplayMember = "label";
                selectc.ValueMember = "id";
                selectc.SelectedItem = null;
                idc.Text = "";
                selectc.Text = "";
                noh.Text = "";
                desbox.Text = "";
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            

        }
        private void selectc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd;
                cmd = db.GetConnection.CreateCommand();
                if (check)
                {
                    SqlCommand ncmd = new SqlCommand("SELECT * FROM courses WHERE (label = @lb)", db.GetConnection);
                    ncmd.Parameters.AddWithValue("@lb", selectc.Text);
                    SqlDataReader mdr1 = ncmd.ExecuteReader();
                    if (mdr1.Read())
                    {
                        idc.Text = mdr1.GetInt32(0).ToString();
                        noh.Text = mdr1.GetInt32(2).ToString();
                        desbox.Text = mdr1.GetString(3).ToString();

                    }
                    mdr1.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            


        }

        private void noh_ValueChanged(object sender, EventArgs e)
        {
            check_noh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
