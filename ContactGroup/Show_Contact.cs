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
    public partial class Show_Contact : Form
    {
        public Show_Contact()
        {
            InitializeComponent();
        }
        Contact contact = new Contact();
        Group group = new Group();
        private void bt_ShowFull_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                dataGridView1.RowTemplate.Height = 80;
                dataGridView1.DataSource = contact.SelectContactList();
                picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.AllowUserToAddRows = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Show_Contact_Load(object sender, EventArgs e)
        {
            try
            {
                //List Box
                listbox_Group.DataSource = group.GetUserGroups(Global.GlobalUserID1);
                listbox_Group.ValueMember = "Id";
                listbox_Group.DisplayMember = "name";
                listbox_Group.SelectedItem = null;
                //MessageBox.Show(Global.GlobalUserID1.ToString());
                //DataGridView
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                dataGridView1.RowTemplate.Height = 80;
                dataGridView1.DataSource = group.ContactListByUserID(Global.GlobalUserID1);
                picCol = (DataGridViewImageColumn)dataGridView1.Columns[6];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView1.AllowUserToAddRows = false;

                dataGridView1.ClearSelection();

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (i % 2 != 0)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
           
        }

        private void listbox_Group_Click(object sender, EventArgs e)
        {
            try
            {
                int GroupID = (Int32)listbox_Group.SelectedValue;
                dataGridView1.DataSource = contact.ContactListByUserIDandGroupID(Global.GlobalUserID1, GroupID);
            } catch(Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
        }

        private void listbox_Group_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        DK.RT rt = new DK.RT();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Print_Result pr = new Print_Result();
                pr.ch = false;
                string strt = "select dt.Student_id as StudentID,first_name as FirstName, last_name as LastName, label, student_score as Score, HR_id as HR from (SELECT Scores.Student_id, Students.first_name, Students.last_name, Scores.Course_id, courses.label, round(Scores.score,3) as student_score FROM Students INNER JOIN Scores on Students.id = Scores.Student_id INNER JOIN courses on Scores.Course_id = courses.id ) as dt Inner join Dangky on dt.Course_id = Dangky.Course_id  where HR_id =" + Global.GlobalUserID1 + " order by dt.label ";
                SqlCommand cmd1 = new SqlCommand(strt);
                pr.datve.DataSource = rt.getdata(cmd1);
                pr.datve.RowTemplate.Height = 80;
                pr.ShowDialog();
            } catch (Exception exp)
            {
                MessageBox.Show("0x0001", "Information");
            }
            
        }
    }
}
