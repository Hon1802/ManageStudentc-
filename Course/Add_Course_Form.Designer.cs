
namespace project_10_3
{
    partial class Add_Course_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Course_Form));
            this.lb1 = new System.Windows.Forms.Label();
            this.txtlable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.noh = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.desbox = new System.Windows.Forms.TextBox();
            this.idc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.noh)).BeginInit();
            this.SuspendLayout();
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.BackColor = System.Drawing.Color.Transparent;
            this.lb1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.ForeColor = System.Drawing.Color.Black;
            this.lb1.Location = new System.Drawing.Point(102, 125);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(76, 28);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "Label";
            // 
            // txtlable
            // 
            this.txtlable.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlable.Location = new System.Drawing.Point(376, 125);
            this.txtlable.Name = "txtlable";
            this.txtlable.Size = new System.Drawing.Size(320, 30);
            this.txtlable.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(102, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number Of Hours";
            // 
            // noh
            // 
            this.noh.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noh.Location = new System.Drawing.Point(376, 186);
            this.noh.Name = "noh";
            this.noh.Size = new System.Drawing.Size(320, 32);
            this.noh.TabIndex = 3;
            this.noh.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.noh.ValueChanged += new System.EventHandler(this.noh_ValueChanged);
            this.noh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.noh_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(102, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descriptions";
            // 
            // desbox
            // 
            this.desbox.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desbox.Location = new System.Drawing.Point(376, 255);
            this.desbox.Multiline = true;
            this.desbox.Name = "desbox";
            this.desbox.Size = new System.Drawing.Size(320, 170);
            this.desbox.TabIndex = 12;
            // 
            // idc
            // 
            this.idc.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idc.Location = new System.Drawing.Point(376, 71);
            this.idc.Name = "idc";
            this.idc.Size = new System.Drawing.Size(320, 30);
            this.idc.TabIndex = 14;
            this.idc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.noh_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(102, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 28);
            this.label3.TabIndex = 13;
            this.label3.Text = "ID Course";
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Red;
            this.add.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.ForeColor = System.Drawing.Color.White;
            this.add.Location = new System.Drawing.Point(559, 463);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(137, 70);
            this.add.TabIndex = 15;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Snow;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(376, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 70);
            this.button1.TabIndex = 16;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Add_Course_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(830, 604);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.add);
            this.Controls.Add(this.idc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.desbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.noh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtlable);
            this.Controls.Add(this.lb1);
            this.Name = "Add_Course_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_Course_Form";
            this.Load += new System.EventHandler(this.Add_Course_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.noh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TextBox txtlable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown noh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox desbox;
        private System.Windows.Forms.TextBox idc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button button1;
    }
}