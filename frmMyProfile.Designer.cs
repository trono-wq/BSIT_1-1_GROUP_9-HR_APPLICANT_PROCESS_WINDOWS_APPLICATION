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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(110, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(80, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "My Profile";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(13, 44);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(57, 13);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "Full Name:";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(13, 71);
            this.lblDOB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(69, 13);
            this.lblDOB.TabIndex = 2;
            this.lblDOB.Text = "Date of Birth:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(13, 93);
            this.lblGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(45, 13);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "Gender:";
            // 
            // lblCivilStatus
            // 
            this.lblCivilStatus.AutoSize = true;
            this.lblCivilStatus.Location = new System.Drawing.Point(13, 118);
            this.lblCivilStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCivilStatus.Name = "lblCivilStatus";
            this.lblCivilStatus.Size = new System.Drawing.Size(62, 13);
            this.lblCivilStatus.TabIndex = 4;
            this.lblCivilStatus.Text = "Civil Status:";
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(11, 143);
            this.lblNationality.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(59, 13);
            this.lblNationality.TabIndex = 5;
            this.lblNationality.Text = "Nationality:";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(11, 164);
            this.lblContact.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(84, 13);
            this.lblContact.TabIndex = 6;
            this.lblContact.Text = "Contact Number";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(144, 41);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(135, 20);
            this.txtFullName.TabIndex = 7;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Location = new System.Drawing.Point(144, 65);
            this.dtpDOB.Margin = new System.Windows.Forms.Padding(2);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(135, 20);
            this.dtpDOB.TabIndex = 8;
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Prefer not say"});
            this.cmbGender.Location = new System.Drawing.Point(144, 90);
            this.cmbGender.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(135, 21);
            this.cmbGender.TabIndex = 9;
            // 
            // cmbCivilStatus
            // 
            this.cmbCivilStatus.FormattingEnabled = true;
            this.cmbCivilStatus.Items.AddRange(new object[] {
            "Single",
            "Married"});
            this.cmbCivilStatus.Location = new System.Drawing.Point(144, 115);
            this.cmbCivilStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCivilStatus.Name = "cmbCivilStatus";
            this.cmbCivilStatus.Size = new System.Drawing.Size(135, 21);
            this.cmbCivilStatus.TabIndex = 10;
            // 
            // txtNationality
            // 
            this.txtNationality.Location = new System.Drawing.Point(144, 140);
            this.txtNationality.Margin = new System.Windows.Forms.Padding(2);
            this.txtNationality.Name = "txtNationality";
            this.txtNationality.Size = new System.Drawing.Size(135, 20);
            this.txtNationality.TabIndex = 11;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(144, 164);
            this.txtContact.Margin = new System.Windows.Forms.Padding(2);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(135, 20);
            this.txtContact.TabIndex = 12;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(144, 188);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(135, 20);
            this.txtAddress.TabIndex = 13;
            // 
            // txtSkills
            // 
            this.txtSkills.Location = new System.Drawing.Point(144, 212);
            this.txtSkills.Margin = new System.Windows.Forms.Padding(2);
            this.txtSkills.Name = "txtSkills";
            this.txtSkills.Size = new System.Drawing.Size(135, 20);
            this.txtSkills.TabIndex = 14;
            // 
            // txtEducation
            // 
            this.txtEducation.Location = new System.Drawing.Point(144, 236);
            this.txtEducation.Margin = new System.Windows.Forms.Padding(2);
            this.txtEducation.Name = "txtEducation";
            this.txtEducation.Size = new System.Drawing.Size(135, 20);
            this.txtEducation.TabIndex = 15;
            // 
            // txtExperience
            // 
            this.txtExperience.Location = new System.Drawing.Point(144, 260);
            this.txtExperience.Margin = new System.Windows.Forms.Padding(2);
            this.txtExperience.Multiline = true;
            this.txtExperience.Name = "txtExperience";
            this.txtExperience.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtExperience.Size = new System.Drawing.Size(135, 177);
            this.txtExperience.TabIndex = 16;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(13, 191);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 17;
            this.lblAddress.Text = "Address:";
            // 
            // lblEducational
            // 
            this.lblEducational.AutoSize = true;
            this.lblEducational.Location = new System.Drawing.Point(11, 215);
            this.lblEducational.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEducational.Name = "lblEducational";
            this.lblEducational.Size = new System.Drawing.Size(124, 13);
            this.lblEducational.TabIndex = 18;
            this.lblEducational.Text = "Educational Background";
            // 
            // lblSkills
            // 
            this.lblSkills.AutoSize = true;
            this.lblSkills.Location = new System.Drawing.Point(11, 243);
            this.lblSkills.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(34, 13);
            this.lblSkills.TabIndex = 19;
            this.lblSkills.Text = "Skills:";
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(11, 263);
            this.lblExperience.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(92, 13);
            this.lblExperience.TabIndex = 20;
            this.lblExperience.Text = "Work Experience:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 417);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 20);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 417);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 20);
            this.button1.TabIndex = 22;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMyProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 445);
            this.Controls.Add(this.button1);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMyProfile";
            this.Text = "My Profile";
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
        private System.Windows.Forms.Button button1;
    }
}