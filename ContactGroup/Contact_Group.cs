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
    public partial class Contact_Group : Form
    {
        public Contact_Group()
        {
            InitializeComponent();
            //panelgr.Hide();
            panel1.Hide();
        }
        Users us = new Users();
        private void Contact_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel3.BackColor = Color.Blue;
            panelgr.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelgr.Show();
            panel1.Hide();
            selectgroupnae.DataSource = us.loadData();
            selectgroupnae.DisplayMember = "name";
            selectgroupnae.ValueMember = "id";
            selectgroupnae.SelectedItem = null;
            cbselectgroupnameduoi.DataSource = us.loadData();
            cbselectgroupnameduoi.DisplayMember = "name";
            cbselectgroupnameduoi.ValueMember = "id";
            cbselectgroupnameduoi.SelectedItem = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //add button
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //edit button
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //select contack
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //bt remove
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //bt show full
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //add group name
        }

        private void add_Click(object sender, EventArgs e)
        {
            //new group name
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //select groupname duoi
        }

        private void Contact_Group_Load(object sender, EventArgs e)
        {

        }
        bool verif1()
        {
            if ((tbgroupname.Text.Trim() == "") ||
                    (idgr.Text.Trim() == ""))
            {
                MessageBox.Show("Please try again !!!!!!", "error");
                return false;
            }
            else
            {
                return true;
            }
        }
        bool verif2()
        {
            if ((selectgroupnae.Text.Trim() == "") ||
                    (tbenternewname.Text.Trim() == ""))
            {
                MessageBox.Show("Please try again !!!!!!", "error");
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            string name = tbgroupname.Text;
            us.Add_group(name, idgr,verif1());
        }
        My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        private void Edit_Click(object sender, EventArgs e)
        {
            string name = selectgroupnae.Text;
            string name1 = tbenternewname.Text;
            // chon lai id
            db.openConnection();
            cmd = db.GetConnection.CreateCommand();

            SqlCommand check_id = new SqlCommand("select id from mygroup where name = '" + name+"'", db.GetConnection);
            int UserExist = (int)check_id.ExecuteScalar();
            //double ex = UserExist * 100 / ctt();
            db.closeConnection();
            int id = UserExist;
            us.Update_group(id, name1,verif2());
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            db.openConnection();
            cmd = db.GetConnection.CreateCommand();

            SqlCommand check_id = new SqlCommand("select id from mygroup where name = '" + cbselectgroupnameduoi.Text + "'", db.GetConnection);
            int UserExist = (int)check_id.ExecuteScalar();
            //double ex = UserExist * 100 / ctt();
            db.closeConnection();
            int id = UserExist;
            us.delete_group(id);
        }
    }
}
