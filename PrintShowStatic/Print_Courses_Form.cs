using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Font = Xceed.Document.NET.Font;
using Formatting = Xceed.Document.NET.Formatting;

namespace project_10_3
{
    public partial class Print_Courses_Form : Form
    {
        public Print_Courses_Form()
        {
            InitializeComponent();
            dataGridView1.DataSource = cs.loadData();
            dataGridView1.RowTemplate.Height = 80;
        }
        Courses cs = new Courses();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region one
                string fileName = "Export_Course.docx";
                var doc = DocX.Create(fileName);
                #endregion

                #region two
                //string title = "Course_List";
                string title = "CONG HOA XA HOI CHU NGHIA VIET NAM " + Environment.NewLine + " DOC LAP - TU DO - HANH PHUC " + Environment.NewLine + "COURSE LIST";


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
                //Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleFormat);
                //paragraphTitle.Alignment = Alignment.center;

                Paragraph paragraphTitle = doc.InsertParagraph(title, false, textParagraphFormat);
                paragraphTitle.Alignment = Alignment.center;
                //Paragraph paragraphTitle77 = doc.InsertParagraph(title2, false, titleFormat);
                string textParagraph444 = "Today at  " + DateTime.Now.ToString() + Environment.NewLine;
                doc.InsertParagraph(textParagraph444, false, textParagraphFormat);
                #endregion


                dataGridView1.AllowUserToAddRows = false;
                int temp1 = dataGridView1.RowCount;
                #region four
                doc.InsertParagraph();
                Table t = doc.AddTable(temp1 + 1, 4);
                t.Alignment = Alignment.center;
                t.Design = TableDesign.ColorfulList;

                t.Rows[0].Cells[0].Paragraphs.First().Append("ID");
                t.Rows[0].Cells[1].Paragraphs.First().Append("Label");
                t.Rows[0].Cells[2].Paragraphs.First().Append("Period");
                t.Rows[0].Cells[3].Paragraphs.First().Append("Description");
                int k = 0;
                for (int i = 1; i <= temp1; i++)
                {
                    t.Rows[i].Cells[0].Paragraphs.First().Append(dataGridView1.Rows[k].Cells[0].Value.ToString());
                    t.Rows[i].Cells[1].Paragraphs.First().Append(dataGridView1.Rows[k].Cells[1].Value.ToString());
                    t.Rows[i].Cells[2].Paragraphs.First().Append(dataGridView1.Rows[k].Cells[2].Value.ToString());
                    t.Rows[i].Cells[3].Paragraphs.First().Append(dataGridView1.Rows[k].Cells[3].Value.ToString());
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

        private void btp_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Student_list.txt";
                //loi phải tắt phần mềm bảo vệ
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
                            write.Write("\t" + dataGridView1.Rows[h].Cells[j].Value.ToString() + "\t" + "|");
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

        private void Print_Courses_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
