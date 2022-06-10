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

namespace project_10_3
{
    public partial class Add_Edit_new_contact : Form
    {
        public Add_Edit_new_contact()
        {
            InitializeComponent();
            call1();
        }
        Users us = new Users();
        Contact contact = new Contact();
        Group group = new Group();
        int idtemp = 0;
        private void call1()
        {
            panel2.Show();
            paneledit.Hide();
        }
        private void call2()
        {
            paneledit.Show();
            panel2.Hide();
        }

        bool verif()
        {
            if ((txtfirstname.Text.Trim() == "") ||
                    (txtlastname.Text.Trim() == "") ||
                    (cbgroup.Text.Trim() == "") ||
                    (ema.Text.Trim() == "") ||
                    (phone.Text.Trim() == "") ||
                    (addressbox.Text.Trim() == "") ||
                    (idct.Text.Trim() == ""))
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
            if ((fnamect.Text.Trim() == "") ||
                    (lnamect.Text.Trim() == "") ||
                    (cbgroupct.Text.Trim() == "") ||
                    (emailct.Text.Trim() == "") ||
                    (phonect.Text.Trim() == "") ||
                    (addressct.Text.Trim() == "") ||
                    (id_ct.Text.Trim() == ""))
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
            string fname = txtfirstname.Text;
            string lname = txtlastname.Text;
            string email = ema.Text;
            string addr = addressbox.Text;
            us.Add_contact(fname, lname, idtemp, phone, email, addr, idct, pictureBox1, verif());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            call1();
            cbgroup.DataSource = us.loadData();
            cbgroup.DisplayMember = "name";
            cbgroup.ValueMember = "id";
            idtemp = (int)cbgroup.SelectedValue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            call2();
            cbgroupct.DataSource = us.loadData();
            cbgroupct.DisplayMember = "name";
            cbgroupct.ValueMember = "id";
            idtemp = (int)cbgroupct.SelectedValue;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            {
                pictureBox2.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void Add_Edit_new_contact_Load(object sender, EventArgs e)
        {
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void paneledit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int num = -1; // checking input is interger or not
                if (id_ct.Text.Trim() == "")
                {
                    MessageBox.Show("Please Add An ID", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!Int32.TryParse(id_ct.Text, out num))
                {
                    MessageBox.Show("Please Add An InterGer", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int ContactID = Convert.ToInt32(id_ct.Text);
                    if (!contact.CheckContactID(ContactID))
                    {
                        DataTable table = new DataTable();
                        table = contact.GetContactByID(ContactID);
                        fnamect.Text = table.Rows[0]["fname"].ToString();
                        lnamect.Text = table.Rows[0]["lname"].ToString();
                        cbgroupct.DataSource = group.GetAllGroups();
                        cbgroupct.DisplayMember = "name";
                        cbgroupct.ValueMember = "id";
                        cbgroupct.SelectedValue = table.Rows[0]["group_id"];
                        phonect.Text = table.Rows[0]["phone"].ToString();
                        emailct.Text = table.Rows[0]["email"].ToString();
                        addressct.Text = table.Rows[0]["address"].ToString();
                        byte[] pic = (byte[])table.Rows[0]["pic"];
                        MemoryStream ms = new MemoryStream(pic);
                        pictureBox2.Image = Image.FromStream(ms);
                    }
                    else
                    {
                        MessageBox.Show("ID Can Not Be Found!", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        fnamect.Text = " ";
                        lnamect.Text = "";
                        cbgroupct.Text = "";
                        phonect.Text = "";
                        emailct.Text = "";
                        addressct.Text = "";
                        pictureBox2.Image = null;
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (verif2())
                {
                    int ContactID = Convert.ToInt32(id_ct.Text);
                    string fname = fnamect.Text;
                    string lname = lnamect.Text;
                    string phone = phonect.Text;
                    string email = emailct.Text;
                    string address = addressct.Text;
                    int GroupID = (int)cbgroupct.SelectedValue;
                    MemoryStream pic = new MemoryStream();
                    pictureBox2.Image.Save(pic, pictureBox2.Image.RawFormat);
                    if (contact.CheckContactIDForEdit(ContactID))
                    {
                        if (contact.updateContact(ContactID, fname, lname, phone, address, email, GroupID, pic))
                        {
                            MessageBox.Show("Contact Edited", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fnamect.Text = " ";
                            lnamect.Text = "";
                            cbgroupct.Text = "";
                            phonect.Text = "";
                            emailct.Text = "";
                            addressct.Text = "";
                            pictureBox2.Image = null;
                        }
                        else
                        {
                            MessageBox.Show("Can not Update Contact With Non-Exists ID", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ID Already Existed!", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Contact", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            {
                pictureBox2.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void paneledit_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
