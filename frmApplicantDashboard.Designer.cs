namespace COMP_003_CAPSTONE
{
    partial class frmApplicantDashboard
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
            this.btnMyProfile = new System.Windows.Forms.Button();
            this.btnJobVacancies = new System.Windows.Forms.Button();
            this.btnMyApplication = new System.Windows.Forms.Button();
            this.btnMyDocuments = new System.Windows.Forms.Button();
            this.btnApplicationStatus = new System.Windows.Forms.Button();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblMissingDocuments = new System.Windows.Forms.Label();
            this.lblInterviewSchedule = new System.Windows.Forms.Label();
            this.lblRecentUpdates = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(452, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Applicant Dashboard";
            // 
            // btnMyProfile
            // 
            this.btnMyProfile.Location = new System.Drawing.Point(139, 230);
            this.btnMyProfile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMyProfile.Name = "btnMyProfile";
            this.btnMyProfile.Size = new System.Drawing.Size(252, 35);
            this.btnMyProfile.TabIndex = 1;
            this.btnMyProfile.Text = "My Profile";
            this.btnMyProfile.UseVisualStyleBackColor = true;
            this.btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click_1);
            // 
            // btnJobVacancies
            // 
            this.btnJobVacancies.Location = new System.Drawing.Point(139, 275);
            this.btnJobVacancies.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnJobVacancies.Name = "btnJobVacancies";
            this.btnJobVacancies.Size = new System.Drawing.Size(252, 35);
            this.btnJobVacancies.TabIndex = 2;
            this.btnJobVacancies.Text = "Job Vacancies";
            this.btnJobVacancies.UseVisualStyleBackColor = true;
            this.btnJobVacancies.Click += new System.EventHandler(this.btnJobVacancies_Click_1);
            // 
            // btnMyApplication
            // 
            this.btnMyApplication.Location = new System.Drawing.Point(139, 320);
            this.btnMyApplication.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMyApplication.Name = "btnMyApplication";
            this.btnMyApplication.Size = new System.Drawing.Size(252, 35);
            this.btnMyApplication.TabIndex = 3;
            this.btnMyApplication.Text = "My Application";
            this.btnMyApplication.UseVisualStyleBackColor = true;
            this.btnMyApplication.Click += new System.EventHandler(this.btnMyApplication_Click);
            // 
            // btnMyDocuments
            // 
            this.btnMyDocuments.AllowDrop = true;
            this.btnMyDocuments.Location = new System.Drawing.Point(139, 365);
            this.btnMyDocuments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMyDocuments.Name = "btnMyDocuments";
            this.btnMyDocuments.Size = new System.Drawing.Size(252, 35);
            this.btnMyDocuments.TabIndex = 4;
            this.btnMyDocuments.Text = "My Documents";
            this.btnMyDocuments.UseVisualStyleBackColor = true;
            this.btnMyDocuments.Click += new System.EventHandler(this.btnMyDocuments_Click);
            // 
            // btnApplicationStatus
            // 
            this.btnApplicationStatus.Location = new System.Drawing.Point(139, 410);
            this.btnApplicationStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnApplicationStatus.Name = "btnApplicationStatus";
            this.btnApplicationStatus.Size = new System.Drawing.Size(252, 35);
            this.btnApplicationStatus.TabIndex = 5;
            this.btnApplicationStatus.Text = "Application Status";
            this.btnApplicationStatus.UseVisualStyleBackColor = true;
            this.btnApplicationStatus.Click += new System.EventHandler(this.btnApplicationStatus_Click);
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Location = new System.Drawing.Point(670, 230);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(194, 20);
            this.lblCurrentStatus.TabIndex = 6;
            this.lblCurrentStatus.Text = "Current Status: Submitted";
            // 
            // lblMissingDocuments
            // 
            this.lblMissingDocuments.AutoSize = true;
            this.lblMissingDocuments.Location = new System.Drawing.Point(670, 264);
            this.lblMissingDocuments.Name = "lblMissingDocuments";
            this.lblMissingDocuments.Size = new System.Drawing.Size(216, 20);
            this.lblMissingDocuments.TabIndex = 7;
            this.lblMissingDocuments.Text = "Missing Documents: Resume\n";
            // 
            // lblInterviewSchedule
            // 
            this.lblInterviewSchedule.AutoSize = true;
            this.lblInterviewSchedule.Location = new System.Drawing.Point(670, 315);
            this.lblInterviewSchedule.Name = "lblInterviewSchedule";
            this.lblInterviewSchedule.Size = new System.Drawing.Size(173, 40);
            this.lblInterviewSchedule.TabIndex = 8;
            this.lblInterviewSchedule.Text = "Interview Schedule:\nJune 20, 2026 9:00 AM";
            // 
            // lblRecentUpdates
            // 
            this.lblRecentUpdates.AutoSize = true;
            this.lblRecentUpdates.Location = new System.Drawing.Point(670, 382);
            this.lblRecentUpdates.Name = "lblRecentUpdates";
            this.lblRecentUpdates.Size = new System.Drawing.Size(130, 40);
            this.lblRecentUpdates.TabIndex = 9;
            this.lblRecentUpdates.Text = "Recent Updates:\nUnder Review";
            // 
            // frmApplicantDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.lblRecentUpdates);
            this.Controls.Add(this.lblInterviewSchedule);
            this.Controls.Add(this.lblMissingDocuments);
            this.Controls.Add(this.lblCurrentStatus);
            this.Controls.Add(this.btnApplicationStatus);
            this.Controls.Add(this.btnMyDocuments);
            this.Controls.Add(this.btnMyApplication);
            this.Controls.Add(this.btnJobVacancies);
            this.Controls.Add(this.btnMyProfile);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmApplicantDashboard";
            this.Text = "frmApplicantDashboard";
            this.Load += new System.EventHandler(this.frmApplicantDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMyProfile;
        private System.Windows.Forms.Button btnJobVacancies;
        private System.Windows.Forms.Button btnMyApplication;
        private System.Windows.Forms.Button btnMyDocuments;
        private System.Windows.Forms.Button btnApplicationStatus;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label lblMissingDocuments;
        private System.Windows.Forms.Label lblInterviewSchedule;
        private System.Windows.Forms.Label lblRecentUpdates;
    }
}