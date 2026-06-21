namespace COMP_003_CAPSTONE
{
    partial class frmMyProfile
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
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblCivilStatus = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.cmbCivilStatus = new System.Windows.Forms.ComboBox();
            this.txtNationality = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtSkills = new System.Windows.Forms.TextBox();
            this.txtEducation = new System.Windows.Forms.TextBox();
            this.txtExperience = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblEducational = new System.Windows.Forms.Label();
            this.lblSkills = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(247, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(229, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "APPLICANT PROFILE";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(27, 107);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(84, 20);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Full Name:";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(27, 138);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(103, 20);
            this.lblDOB.TabIndex = 2;
            this.lblDOB.Text = "Date of Birth:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(27, 177);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(67, 20);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "Gender:";
            // 
            // lblCivilStatus
            // 
            this.lblCivilStatus.AutoSize = true;
            this.lblCivilStatus.Location = new System.Drawing.Point(27, 216);
            this.lblCivilStatus.Name = "lblCivilStatus";
            this.lblCivilStatus.Size = new System.Drawing.Size(91, 20);
            this.lblCivilStatus.TabIndex = 4;
            this.lblCivilStatus.Text = "Civil Status:";
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(27, 264);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(86, 20);
            this.lblNationality.TabIndex = 5;
            this.lblNationality.Text = "Nationality:";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(27, 310);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(125, 20);
            this.lblContact.TabIndex = 6;
            this.lblContact.Text = "Contact Number";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(117, 107);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(100, 26);
            this.txtFullName.TabIndex = 7;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Location = new System.Drawing.Point(136, 139);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(200, 26);
            this.dtpDOB.TabIndex = 8;
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Prefer not say"});
            this.cmbGender.Location = new System.Drawing.Point(96, 174);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 28);
            this.cmbGender.TabIndex = 9;
            // 
            // cmbCivilStatus
            // 
            this.cmbCivilStatus.FormattingEnabled = true;
            this.cmbCivilStatus.Items.AddRange(new object[] {
            "Single",
            "Married"});
            this.cmbCivilStatus.Location = new System.Drawing.Point(117, 213);
            this.cmbCivilStatus.Name = "cmbCivilStatus";
            this.cmbCivilStatus.Size = new System.Drawing.Size(121, 28);
            this.cmbCivilStatus.TabIndex = 10;
            // 
            // txtNationality
            // 
            this.txtNationality.Location = new System.Drawing.Point(117, 264);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(100, 26);
            this.txtNationality.TabIndex = 11;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(158, 307);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(100, 26);
            this.txtContact.TabIndex = 12;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(105, 356);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 26);
            this.txtAddress.TabIndex = 13;
            // 
            // txtSkills
            // 
            this.txtSkills.Location = new System.Drawing.Point(82, 433);
            this.txtSkills.Name = "txtSkills";
            this.txtSkills.Size = new System.Drawing.Size(100, 26);
            this.txtSkills.TabIndex = 14;
            // 
            // txtEducation
            // 
            this.txtEducation.Location = new System.Drawing.Point(216, 394);
            this.txtEducation.Name = "txtEducation";
            this.txtEducation.Size = new System.Drawing.Size(100, 26);
            this.txtEducation.TabIndex = 15;
            // 
            // txtExperience
            // 
            this.txtExperience.Location = new System.Drawing.Point(166, 477);
            this.txtExperience.Multiline = true;
            this.txtExperience.Name = "txtExperience";
            this.txtExperience.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExperience.Size = new System.Drawing.Size(170, 155);
            this.txtExperience.TabIndex = 16;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(27, 356);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(72, 20);
            this.lblAddress.TabIndex = 17;
            this.lblAddress.Text = "Address:";
            // 
            // lblEducational
            // 
            this.lblEducational.AutoSize = true;
            this.lblEducational.Location = new System.Drawing.Point(27, 400);
            this.lblEducational.Name = "lblEducational";
            this.lblEducational.Size = new System.Drawing.Size(183, 20);
            this.lblEducational.TabIndex = 18;
            this.lblEducational.Text = "Educational Background";
            // 
            // lblSkills
            // 
            this.lblSkills.AutoSize = true;
            this.lblSkills.Location = new System.Drawing.Point(27, 433);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(49, 20);
            this.lblSkills.TabIndex = 19;
            this.lblSkills.Text = "Skills:";
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(27, 480);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(133, 20);
            this.lblExperience.TabIndex = 20;
            this.lblExperience.Text = "Work Experience:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(24, 642);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmMyProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 685);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblSkills);
            this.Controls.Add(this.lblEducational);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtExperience);
            this.Controls.Add(this.txtEducation);
            this.Controls.Add(this.txtSkills);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtNationality);
            this.Controls.Add(this.cmbCivilStatus);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.lblCivilStatus);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmMyProfile";
            this.Text = "frmMyProfile";
            this.Load += new System.EventHandler(this.frmMyProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblCivilStatus;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.ComboBox cmbCivilStatus;
        private System.Windows.Forms.TextBox txtNationality;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtSkills;
        private System.Windows.Forms.TextBox txtEducation;
        private System.Windows.Forms.TextBox txtExperience;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblEducational;
        private System.Windows.Forms.Label lblSkills;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Button btnSave;
    }
}