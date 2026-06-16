namespace COMP_003_CAPSTONE
{
    partial class frmApplicationStatus
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblDraft = new System.Windows.Forms.Label();
            this.lblSubmitted = new System.Windows.Forms.Label();
            this.lblUnderReview = new System.Windows.Forms.Label();
            this.Shortlisted = new System.Windows.Forms.Label();
            this.lblForInterview = new System.Windows.Forms.Label();
            this.lblForAssessment = new System.Windows.Forms.Label();
            this.lblForFinalReview = new System.Windows.Forms.Label();
            this.lblAccepted = new System.Windows.Forms.Label();
            this.lblRejected = new System.Windows.Forms.Label();
            this.lblWithdrawn = new System.Windows.Forms.Label();
            this.grpHRRemarks = new System.Windows.Forms.GroupBox();
            this.lblMeets = new System.Windows.Forms.Label();
            this.lblInterviewSchedule = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.grpHRRemarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(295, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(295, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Current Application Status     ";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(23, 632);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 33);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDraft
            // 
            this.lblDraft.AutoSize = true;
            this.lblDraft.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDraft.Location = new System.Drawing.Point(16, 53);
            this.lblDraft.Name = "lblDraft";
            this.lblDraft.Size = new System.Drawing.Size(65, 20);
            this.lblDraft.TabIndex = 4;
            this.lblDraft.Text = "✔ Draft";
            // 
            // lblSubmitted
            // 
            this.lblSubmitted.AutoSize = true;
            this.lblSubmitted.Location = new System.Drawing.Point(16, 83);
            this.lblSubmitted.Name = "lblSubmitted";
            this.lblSubmitted.Size = new System.Drawing.Size(102, 20);
            this.lblSubmitted.TabIndex = 5;
            this.lblSubmitted.Text = "✔ Submitted";
            // 
            // lblUnderReview
            // 
            this.lblUnderReview.AutoSize = true;
            this.lblUnderReview.Location = new System.Drawing.Point(16, 117);
            this.lblUnderReview.Name = "lblUnderReview";
            this.lblUnderReview.Size = new System.Drawing.Size(122, 20);
            this.lblUnderReview.TabIndex = 6;
            this.lblUnderReview.Text = "○ Under Review";
            // 
            // Shortlisted
            // 
            this.Shortlisted.AutoSize = true;
            this.Shortlisted.Location = new System.Drawing.Point(16, 149);
            this.Shortlisted.Name = "Shortlisted";
            this.Shortlisted.Size = new System.Drawing.Size(99, 20);
            this.Shortlisted.TabIndex = 7;
            this.Shortlisted.Text = "○ Shortlisted";
            // 
            // lblForInterview
            // 
            this.lblForInterview.AutoSize = true;
            this.lblForInterview.Location = new System.Drawing.Point(16, 182);
            this.lblForInterview.Name = "lblForInterview";
            this.lblForInterview.Size = new System.Drawing.Size(114, 20);
            this.lblForInterview.TabIndex = 8;
            this.lblForInterview.Text = "○ For Interview";
            // 
            // lblForAssessment
            // 
            this.lblForAssessment.AutoSize = true;
            this.lblForAssessment.Location = new System.Drawing.Point(16, 215);
            this.lblForAssessment.Name = "lblForAssessment";
            this.lblForAssessment.Size = new System.Drawing.Size(139, 20);
            this.lblForAssessment.TabIndex = 9;
            this.lblForAssessment.Text = "○ For Assessment";
            // 
            // lblForFinalReview
            // 
            this.lblForFinalReview.AutoSize = true;
            this.lblForFinalReview.Location = new System.Drawing.Point(16, 250);
            this.lblForFinalReview.Name = "lblForFinalReview";
            this.lblForFinalReview.Size = new System.Drawing.Size(140, 20);
            this.lblForFinalReview.TabIndex = 10;
            this.lblForFinalReview.Text = "○ For Final Review";
            // 
            // lblAccepted
            // 
            this.lblAccepted.AutoSize = true;
            this.lblAccepted.Location = new System.Drawing.Point(19, 285);
            this.lblAccepted.Name = "lblAccepted";
            this.lblAccepted.Size = new System.Drawing.Size(91, 20);
            this.lblAccepted.TabIndex = 11;
            this.lblAccepted.Text = "○ Accepted";
            // 
            // lblRejected
            // 
            this.lblRejected.AutoSize = true;
            this.lblRejected.Location = new System.Drawing.Point(19, 322);
            this.lblRejected.Name = "lblRejected";
            this.lblRejected.Size = new System.Drawing.Size(87, 20);
            this.lblRejected.TabIndex = 12;
            this.lblRejected.Text = "○ Rejected";
            // 
            // lblWithdrawn
            // 
            this.lblWithdrawn.AutoSize = true;
            this.lblWithdrawn.Location = new System.Drawing.Point(20, 360);
            this.lblWithdrawn.Name = "lblWithdrawn";
            this.lblWithdrawn.Size = new System.Drawing.Size(98, 20);
            this.lblWithdrawn.TabIndex = 13;
            this.lblWithdrawn.Text = "○ Withdrawn";
            // 
            // grpHRRemarks
            // 
            this.grpHRRemarks.Controls.Add(this.lblMeets);
            this.grpHRRemarks.Location = new System.Drawing.Point(20, 413);
            this.grpHRRemarks.Name = "grpHRRemarks";
            this.grpHRRemarks.Size = new System.Drawing.Size(360, 74);
            this.grpHRRemarks.TabIndex = 14;
            this.grpHRRemarks.TabStop = false;
            this.grpHRRemarks.Text = "HRRemarks";
            // 
            // lblMeets
            // 
            this.lblMeets.AutoSize = true;
            this.lblMeets.Location = new System.Drawing.Point(35, 35);
            this.lblMeets.Name = "lblMeets";
            this.lblMeets.Size = new System.Drawing.Size(294, 20);
            this.lblMeets.TabIndex = 0;
            this.lblMeets.Text = "Applicant meets minimum qualifications. ";
            // 
            // lblInterviewSchedule
            // 
            this.lblInterviewSchedule.AutoSize = true;
            this.lblInterviewSchedule.Location = new System.Drawing.Point(20, 506);
            this.lblInterviewSchedule.Name = "lblInterviewSchedule";
            this.lblInterviewSchedule.Size = new System.Drawing.Size(143, 20);
            this.lblInterviewSchedule.TabIndex = 1;
            this.lblInterviewSchedule.Text = "Interview Schedule";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 536);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(153, 20);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date: June 17, 2026";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(19, 565);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(119, 20);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "Time: 10:00 AM";
            this.lblTime.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(19, 594);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(102, 20);
            this.lblMode.TabIndex = 4;
            this.lblMode.Text = "Mode: Online";
            // 
            // frmApplicationStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 677);
            this.Controls.Add(this.lblInterviewSchedule);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.grpHRRemarks);
            this.Controls.Add(this.lblWithdrawn);
            this.Controls.Add(this.lblRejected);
            this.Controls.Add(this.lblAccepted);
            this.Controls.Add(this.lblForFinalReview);
            this.Controls.Add(this.lblForAssessment);
            this.Controls.Add(this.lblForInterview);
            this.Controls.Add(this.Shortlisted);
            this.Controls.Add(this.lblUnderReview);
            this.Controls.Add(this.lblSubmitted);
            this.Controls.Add(this.lblDraft);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmApplicationStatus";
            this.Text = "frmMyApplicationStatus";
            this.Load += new System.EventHandler(this.frmApplicationStatus_Load);
            this.grpHRRemarks.ResumeLayout(false);
            this.grpHRRemarks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblDraft;
        private System.Windows.Forms.Label lblSubmitted;
        private System.Windows.Forms.Label lblUnderReview;
        private System.Windows.Forms.Label Shortlisted;
        private System.Windows.Forms.Label lblForInterview;
        private System.Windows.Forms.Label lblForAssessment;
        private System.Windows.Forms.Label lblForFinalReview;
        private System.Windows.Forms.Label lblAccepted;
        private System.Windows.Forms.Label lblRejected;
        private System.Windows.Forms.Label lblWithdrawn;
        private System.Windows.Forms.GroupBox grpHRRemarks;
        private System.Windows.Forms.Label lblInterviewSchedule;
        private System.Windows.Forms.Label lblMeets;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblMode;
    }
}