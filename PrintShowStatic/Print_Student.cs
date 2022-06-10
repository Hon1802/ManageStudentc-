using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Xceed.Words.NET;
using Xceed.Document.NET;
using Font = Xceed.Document.NET.Font;
using Formatting = Xceed.Document.NET.Formatting;

namespace project_10_3
{
    public partial class Print_Student : Form
    {
        public Print_Student()
        {
            InitializeComponent();
            dataGridView1.DataSource = st.loadData();
            dataGridView1.RowTemplate.Height = 80;
        }
        Student st = new Student();
        private void btp_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Student_list.txt";
                using (var write = new StreamWriter(path))
                {
                    if (!File.Exists(path))
                    {
                        File.Create(path);
                    }
                    dataGridView1.AllowUserToAddRows = false;
                    for (int h = 0; h < dataGridView1.Rows.Count; h++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if(j==3)
                            {
                                DateTime bdate = Convert.ToDateTime(dataGridView1.Rows[h].Cells[j].Value.ToString());
                                write.Write("\t" + bdate.ToString("yyyy-MM-dd") + "\t" + "|");
                            }
                            else
                            {
                                write.Write("\t" + dataGridView1.Rows[h].Cells[j].Value.ToString() + "\t" + "|");
                            }
                            
                        }
                        write.WriteLine("");
                        write.WriteLine("------------------------------------------------------------------------------------------------------------------");

                    }

