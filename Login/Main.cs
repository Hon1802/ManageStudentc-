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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public bool isExit = true;
        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Student_Form g = new Add_Student_Form();
            g.ShowDialog();
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public event EventHandler Outpr;
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Outpr(this, new EventArgs());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Outpr(this, new EventArgs());
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
                Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                if (MessageBox.Show("The program will exit !!!!!", "Are you sure", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    e.Cancel = true;
            }

        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 h = new Form1();
            h.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void studentsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_List_Form h = new Student_List_Form();
            h.ShowDialog();
        }

        private void staticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics_Student st = new Statistics_Student();
            st.ShowDialog();
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update_Delete_Student_Form ud = new Update_Delete_Student_Form();
            ud.ShowDialog();
        }

        private void manageStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Students_Form mc = new Manage_Students_Form();
            mc.ShowDialog();
        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Course_Form ac = new Add_Course_Form();
            ac.ShowDialog();
        }

        private void removeCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove_Courses_Form rm = new Remove_Courses_Form();
            rm.ShowDialog();

        }

        private void manageCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_Courses_Form mc = new Manage_Courses_Form();
            mc.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Update_Course_Form ud = new Update_Course_Form();
            ud.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print_Student pt = new Print_Student();
            pt.ShowDialog();
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Print_Courses_Form p = new Print_Courses_Form();
            p.ShowDialog();
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Score p = new Add_Score();
            p.ShowDialog();
        }

        private void editRemoveScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Remove_Score rs = new Remove_Score();
            rs.ShowDialog();
        }

        private void manageScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage_score ms = new Manage_score();
            ms.ShowDialog();
        }

        private void avgScoreByCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Avr_Score_By_Course va = new Avr_Score_By_Course();
            va.ShowDialog();
        }

        private void aVGResultByScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AVG_Result_By_Score avg1 = new AVG_Result_By_Score();
            avg1.ShowDialog();
        }

        private void staticsResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistic_Result sr = new Statistic_Result();
            sr.ShowDialog();
        }

        private void printToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Print_Result pr = new Print_Result();
            pr.ShowDialog();
        }
    }
}
