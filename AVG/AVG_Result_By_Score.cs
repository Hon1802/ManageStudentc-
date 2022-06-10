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
using System.Xml;
using Xceed.Words.NET;
using Xceed.Document.NET;
using Font = Xceed.Document.NET.Font;
using Formatting = Xceed.Document.NET.Formatting;
using System.Diagnostics;

namespace project_10_3
{
    public partial class AVG_Result_By_Score : Form
    {
        public AVG_Result_By_Score()
        {
            InitializeComponent();
            string a =""; 
            //insert_co2();
            loaddata();
            dataGridView2.Hide();

        }
        My_DB db = new My_DB();
        Score sc = new Score();
        Courses cr = new Courses();
        int temp = 0;
        public bool knw = false;
        DataGridView dt = new DataGridView();
        //My_DB db = new My_DB();
        SqlCommand cmd = new SqlCommand();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AVG_Result_By_Score_Load(object sender, EventArgs e)
        {
            try
            {
                DataColumn col = new DataColumn((dataGridView1.ColumnCount + 1).ToString());
                dataGridView1.Columns.Add("Result", "Result");
                //           dataGridView1.Columns.Add("...", "...");
                //dataGridView1.Rows[1].Cells[1].Value = 6.5;
                //start region
                int end = dataGridView1.Columns.Count;
                //MessageBox.Show(end.ToString());
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 2].Value) >= 9)
                        dataGridView1.Rows[i].Cells[end - 1].Value = "Very Good";
                    else if(Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 2].Value) >= 8)
                        dataGridView1.Rows[i].Cells[end - 1].Value = "Good";
                    else if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 2].Value) >= 5)
                        dataGridView1.Rows[i].Cells[end - 1].Value = "Pass";
                    else
                        dataGridView1.Rows[i].Cells[end - 1].Value = "Faller";

                }
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Has errol!!!!", "information");
            }
            

            //end region
        }
        private string insert_co()
        {

            string str2 = "select label from courses";
            string chuoi = "";
            try
            {
                SqlCommand cmd = new SqlCommand(str2);
                DataGridView dataload = new DataGridView();
                dataGridView2.DataSource = cr.getCourse(cmd);
                dataload.DataSource = cr.getCourse(cmd);
                temp = dataGridView2.RowCount - 2;
                for (int i = 0; i < temp; i++)
                {
                    chuoi = chuoi + "[" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "], ";
                }
                chuoi += dataGridView2.Rows[temp].Cells[0].Value.ToString();
            } catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
           
            //MessageBox.Show(chuoi);
            return chuoi;
        }
        private string insert_co2()
        {
            string str2 = "select label from courses";
            string chuoi = "";
            try
            {
                SqlCommand cmd = new SqlCommand(str2);
                DataGridView dataload = new DataGridView();
                dataGridView1.DataSource = cr.getCourse(cmd);
                dataload.DataSource = cr.getCourse(cmd);
                temp = dataGridView2.RowCount - 2;
                for (int i = 0; i < temp; i++)
                {
                    chuoi = chuoi + "ROUND([" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "],1) as " + dataGridView2.Rows[i].Cells[0].Value.ToString() + ", ";
                }
                chuoi = chuoi + "ROUND([" + dataGridView2.Rows[temp].Cells[0].Value.ToString() + "],1) as " + dataGridView2.Rows[temp].Cells[0].Value.ToString() + "";
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
            
            return chuoi;
        }
        private void loaddata()
        {
            string str3 = insert_co();
            string str1 = "SELECT id, first_name, last_name, "+ insert_co2() + " ,ROUND(GOOD.[Average Score],2) as [Average Course] FROM (Select * FROM(select  DTB.[label], DTB.score, first_name, last_name, id from(Select[label],[student_id], course_id, score  From Scores Inner JOIN  courses on course_id = id Group by score, course_id, [label], Student_id) as DTB Inner JOIN Students on DTB.Student_id = id) as OK PIVOT(SUM(score) FOR OK.[label] IN(" + str3+ ")) AS PVTTable) AS MUCH INNER JOIN (Select student_id, AVG(Scores.score) AS [Average Score] FROM Scores Group by student_id) AS GOOD ON student_id = MUCH.id";
            try
            {
                SqlCommand cmd1 = new SqlCommand(str1);
                dataGridView1.DataSource = sc.getScore(cmd1);
                dataGridView1.RowTemplate.Height = 80;
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
                if (radioButton1.Checked)
                {
                    #region one
                    string fileName = "Export_Student.docx";
                    var doc = DocX.Create(fileName);
                    #endregion

                    #region two
                    string title = "CONG HOA XA HOI CHU NGHIA VIET NAM " + Environment.NewLine +" DOC LAP - TU DO - HANH PHUC " + Environment.NewLine +  "REPORT RESULT OF ONE STUDENT";

                    string title2 = "REPORT RESULT OF ONE STUDENT";


                    Formatting titleFormat = new Formatting();
                    titleFormat.FontFamily = new Font("Tahoma");
                    titleFormat.Size = 20D;
                    titleFormat.Position = 40;
                    titleFormat.FontColor = Color.BlueViolet;
                    titleFormat.UnderlineColor = Color.Gray;
                    titleFormat.Italic = true;

                    Formatting textParagraphFormat = new Formatting();
                    textParagraphFormat.FontFamily = new Font("Tahoma");
                    textParagraphFormat.Size = 12D;
                    textParagraphFormat.Spacing = 1;
                    
                    
                    #endregion
                    dataGridView1.AllowUserToAddRows = false;
                    int temp = dataGridView1.RowCount;
                    #region four
                    doc.InsertParagraph();
                    //t2
                    Paragraph paragraphTitle = doc.InsertParagraph(title, false, textParagraphFormat);
                    paragraphTitle.Alignment = Alignment.center;
                    //Paragraph paragraphTitle77 = doc.InsertParagraph(title2, false, titleFormat);
                    string textParagraph444 = "Today at  " + DateTime.Now.ToString() + Environment.NewLine;
                    doc.InsertParagraph(textParagraph444, false, textParagraphFormat);


                    string str2 = "select label from courses";
                    SqlCommand cmd = new SqlCommand(str2);
                    dataGridView2.DataSource = cr.getCourse(cmd);
                    int temppp = dataGridView2.RowCount;
                //t2
                    int tempq = dataGridView1.ColumnCount;
                    Table t = doc.AddTable(temppp + 2, 3);
                    t.Alignment = Alignment.center;
                    t.Design = TableDesign.ColorfulList;

                    t.Rows[0].Cells[0].Paragraphs.First().Append("Label");
                    t.Rows[0].Cells[1].Paragraphs.First().Append("Score");

                    //
                    string textParagraph1 = "MSSV : " + dataGridView1.CurrentRow.Cells[0].Value.ToString() + Environment.NewLine + "FULL NAME : " + dataGridView1.CurrentRow.Cells[1].Value.ToString() + " " + dataGridView1.CurrentRow.Cells[2].Value.ToString() + Environment.NewLine + "SCORES" + Environment.NewLine;

                    Formatting textParagraphFormat1 = new Formatting();
                    textParagraphFormat.FontFamily = new Font("Tahoma");
                    textParagraphFormat.Size = 12D;
                    textParagraphFormat.Spacing = 1;
                    //Paragraph paragraphTitle1 = doc.InsertParagraph(title, false, titleFormat);
                    paragraphTitle.Alignment = Alignment.center;
                    doc.InsertParagraph(textParagraph1, false, textParagraphFormat);


                //string str2 = "select label from courses";
                //SqlCommand cmd = new SqlCommand(str2);
                //dataGridView2.DataSource = cr.getCourse(cmd);
                //temp = dataGridView1.RowCount;
                try
                    {
                        int yeu = 0;
                        for (int i = 1; i < tempq - 5; i++)
                        {
                            string labe = dataGridView2.Rows[yeu].Cells[0].Value.ToString();
                            t.Rows[i].Cells[0].Paragraphs.First().Append(labe);
                            yeu++;
                        }
                        int k = 0;
                        int yeu2 = 1;
                        for (int kt = 3; kt < tempq - 2; kt++)
                        {
                            t.Rows[yeu2].Cells[1].Paragraphs.First().Append(dataGridView1.CurrentRow.Cells[kt].Value.ToString());
                            yeu2++;
                        }
                    }catch(Exception ad)
                    {
                        MessageBox.Show("0x002", "information");
                    }
                
                    string textParagraph3 = "AVERAGE: " + dataGridView1.CurrentRow.Cells[tempq - 2].Value.ToString() + Environment.NewLine + "RESULT : " + dataGridView1.CurrentRow.Cells[tempq - 1].Value.ToString() + Environment.NewLine;
                    doc.InsertParagraph(textParagraph3, false, textParagraphFormat);
                    doc.InsertTable(t);
                    #endregion
                    #region part of one
                    doc.Save();
                    Process.Start("WINWORD.EXE", fileName);
                    #endregion
                    Console.Read();
                }
                else
                {
                    #region one
                    string fileName = "Export_Report_All.docx";
                    var doc = DocX.Create(fileName);
                    #endregion

                    #region two
                    string title = "CONG HOA XA HOI CHU NGHIA VIET NAM " + Environment.NewLine + " DOC LAP - TU DO - HANH PHUC " + Environment.NewLine + "REPORT RESULT OF ONE STUDENT";

                    //string title = "Report All";

                    Formatting titleFormat = new Formatting();
                    titleFormat.FontFamily = new Font("Tahoma");
                    titleFormat.Size = 20D;
                    titleFormat.Position = 40;
                    titleFormat.FontColor = Color.BlueViolet;
                    titleFormat.UnderlineColor = Color.Gray;
                    titleFormat.Italic = true;

                    //Formatting Text Paragraph  
                    Formatting textParagraphFormat = new Formatting();
                    //font family  
                    textParagraphFormat.FontFamily = new Font("Tahoma");
                    //font size  
                    textParagraphFormat.Size = 12D;
                    //Spaces between characters  
                    textParagraphFormat.Spacing = 1;
                    //Insert title  
                    //Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
                    //paragraphTitle.Alignment = Alignment.center;
                    Paragraph paragraphTitle = doc.InsertParagraph(title, false, textParagraphFormat);
                    paragraphTitle.Alignment = Alignment.center;
                    //Paragraph paragraphTitle77 = doc.InsertParagraph(title2, false, titleFormat);
                    string textParagraph444 = "Today at  " + DateTime.Now.ToString() + Environment.NewLine;
                    doc.InsertParagraph(textParagraph444, false, textParagraphFormat);
                    #endregion


                    dataGridView1.AllowUserToAddRows = false;
                    int temp = dataGridView1.RowCount;
                    #region four
                    doc.InsertParagraph();
                    int tempq = dataGridView1.ColumnCount;
                    Table t = doc.AddTable(temp + 2, tempq - 2);
                    t.Alignment = Alignment.center;
                    t.Design = TableDesign.ColorfulList;

                    t.Rows[0].Cells[0].Paragraphs.First().Append("ID");
                    t.Rows[0].Cells[1].Paragraphs.First().Append("First Name");
                    t.Rows[0].Cells[2].Paragraphs.First().Append("Last Name");
                    string str2 = "select label from courses";
                    SqlCommand cmd = new SqlCommand(str2);
                    dataGridView2.DataSource = cr.getCourse(cmd);
                    temp = dataGridView1.RowCount;
                    int dem2 = 0;
                    for (int i = 3; i < tempq - 5; i++)
                    {
                        t.Rows[0].Cells[i].Paragraphs.First().Append(dataGridView2.Rows[dem2].Cells[0].Value.ToString());
                        dem2++;
                    }
                    //int i = 1;
                    int k = 0;
                    PictureBox picture1 = new PictureBox();
                    for (int i = 1; i <= temp; i++)
                    {
                        for (int kt = 0; kt < tempq - 2; kt++)
                        {
                            t.Rows[i].Cells[kt].Paragraphs.First().Append(dataGridView1.Rows[k].Cells[kt].Value.ToString());
                        }
                        k++;
                    }
                    doc.InsertTable(t);
                    #endregion
                    #region part of one
                    doc.Save();
                    Process.Start("WINWORD.EXE", fileName);
                    #endregion
                    Console.Read();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                stid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                fname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                lname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x0001", "information");
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text != " ")
                {
                    try
                    {
                        string str3 = insert_co();
                        string str1 = "SELECT id, first_name, last_name, " + insert_co2() + " ,ROUND(GOOD.[Average Score],2) as [Average Course] FROM (Select * FROM(select  DTB.[label], DTB.score, first_name, last_name, id from(Select[label],[student_id], course_id, score  From Scores Inner JOIN  courses on course_id = id Group by score, course_id, [label], Student_id) as DTB Inner JOIN Students on DTB.Student_id = id) as OK PIVOT(SUM(score) FOR OK.[label] IN(" + str3 + ")) AS PVTTable) AS MUCH INNER JOIN (Select student_id, AVG(Scores.score) AS [Average Score] FROM Scores Group by student_id) AS GOOD ON student_id = MUCH.id where (id Like '%" + txtsearch.Text + "%') or (first_name like '%" + txtsearch.Text + "%')";
                        SqlCommand cmd1 = new SqlCommand(str1);
                        dataGridView1.Columns.Remove("Result");
                        dataGridView1.DataSource = sc.getScore(cmd1);
                        stid.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                        fname.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                        lname.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                        dataGridView1.RowTemplate.Height = 80;
                        DataColumn col = new DataColumn((dataGridView1.ColumnCount + 1).ToString());
                        dataGridView1.Columns.Add("Result", "Result");
                        int end = dataGridView1.Columns.Count;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 2].Value) >= 5)
                                dataGridView1.Rows[i].Cells[end - 1].Value = "Pass";
                            else
                                dataGridView1.Rows[i].Cells[end - 1].Value = "Faller";

                        }
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                    } catch(Exception ex0)
                    {
                        MessageBox.Show("try again", "Information");
                    }
                    
                }
                else
                {
                try
                    {
                        string str3 = insert_co();
                        string str1 = "SELECT id, first_name, last_name, " + insert_co2() + " ,ROUND(GOOD.[Average Score],2) as [Average Course] FROM (Select * FROM(select  DTB.[label], DTB.score, first_name, last_name, id from(Select[label],[student_id], course_id, score  From Scores Inner JOIN  courses on course_id = id Group by score, course_id, [label], Student_id) as DTB Inner JOIN Students on DTB.Student_id = id) as OK PIVOT(SUM(score) FOR OK.[label] IN(" + str3 + ")) AS PVTTable) AS MUCH INNER JOIN (Select student_id, AVG(Scores.score) AS [Average Score] FROM Scores Group by student_id) AS GOOD ON student_id = MUCH.id ";
                        SqlCommand cmd1 = new SqlCommand(str1);
                        dataGridView1.Columns.Remove("Result");
                        dataGridView1.DataSource = sc.getScore(cmd1);
                        stid.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                        fname.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                        lname.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                        dataGridView1.RowTemplate.Height = 80;
                        DataColumn col = new DataColumn((dataGridView1.ColumnCount + 1).ToString());
                        dataGridView1.Columns.Add("Result", "Result");
                        int end = dataGridView1.Columns.Count;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Convert.ToDouble(dataGridView1.Rows[i].Cells[end - 2].Value) >= 5)
                                dataGridView1.Rows[i].Cells[end - 1].Value = "Pass";
                            else
                                dataGridView1.Rows[i].Cells[end - 1].Value = "Faller";

                        }
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                    } catch (Exception ex)
                    {
                    MessageBox.Show("try later!!", "informaton");
                    }
                   
                }
        }
    }
}
