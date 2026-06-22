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
            this.btnLogout = new System.Windows.Forms.Button();
            this.grpCurrentStatus = new System.Windows.Forms.GroupBox();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.grpMissingDocuments = new System.Windows.Forms.GroupBox();
            this.lstMissingDocuments = new System.Windows.Forms.ListBox();
            this.grpInterviewSchedule = new System.Windows.Forms.GroupBox();
            this.lblInterviewSchedule = new System.Windows.Forms.Label();
            this.grpRecentUpdates = new System.Windows.Forms.GroupBox();
            this.lstRecentUpdates = new System.Windows.Forms.ListBox();
            this.grpCurrentStatus.SuspendLayout();
            this.grpMissingDocuments.SuspendLayout();
            this.grpInterviewSchedule.SuspendLayout();
            this.grpRecentUpdates.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Applicant Dashboard";
            // 
            // btnMyProfile
            // 
            this.btnMyProfile.Location = new System.Drawing.Point(12, 53);
            this.btnMyProfile.Name = "btnMyProfile";
            this.btnMyProfile.Size = new System.Drawing.Size(106, 23);
            this.btnMyProfile.TabIndex = 1;
            this.btnMyProfile.Text = "My Profile";
            this.btnMyProfile.UseVisualStyleBackColor = true;
            this.btnMyProfile.Click += new System.EventHandler(this.btnMyProfile_Click_1);
            // 
            // btnJobVacancies
            // 
            this.btnJobVacancies.Location = new System.Drawing.Point(11, 82);
            this.btnJobVacancies.Name = "btnJobVacancies";
            this.btnJobVacancies.Size = new System.Drawing.Size(106, 23);
            this.btnJobVacancies.TabIndex = 2;
            this.btnJobVacancies.Text = "Job Vacancies";
            this.btnJobVacancies.UseVisualStyleBackColor = true;
            this.btnJobVacancies.Click += new System.EventHandler(this.btnJobVacancies_Click_1);
            // 
            // btnMyApplication
            // 
            this.btnMyApplication.Location = new System.Drawing.Point(11, 111);
            this.btnMyApplication.Name = "btnMyApplication";
            this.btnMyApplication.Size = new System.Drawing.Size(106, 23);
            this.btnMyApplication.TabIndex = 3;
            this.btnMyApplication.Text = "My Application";
            this.btnMyApplication.UseVisualStyleBackColor = true;
            this.btnMyApplication.Click += new System.EventHandler(this.btnMyApplication_Click);
            // 
            // btnMyDocuments
            // 
            this.btnMyDocuments.AllowDrop = true;
            this.btnMyDocuments.Location = new System.Drawing.Point(11, 140);
            this.btnMyDocuments.Name = "btnMyDocuments";
            this.btnMyDocuments.Size = new System.Drawing.Size(106, 23);
            this.btnMyDocuments.TabIndex = 4;
            this.btnMyDocuments.Text = "My Documents";
            this.btnMyDocuments.UseVisualStyleBackColor = true;
            this.btnMyDocuments.Click += new System.EventHandler(this.btnMyDocuments_Click);
            // 
            // btnApplicationStatus
            // 
            this.btnApplicationStatus.Location = new System.Drawing.Point(12, 169);
            this.btnApplicationStatus.Name = "btnApplicationStatus";
            this.btnApplicationStatus.Size = new System.Drawing.Size(106, 23);
            this.btnApplicationStatus.TabIndex = 5;
            this.btnApplicationStatus.Text = "Application Status";
            this.btnApplicationStatus.UseVisualStyleBackColor = true;
            this.btnApplicationStatus.Click += new System.EventHandler(this.btnApplicationStatus_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 243);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(105, 21);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // grpCurrentStatus
            // 
            this.grpCurrentStatus.Controls.Add(this.lblCurrentStatus);
            this.grpCurrentStatus.Location = new System.Drawing.Point(160, 53);
            this.grpCurrentStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpCurrentStatus.Name = "grpCurrentStatus";
            this.grpCurrentStatus.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpCurrentStatus.Size = new System.Drawing.Size(191, 94);
            this.grpCurrentStatus.TabIndex = 11;
            this.grpCurrentStatus.TabStop = false;
            this.grpCurrentStatus.Text = "Current Status\n";
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Location = new System.Drawing.Point(4, 14);
            this.lblCurrentStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(74, 13);
            this.lblCurrentStatus.TabIndex = 0;
            this.lblCurrentStatus.Text = "Current Status";
            // 
            // grpMissingDocuments
            // 
            this.grpMissingDocuments.Controls.Add(this.lstMissingDocuments);
            this.grpMissingDocuments.Location = new System.Drawing.Point(160, 156);
            this.grpMissingDocuments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpMissingDocuments.Name = "grpMissingDocuments";
            this.grpMissingDocuments.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpMissingDocuments.Size = new System.Drawing.Size(191, 108);
            this.grpMissingDocuments.TabIndex = 12;
            this.grpMissingDocuments.TabStop = false;
            this.grpMissingDocuments.Text = "Missing Documents";
            this.grpMissingDocuments.Enter += new System.EventHandler(this.grpMissingDocuments_Enter);
            // 
            // lstMissingDocuments
            // 
            this.lstMissingDocuments.FormattingEnabled = true;
            this.lstMissingDocuments.Location = new System.Drawing.Point(7, 16);
            this.lstMissingDocuments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstMissingDocuments.Name = "lstMissingDocuments";
            this.lstMissingDocuments.Size = new System.Drawing.Size(170, 82);
            this.lstMissingDocuments.TabIndex = 3;
            // 
            // grpInterviewSchedule
            // 
            this.grpInterviewSchedule.Controls.Add(this.lblInterviewSchedule);
            this.grpInterviewSchedule.Location = new System.Drawing.Point(369, 53);
            this.grpInterviewSchedule.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpInterviewSchedule.Name = "grpInterviewSchedule";
            this.grpInterviewSchedule.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpInterviewSchedule.Size = new System.Drawing.Size(211, 94);
            this.grpInterviewSchedule.TabIndex = 12;
            this.grpInterviewSchedule.TabStop = false;
            this.grpInterviewSchedule.Text = "Interview Schedule";
            this.grpInterviewSchedule.Enter += new System.EventHandler(this.grpInterviewSchedule_Enter);
            // 
            // lblInterviewSchedule
            // 
            this.lblInterviewSchedule.AutoSize = true;
            this.lblInterviewSchedule.Location = new System.Drawing.Point(4, 21);
            this.lblInterviewSchedule.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInterviewSchedule.Name = "lblInterviewSchedule";
            this.lblInterviewSchedule.Size = new System.Drawing.Size(98, 13);
            this.lblInterviewSchedule.TabIndex = 1;
            this.lblInterviewSchedule.Text = "Interview Schedule";
            // 
            // grpRecentUpdates
            // 
            this.grpRecentUpdates.Controls.Add(this.lstRecentUpdates);
            this.grpRecentUpdates.Location = new System.Drawing.Point(369, 156);
            this.grpRecentUpdates.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpRecentUpdates.Name = "grpRecentUpdates";
            this.grpRecentUpdates.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpRecentUpdates.Size = new System.Drawing.Size(211, 108);
            this.grpRecentUpdates.TabIndex = 12;
            this.grpRecentUpdates.TabStop = false;
            this.grpRecentUpdates.Text = "Recent Updates";
            // 
            // lstRecentUpdates
            // 
            this.lstRecentUpdates.FormattingEnabled = true;
            this.lstRecentUpdates.Location = new System.Drawing.Point(7, 16);
            this.lstRecentUpdates.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstRecentUpdates.Name = "lstRecentUpdates";
            this.lstRecentUpdates.Size = new System.Drawing.Size(187, 82);
            this.lstRecentUpdates.TabIndex = 2;
            // 
            // frmApplicantDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 272);
            this.Controls.Add(this.grpMissingDocuments);
            this.Controls.Add(this.grpInterviewSchedule);
            this.Controls.Add(this.grpRecentUpdates);
            this.Controls.Add(this.grpCurrentStatus);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnApplicationStatus);
            this.Controls.Add(this.btnMyDocuments);
            this.Controls.Add(this.btnMyApplication);
            this.Controls.Add(this.btnJobVacancies);
            this.Controls.Add(this.btnMyProfile);
            this.Controls.Add(this.label1);
            this.Name = "frmApplicantDashboard";
            this.Text = "Applicant Dashboard";
            this.Load += new System.EventHandler(this.frmApplicantDashboard_Load);
            this.grpCurrentStatus.ResumeLayout(false);
            this.grpCurrentStatus.PerformLayout();
            this.grpMissingDocuments.ResumeLayout(false);
            this.grpInterviewSchedule.ResumeLayout(false);
            this.grpInterviewSchedule.PerformLayout();
            this.grpRecentUpdates.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.GroupBox grpCurrentStatus;
        private System.Windows.Forms.GroupBox grpMissingDocuments;
        private System.Windows.Forms.GroupBox grpInterviewSchedule;
        private System.Windows.Forms.GroupBox grpRecentUpdates;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.ListBox lstMissingDocuments;
        private System.Windows.Forms.Label lblInterviewSchedule;
        private System.Windows.Forms.ListBox lstRecentUpdates;
    }
}