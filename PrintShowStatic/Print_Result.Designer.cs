
namespace project_10_3
{
    partial class Print_Result
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print_Result));
            this.datve = new System.Windows.Forms.DataGridView();
            this.bt_Print = new System.Windows.Forms.Button();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datve)).BeginInit();
            this.SuspendLayout();
            // 
            // datve
            // 
            this.datve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datve.Location = new System.Drawing.Point(23, 97);
            this.datve.Name = "datve";
            this.datve.RowHeadersWidth = 51;
            this.datve.RowTemplate.Height = 24;
            this.datve.Size = new System.Drawing.Size(1139, 455);
            this.datve.TabIndex = 50;
            // 
            // bt_Print
            // 
            this.bt_Print.BackColor = System.Drawing.Color.Tomato;
            this.bt_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Print.Location = new System.Drawing.Point(530, 572);
            this.bt_Print.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_Print.Name = "bt_Print";
            this.bt_Print.Size = new System.Drawing.Size(184, 49);
            this.bt_Print.TabIndex = 49;
            this.bt_Print.Text = "Print";
            this.bt_Print.UseVisualStyleBackColor = false;
            this.bt_Print.Click += new System.EventHandler(this.bt_Print_Click);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.BackColor = System.Drawing.Color.Tomato;
            this.bt_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Cancel.Location = new System.Drawing.Point(930, 572);
            this.bt_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(184, 49);
            this.bt_Cancel.TabIndex = 48;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.UseVisualStyleBackColor = false;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(377, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(381, 55);
            this.label2.TabIndex = 47;
            this.label2.Text = "Student Result: ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tomato;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(138, 572);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 49);
            this.button1.TabIndex = 51;
            this.button1.Text = "Save to Word";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Print_Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1217, 632);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datve);
            this.Controls.Add(this.bt_Print);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.label2);
            this.Name = "Print_Result";
            this.Text = "Print_Result";
            this.Load += new System.EventHandler(this.Print_Result_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datve)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_Print;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView datve;
    }
}