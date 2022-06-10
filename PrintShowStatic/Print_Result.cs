using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Xceed.Document.NET;
using Font = Xceed.Document.NET.Font;
using Formatting = Xceed.Document.NET.Formatting;

namespace project_10_3
{
    public partial class Print_Result : Form
    {
        public Print_Result()
        {
            InitializeComponent();
        }

        public bool ch = true;
        private void Print_Result_Load(object sender, EventArgs e)
        {

            try
            {
                if(ch)
                {
                    datve.DataSource = score.getStudentScore();
                    datve.RowTemplate.Height = 80;
                    datve.AllowUserToAddRows = false;
                    datve.ReadOnly = true;
                }
                
            }
            catch (Exception exp)
            {
                MessageBox.Show("0x011", "Infromation");
            }
        }
        My_DB mydb = new My_DB();
        Courses course = new Courses();
        Score score = new Score();
        

        private void bt_Print_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;

            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region one
                string fileName = "Export_Student.docx";
                var doc = DocX.Create(fileName);
                #endregion

                #region two
                //string title = "REPORT RESULT";
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

                //Insert text  
                //doc.InsertParagraph(textParagraph, false, textParagraphFormat);
                #endregion
                datve.AllowUserToAddRows = false;
                #region four
                doc.InsertParagraph();
                //Create Table
                //var listPlayer = CreateInitData();
                int tempq = datve.ColumnCount;
                int temp = datve.RowCount;
                Table t = doc.AddTable(temp + 1, tempq);
                t.Alignment = Alignment.center;
                t.Design = TableDesign.ColorfulList;
                // Fill cells by adding text.  
                // First row
                t.Rows[0].Cells[0].Paragraphs.First().Append("ID");
                t.Rows[0].Cells[1].Paragraphs.First().Append("First Name");
                t.Rows[0].Cells[2].Paragraphs.First().Append("Last Name");
                t.Rows[0].Cells[3].Paragraphs.First().Append("Course ID");
                t.Rows[0].Cells[4].Paragraphs.First().Append("Course Name");
                t.Rows[0].Cells[5].Paragraphs.First().Append("Score");

                temp = datve.RowCount;


                for (int i = 0; i < temp; i++)
                {
                    for (int kt = 0; kt < tempq; kt++)
                    {
                        t.Rows[i + 1].Cells[kt].Paragraphs.First().Append(datve.Rows[i].Cells[kt].Value.ToString());
                    }
                }
                doc.InsertTable(t);
                #endregion
                #region part of one
                doc.Save();
                Process.Start("WINWORD.EXE", fileName);
                #endregion
                Console.Read();
            }
            catch(Exception exp)
            {
                MessageBox.Show("0x0002", "Information");
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