                    write.Close();
                    MessageBox.Show("Data Exported");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
        }
        
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Go_Click(object sender, EventArgs e)
        {
            if (all.Checked)
            {
                if (no.Checked)
                {
                    try {
                        DateTime dates = dp1.Value;
                        DateTime datee = dp2.Value;
                        string cmd = "SELECT * FROM Students where birthday BETWEEN '" + dates + "' AND '" + datee + "' ";
                        SqlCommand com = new SqlCommand(cmd);
                        dataGridView1.RowTemplate.Height = 80;
                        dataGridView1.DataSource = st.getStudents1(com);
                        this.Refresh();
                    } catch (Exception ex)
                    {
                        MessageBox.Show("check again !!!!", "information");
                    }
                }
                else
                {
                    try {
                        string cmd = "SELECT * FROM Students ";
                        SqlCommand com = new SqlCommand(cmd);
                        dataGridView1.RowTemplate.Height = 80;
                        dataGridView1.DataSource = st.getStudents1(com);
                        this.Refresh();
                    } catch (Exception ex)
                    {
                        MessageBox.Show("check again !!!!", "information");
                    }
                }

            }
            else if (male.Checked)
            {
                if (no.Checked)
                {
                    try { 
                        DateTime dates = dp1.Value;
                        DateTime datee = dp2.Value;                 
                        string cmd = "SELECT * FROM Students where birthday BETWEEN '" + dates + "' AND '" + datee + "' AND gender = 'Male'";
                        SqlCommand com = new SqlCommand(cmd);
                        dataGridView1.RowTemplate.Height = 80;
                        dataGridView1.DataSource = st.getStudents1(com);
                        this.Refresh();
                    } catch (Exception ex)
                    {
                        MessageBox.Show("check again !!!!", "information");
                    }
                }
                else
                {
                    try
                    {
                        string cmd = "SELECT * FROM Students where gender = 'Male'";
                        SqlCommand com = new SqlCommand(cmd);
                        dataGridView1.RowTemplate.Height = 80;
                        dataGridView1.DataSource = st.getStudents1(com);
                        this.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("check again !!!!", "information");
                    }
                    
                }

            }
            else if (female.Checked)
            {
                try
                {
                    if (no.Checked)
                    {
                        DateTime dates = dp1.Value;
                        DateTime datee = dp2.Value;
                        string cmd = "SELECT * FROM Students where birthday BETWEEN '" + dates + "' AND '" + datee + "' AND gender = 'Female'";
                        SqlCommand com = new SqlCommand(cmd);
                        dataGridView1.RowTemplate.Height = 80;
                        dataGridView1.DataSource = st.getStudents1(com);
                        this.Refresh();
                    }
                    else
                    {
                        DateTime dates = dp1.Value;
                        DateTime datee = dp2.Value;
                        string cmd = "SELECT * FROM Students where gender = 'Female'";
                        SqlCommand com = new SqlCommand(cmd);
                        dataGridView1.RowTemplate.Height = 80;
                        dataGridView1.DataSource = st.getStudents1(com);
                        this.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("check again !!!!", "information");
                }
                

            }
            else
            {
                try
                {
                    string cmd = "SELECT * FROM Students ";
                    SqlCommand com = new SqlCommand(cmd);
                    dataGridView1.RowTemplate.Height = 80;
                    dataGridView1.DataSource = st.getStudents1(com);
                    this.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("check again !!!!", "information");
                }
               
            }
        }

        private void Print_Student_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region one
                string fileName = "Export_Student_List.docx";
                var doc = DocX.Create(fileName);
                #endregion

                #region two
                string title = "CONG HOA XA HOI CHU NGHIA VIET NAM " + Environment.NewLine + " DOC LAP - TU DO - HANH PHUC " + Environment.NewLine + "REPORT RESULT STUDENT";


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
                Table t = doc.AddTable(temp + 2, 8);
                t.Alignment = Alignment.center;
                t.Design = TableDesign.ColorfulList;

                t.Rows[0].Cells[0].Paragraphs.First().Append("ID");
                t.Rows[0].Cells[1].Paragraphs.First().Append("First Name");
                t.Rows[0].Cells[2].Paragraphs.First().Append("Last Name");
                t.Rows[0].Cells[3].Paragraphs.First().Append("Birthday");
                t.Rows[0].Cells[4].Paragraphs.First().Append("Gender");
                t.Rows[0].Cells[5].Paragraphs.First().Append("Phone");
                t.Rows[0].Cells[6].Paragraphs.First().Append("Address");
                t.Rows[0].Cells[7].Paragraphs.First().Append("Picture");
                //int i = 1;
                int k = 0;
                MemoryStream ms = new MemoryStream();
                PictureBox picture1 = new PictureBox();
                for (int i = 1; i <= temp; i++)
                {
                    t.Rows[i].Cells[0].Paragraphs.First().Append(dataGridView1.Rows[k].Cells[0].Value.ToString());
                    t.Rows[i].Cells[1].Paragraphs.First().Append(dataGridView1.Rows[k].Cells[1].Value.ToString());
                    t.Rows[i].Cells[2].Paragraphs.First().Append(dataGridView1.Rows[k].Cells[2].Value.ToString());
                    string stringtodate = ((DateTime)dataGridView1.Rows[k].Cells[3].Value).ToString("MM-dd-yyyy");
                    t.Rows[i].Cells[3].Paragraphs.First().Append(stringtodate);
                    t.Rows[i].Cells[4].Paragraphs.First().Append(dataGridView1.Rows[k].Cells[4].Value.ToString());
                    t.Rows[i].Cells[5].Paragraphs.First().Append(dataGridView1.Rows[k].Cells[5].Value.ToString());
                    t.Rows[i].Cells[6].Paragraphs.First().Append(dataGridView1.Rows[k].Cells[6].Value.ToString());

                    using (MemoryStream ms1 = new MemoryStream())
                    {
                        byte[] pic;
                        pic = (byte[])dataGridView1.Rows[k].Cells[7].Value;
                        MemoryStream picture = new MemoryStream();
                        System.Drawing.Image myImg = st.ByteArrayToImage(pic);
                        myImg.Save(ms1, myImg.RawFormat);
                        ms1.Seek(0, SeekOrigin.Begin);
                        var img2 = doc.AddImage(ms1);
                        Picture p2 = img2.CreatePicture();
                        p2.Width = 100;
                        p2.Height = 100;
                        Paragraph par2 = doc.InsertParagraph();
                        par2.Alignment = Alignment.center;
                        //    par2.AppendPicture(p2);
                        t.Rows[i].Cells[7].Paragraphs.First().AppendPicture(p2);
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
            catch (Exception ex)
            {
                MessageBox.Show("check again !!!!", "information");
            }
            
        }

        private void gr2_Enter(object sender, EventArgs e)
        {

        }

        private void gr1_Enter(object sender, EventArgs e)
        {

        }
    }
}
