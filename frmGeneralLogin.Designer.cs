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
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Applicant = new System.Windows.Forms.Button();
            this.btn_HumanResources = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "General Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Login as:";
            // 
            // btn_Applicant
            // 
            this.btn_Applicant.Location = new System.Drawing.Point(55, 55);
            this.btn_Applicant.Name = "btn_Applicant";
            this.btn_Applicant.Size = new System.Drawing.Size(108, 23);
            this.btn_Applicant.TabIndex = 4;
            this.btn_Applicant.Text = "Applicant";
            this.btn_Applicant.UseVisualStyleBackColor = true;
            this.btn_Applicant.Click += new System.EventHandler(this.btn_Applicant_Click);
            // 
            // btn_HumanResources
            // 
            this.btn_HumanResources.Location = new System.Drawing.Point(55, 84);
            this.btn_HumanResources.Name = "btn_HumanResources";
            this.btn_HumanResources.Size = new System.Drawing.Size(108, 23);
            this.btn_HumanResources.TabIndex = 5;
            this.btn_HumanResources.Text = "Human Resources";
            this.btn_HumanResources.UseVisualStyleBackColor = true;
            this.btn_HumanResources.Click += new System.EventHandler(this.btn_HumanResources_Click);
            // 
            // frmGeneralLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 117);
            this.Controls.Add(this.btn_HumanResources);
            this.Controls.Add(this.btn_Applicant);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmGeneralLogin";
            this.Text = "General Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Applicant;
        private System.Windows.Forms.Button btn_HumanResources;
    }
}