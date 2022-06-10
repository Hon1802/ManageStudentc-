
namespace project_10_3
{
    partial class Print_Student
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print_Student));
            this.gr1 = new System.Windows.Forms.GroupBox();
            this.Go = new System.Windows.Forms.Button();
            this.gr2 = new System.Windows.Forms.GroupBox();
            this.dp2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dp1 = new System.Windows.Forms.DateTimePicker();
            this.no = new System.Windows.Forms.RadioButton();
            this.yes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.female = new System.Windows.Forms.RadioButton();
            this.male = new System.Windows.Forms.RadioButton();
            this.all = new System.Windows.Forms.RadioButton();
            this.btp = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.gr1.SuspendLayout();
            this.gr2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gr1
            // 
            this.gr1.BackColor = System.Drawing.Color.Transparent;
            this.gr1.Controls.Add(this.Go);
            this.gr1.Controls.Add(this.gr2);
            this.gr1.Controls.Add(this.female);
            this.gr1.Controls.Add(this.male);
            this.gr1.Controls.Add(this.all);
            this.gr1.Location = new System.Drawing.Point(12, 12);
            this.gr1.Name = "gr1";
            this.gr1.Size = new System.Drawing.Size(1175, 107);
            this.gr1.TabIndex = 5;
            this.gr1.TabStop = false;
            this.gr1.Enter += new System.EventHandler(this.gr1_Enter);
            // 
            // Go
            // 
            this.Go.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Go.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Go.ForeColor = System.Drawing.Color.Red;
            this.Go.Location = new System.Drawing.Point(953, 21);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(173, 76);
            this.Go.TabIndex = 4;
            this.Go.Text = "GO";
            this.Go.UseVisualStyleBackColor = false;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // gr2
            // 
            this.gr2.Controls.Add(this.dp2);
            this.gr2.Controls.Add(this.label2);
            this.gr2.Controls.Add(this.dp1);
            this.gr2.Controls.Add(this.no);
            this.gr2.Controls.Add(this.yes);
            this.gr2.Controls.Add(this.label1);
            this.gr2.Controls.Add(this.lb1);
            this.gr2.Location = new System.Drawing.Point(327, 9);
            this.gr2.Name = "gr2";
            this.gr2.Size = new System.Drawing.Size(620, 92);
            this.gr2.TabIndex = 3;
            this.gr2.TabStop = false;
            this.gr2.Enter += new System.EventHandler(this.gr2_Enter);
            // 
            // dp2
            // 
            this.dp2.CustomFormat = "yyyy-MM-dd";
            this.dp2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp2.Location = new System.Drawing.Point(449, 53);
            this.dp2.Name = "dp2";
            this.dp2.Size = new System.Drawing.Size(155, 28);
            this.dp2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(376, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "AND";
            // 
            // dp1
            // 
            this.dp1.CustomFormat = "yyyy-MM-dd";
            this.dp1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dp1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp1.Location = new System.Drawing.Point(222, 53);
            this.dp1.Name = "dp1";
            this.dp1.Size = new System.Drawing.Size(148, 28);
            this.dp1.TabIndex = 6;
            // 
            // no
            // 
            this.no.AutoSize = true;
            this.no.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.no.ForeColor = System.Drawing.Color.White;
            this.no.Location = new System.Drawing.Point(449, 16);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(63, 27);
            this.no.TabIndex = 5;
            this.no.TabStop = true;
            this.no.Text = "NO";
            this.no.UseVisualStyleBackColor = true;
            // 
            // yes
            // 
            this.yes.AutoSize = true;
            this.yes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yes.ForeColor = System.Drawing.Color.White;
            this.yes.Location = new System.Drawing.Point(233, 14);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(65, 27);
            this.yes.TabIndex = 4;
            this.yes.TabStop = true;
            this.yes.Text = "YES";
            this.yes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Birthday Between";
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.ForeColor = System.Drawing.Color.White;
            this.lb1.Location = new System.Drawing.Point(16, 18);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(169, 23);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "Use Date Range";
            // 
            // female
            // 
            this.female.AutoSize = true;
            this.female.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.female.ForeColor = System.Drawing.Color.White;
            this.female.Location = new System.Drawing.Point(199, 41);
            this.female.Name = "female";
            this.female.Size = new System.Drawing.Size(104, 27);
            this.female.TabIndex = 2;
            this.female.TabStop = true;
            this.female.Text = "FEMALE";
            this.female.UseVisualStyleBackColor = true;
            // 
            // male
            // 
            this.male.AutoSize = true;
            this.male.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.male.ForeColor = System.Drawing.Color.White;
            this.male.Location = new System.Drawing.Point(102, 41);
            this.male.Name = "male";
            this.male.Size = new System.Drawing.Size(83, 27);
            this.male.TabIndex = 1;
            this.male.TabStop = true;
            this.male.Text = "MALE";
            this.male.UseVisualStyleBackColor = true;
            // 
            // all
            // 
            this.all.AutoSize = true;
            this.all.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.all.ForeColor = System.Drawing.Color.White;
            this.all.Location = new System.Drawing.Point(19, 41);
            this.all.Name = "all";
            this.all.Size = new System.Drawing.Size(64, 27);
            this.all.TabIndex = 0;
            this.all.TabStop = true;
            this.all.Text = "ALL";
            this.all.UseVisualStyleBackColor = true;
            // 
            // btp
            // 
            this.btp.BackColor = System.Drawing.SystemColors.Highlight;
            this.btp.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btp.ForeColor = System.Drawing.Color.White;
            this.btp.Location = new System.Drawing.Point(151, 642);
            this.btp.Name = "btp";
            this.btp.Size = new System.Drawing.Size(421, 70);
            this.btp.TabIndex = 4;
            this.btp.Text = "Print To The Text";
            this.btp.UseVisualStyleBackColor = false;
            this.btp.Click += new System.EventHandler(this.btp_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1192, 502);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(627, 640);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(421, 70);
            this.button1.TabIndex = 6;
            this.button1.Text = "Print To The .docx";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Print_Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1218, 722);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gr1);
            this.Controls.Add(this.btp);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Print_Student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print_Student";
            this.Load += new System.EventHandler(this.Print_Student_Load);
            this.gr1.ResumeLayout(false);
            this.gr1.PerformLayout();
            this.gr2.ResumeLayout(false);
            this.gr2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gr1;
        private System.Windows.Forms.Button Go;
        private System.Windows.Forms.GroupBox gr2;
        private System.Windows.Forms.DateTimePicker dp2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dp1;
        private System.Windows.Forms.RadioButton no;
        private System.Windows.Forms.RadioButton yes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.RadioButton female;
        private System.Windows.Forms.RadioButton male;
        private System.Windows.Forms.RadioButton all;
        private System.Windows.Forms.Button btp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}