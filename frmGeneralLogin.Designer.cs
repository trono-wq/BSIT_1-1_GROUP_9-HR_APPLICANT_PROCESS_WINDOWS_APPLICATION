namespace COMP_003_CAPSTONE
{
    partial class frmGeneralLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBox1 = new System.Windows.Forms.Button();
            this.cmbBox2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "General Login";
            // 
            // cmbBox1
            // 
            this.cmbBox1.Location = new System.Drawing.Point(49, 54);
            this.cmbBox1.Name = "cmbBox1";
            this.cmbBox1.Size = new System.Drawing.Size(108, 23);
            this.cmbBox1.TabIndex = 1;
            this.cmbBox1.Text = "Applicant";
            this.cmbBox1.UseVisualStyleBackColor = true;
            this.cmbBox1.Click += new System.EventHandler(this.cmbBox1_Click);
            // 
            // cmbBox2
            // 
            this.cmbBox2.Location = new System.Drawing.Point(49, 83);
            this.cmbBox2.Name = "cmbBox2";
            this.cmbBox2.Size = new System.Drawing.Size(108, 23);
            this.cmbBox2.TabIndex = 2;
            this.cmbBox2.Text = "Human Resources";
            this.cmbBox2.UseVisualStyleBackColor = true;
            this.cmbBox2.Click += new System.EventHandler(this.cmbBox2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Login as:";
            // 
            // frmGeneralLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 117);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBox2);
            this.Controls.Add(this.cmbBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmGeneralLogin";
            this.Text = "frmGeneralLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmbBox1;
        private System.Windows.Forms.Button cmbBox2;
        private System.Windows.Forms.Label label2;
    }
}