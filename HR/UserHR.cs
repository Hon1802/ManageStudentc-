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
    public partial class UserHR : Form
    {
        Contact contact = new Contact();
        public UserHR()
        {
            InitializeComponent();
            panelcontact.Show();
            panelgroup.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
        }
        public int motbientam = 0;
        My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        Group group = new Group();
        public Image ByteArrayToImage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 h = new Form1();
            h.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            panelgroup.Hide();
            panelcontact.Show();
            
        }

        private void Group_Click(object sender, EventArgs e)
        {
            UserHR_Load(null, null);
            panelcontact.Hide();
            panelgroup.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Add_Edit_new_contact ct = new Add_Edit_new_contact();
            //ct.paneledit.Show();
            ct.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Add_Edit_new_contact ct = new Add_Edit_new_contact();
            ct.paneledit.Show();
            ct.ShowDialog();
        }

        private void Remove_Click_1(object sender, EventArgs e)
        {
            try
            {
                int num = -1; // checking input is interger or not
                if (txtcontextID.Text.Trim() == "")
                {
                    MessageBox.Show("Please Add An ID", "Select Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!Int32.TryParse(txtcontextID.Text, out num))
                {
                    MessageBox.Show("Please Add An InterGer", "Select Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int ContactID = Convert.ToInt32(txtcontextID.Text);
                    if (!contact.CheckContactID(ContactID))
                    {
                        if ((MessageBox.Show("Are you sure want to delete this student?", "Delete Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            if (contact.deleteContact(ContactID))
                            {
                                MessageBox.Show("Contact Deleted", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtcontextID.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Can Not Delete Contact", "Delete Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ID Can Not Be Found!", "Select Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtcontextID.Text = "";
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Show_Contact ct = new Show_Contact();
            ct.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        bool verif()
        {
            if (tbgroupname.Text.Trim() == "" || idgr.Text.Trim() == "")
                return false;
            else
                return true;

        }
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (verif())
                {
                    int num = -1;
                    if (tbgroupname.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Add An ID", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (!Int32.TryParse(idgr.Text, out num))
                    {
                        MessageBox.Show("Please Add An InterGer For Group's ID", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int GroupID = Convert.ToInt32(idgr.Text);
                        string GroupName = tbgroupname.Text;
                        if (group.CheckGroupID(GroupID))
                        {
                            if (group.CheckGroupName(GroupName))
                            {
                                if (group.insertGroup(GroupID, GroupName, Global.GlobalUserID1))
                                {
                                    MessageBox.Show("Group Added!", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    idgr.Text = ""; tbgroupname.Text = "";
                                    UserHR_Load(null, null);
                                }
                                else
                                {
                                    MessageBox.Show("Can Not Add Group!", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Group's Name Existed!", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                tbgroupname.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Group's ID Existed!", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            idgr.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Add Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x000012", "information");
            }
        }

        private void UserHR_Load(object sender, EventArgs e)
        {
            try
            {
                selectgroupnae.DataSource = group.GetUserGroups(Global.GlobalUserID1);
                selectgroupnae.DisplayMember = "Name";
                selectgroupnae.ValueMember = "id";
                cbselectgroupnameduoi.DataSource = group.GetUserGroups(Global.GlobalUserID1);
                cbselectgroupnameduoi.DisplayMember = "Name";
                cbselectgroupnameduoi.ValueMember = "id";
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
           
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            try
            {

                if (tbenternewname.Text.Trim() != "")
                {
                    string GroupName = tbenternewname.Text;
                    int GroupID = (int)selectgroupnae.SelectedValue;
                    if (group.CheckGroupName(GroupName))
                    {
                        if (group.updateGroupName(GroupID, GroupName))
                        {
                            MessageBox.Show("Group's Name Edited", "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbenternewname.Text = "";
                            UserHR_Load(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Can Not Update Group's Name", "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Group's Name Existed!", "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbenternewname.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }catch (Exception exp)
            {
                MessageBox.Show("0x00001", "Information");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                if ((MessageBox.Show("Are you sure want to delete this Group?", "Delete Group", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    int GroupID = (int)cbselectgroupnameduoi.SelectedValue;
                    //int GroupID = (int)cbb_EditGroup.SelectedIndex;
                    if (group.deleteGroup(GroupID))
                    {
                        MessageBox.Show("Group Deleted", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UserHR_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Can Not Delete Group!", "Delete Group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } catch (Exception exp)
            {
                MessageBox.Show("0x00001", "Information");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Refresh();
        }
        Score sc = new Score();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                HR.Edit_My_Profile ed = new HR.Edit_My_Profile();
                string str = "select * from UserHR Where id = " + motbientam;
                SqlCommand cmd1 = new SqlCommand(str);
                dataGridView2.DataSource = sc.getScore(cmd1);

                ed.txtfirstname.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
                ed.txtlastname.Text = dataGridView2.Rows[0].Cells[2].Value.ToString();
                ed.txtuser.Text = dataGridView2.Rows[0].Cells[3].Value.ToString();
                ed.txtemail.Text = dataGridView2.Rows[0].Cells[6].Value.ToString();
                byte[] b = (byte[])dataGridView2.Rows[0].Cells[5].Value;
                ed.pictureBox1.Image = ByteArrayToImage(b);
                ed.ShowDialog();
            }
            catch( Exception exp)
            {
                MessageBox.Show("0x0002", "Information");
            }
            
        }
    }
}
