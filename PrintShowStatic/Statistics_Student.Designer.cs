
namespace project_10_3
{
    partial class Statistics_Student
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics_Student));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelfml = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelml = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labeltt = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(532, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 75);
            this.button2.TabIndex = 9;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(532, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 75);
            this.button1.TabIndex = 8;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel3.Controls.Add(this.labelfml);
            this.panel3.Location = new System.Drawing.Point(261, 264);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(211, 188);
            this.panel3.TabIndex = 7;
            // 
            // labelfml
            // 
            this.labelfml.AutoSize = true;
            this.labelfml.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelfml.Location = new System.Drawing.Point(7, 69);
            this.labelfml.Name = "labelfml";
            this.labelfml.Size = new System.Drawing.Size(193, 34);
            this.labelfml.TabIndex = 2;
            this.labelfml.Text = "Female : 50%";
            this.labelfml.MouseEnter += new System.EventHandler(this.labelfml_MouseEnter);
            this.labelfml.MouseLeave += new System.EventHandler(this.labelfml_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SpringGreen;
            this.panel2.Controls.Add(this.labelml);
            this.panel2.Location = new System.Drawing.Point(49, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(213, 188);
            this.panel2.TabIndex = 6;
            // 
            // labelml
            // 
            this.labelml.AutoSize = true;
            this.labelml.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelml.Location = new System.Drawing.Point(13, 69);
            this.labelml.Name = "labelml";
            this.labelml.Size = new System.Drawing.Size(160, 34);
            this.labelml.TabIndex = 1;
            this.labelml.Text = "Male : 50%";
            this.labelml.MouseEnter += new System.EventHandler(this.labelml_MouseEnter);
            this.labelml.MouseLeave += new System.EventHandler(this.labelml_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Violet;
            this.panel1.Controls.Add(this.labeltt);
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(49, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 197);
            this.panel1.TabIndex = 5;
            // 
            // labeltt
            // 
            this.labeltt.AutoSize = true;
            this.labeltt.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltt.Location = new System.Drawing.Point(67, 78);
            this.labeltt.Name = "labeltt";
            this.labeltt.Size = new System.Drawing.Size(263, 34);
            this.labeltt.TabIndex = 0;
            this.labeltt.Text = "Total Student : 100";
            this.labeltt.Click += new System.EventHandler(this.labeltt_Click);
            this.labeltt.MouseEnter += new System.EventHandler(this.labeltt_MouseEnter);
            this.labeltt.MouseLeave += new System.EventHandler(this.labeltt_MouseLeave);
            // 
            // chart1
            // 
            this.chart1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomLeft;
            this.chart1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chart1.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(785, 41);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "s1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(378, 457);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            title1.Name = "ID";
            title2.Name = "Label";
            title3.Name = "Avera";
            this.chart1.Titles.Add(title1);
            this.chart1.Titles.Add(title2);
            this.chart1.Titles.Add(title3);
            // 
            // Statistics_Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1175, 523);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Statistics_Student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistic_Student";
            this.Load += new System.EventHandler(this.Static_Student_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelfml;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelml;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labeltt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}