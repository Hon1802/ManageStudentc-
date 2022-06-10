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
    public partial class Add_Course_Form : Form
    {
        public Add_Course_Form()
        {
            InitializeComponent();
        }
        bool verif()
        {
            if ((txtlable.Text.Trim() == "") ||
                    (noh.Text.Trim() == "") ||
                    (idc.Text.Trim() == "") ||
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main ne = new Main();
            ne.Show();

        }
        My_DB bd = new My_DB();
        Courses sc = new Courses();
        private void add_Click(object sender, EventArgs e)
        {
            bool check = verif();
            int noh1 = Convert.ToInt32(noh.Text.ToString());
            sc.Add_course(idc, txtlable, noh1, desbox, check);
            //this.Hide();
            //Main ne = new Main();
            //ne.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool check = verif();
            int noh1 = Convert.ToInt32(noh.Text.ToString());
            sc.Add_course(idc, txtlable, noh1, desbox, check);
        }

        private void noh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void check_noh()
        {
            int noh1 = Convert.ToInt32(noh.Text.ToString());
            try
            {
                if (noh1 < 10)
                {
                    add.Enabled = false;
                    MessageBox.Show("Number Of Hours must be more 10 , try again !!!!!!", "error");
                }
                else add.Enabled = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
           
        }
        private void Add_Course_Form_Load(object sender, EventArgs e)
        {
        }



        private void noh_ValueChanged(object sender, EventArgs e)
        {
            check_noh();
        }
    }
}
