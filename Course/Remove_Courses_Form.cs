using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_10_3
{
    public partial class Remove_Courses_Form : Form
    {
        public Remove_Courses_Form()
        {
            InitializeComponent();
        }
        My_DB bd = new My_DB();
        Courses cr = new Courses();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (idc.Text == "")
                {
                    MessageBox.Show(" Please fill full ", " Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (cr.check_exist(idc) == 1)
                    {
                        cr.delete_cs(idc);
                        idc.Text = "";
                    }
                    else
                    {
                        MessageBox.Show(" No had Course before", " Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
        }
        
        private void idc_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void Remove_Courses_Form_Load(object sender, EventArgs e)
        {

        }

        private void idc_KeyUp(object sender, KeyEventArgs e)
        {
            if (idc.Text == "")
            {
                idc.BackColor = Color.White;
            }
            else if (cr.check_exist(idc) == 0)
            {
                idc.BackColor = Color.Red;

            }
            else idc.BackColor = Color.White;
            
        }

        private void idc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
