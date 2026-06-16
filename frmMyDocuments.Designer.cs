namespace COMP_003_CAPSTONE
{
    partial class frmMyDocuments
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
            this.dgvDocuments = new System.Windows.Forms.DataGridView();
            this.colRequirementType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUploadResume = new System.Windows.Forms.Button();
            this.btnUploadCertificate = new System.Windows.Forms.Button();
            this.btnUploadTranscript = new System.Windows.Forms.Button();
            this.btnUploadID = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDocuments
            // 
            this.dgvDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRequirementType,
            this.colStatus});
            this.dgvDocuments.Location = new System.Drawing.Point(12, 55);
            this.dgvDocuments.Name = "dgvDocuments";
            this.dgvDocuments.RowHeadersWidth = 62;
            this.dgvDocuments.RowTemplate.Height = 28;
            this.dgvDocuments.Size = new System.Drawing.Size(417, 150);
            this.dgvDocuments.TabIndex = 0;
            this.dgvDocuments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocuments_CellContentClick);
            // 
            // colRequirementType
            // 
            this.colRequirementType.HeaderText = "Requirement Type";
            this.colRequirementType.MinimumWidth = 8;
            this.colRequirementType.Name = "colRequirementType";
            this.colRequirementType.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 150;
            // 
            // btnUploadResume
            // 
            this.btnUploadResume.Location = new System.Drawing.Point(12, 237);
            this.btnUploadResume.Name = "btnUploadResume";
            this.btnUploadResume.Size = new System.Drawing.Size(147, 36);
            this.btnUploadResume.TabIndex = 1;
            this.btnUploadResume.Text = "Upload Resume";
            this.btnUploadResume.UseVisualStyleBackColor = true;
            this.btnUploadResume.Click += new System.EventHandler(this.btnUploadResume_Click);
            // 
            // btnUploadCertificate
            // 
            this.btnUploadCertificate.Location = new System.Drawing.Point(12, 363);
            this.btnUploadCertificate.Name = "btnUploadCertificate";
            this.btnUploadCertificate.Size = new System.Drawing.Size(155, 36);
            this.btnUploadCertificate.TabIndex = 2;
            this.btnUploadCertificate.Text = "Upload Certificate";
            this.btnUploadCertificate.UseVisualStyleBackColor = true;
            this.btnUploadCertificate.Click += new System.EventHandler(this.btnUploadCertificate_Click);
            // 
            // btnUploadTranscript
            // 
            this.btnUploadTranscript.Location = new System.Drawing.Point(12, 321);
            this.btnUploadTranscript.Name = "btnUploadTranscript";
            this.btnUploadTranscript.Size = new System.Drawing.Size(147, 36);
            this.btnUploadTranscript.TabIndex = 3;
            this.btnUploadTranscript.Text = "Upload Transcript";
            this.btnUploadTranscript.UseVisualStyleBackColor = true;
            this.btnUploadTranscript.Click += new System.EventHandler(this.btnUploadTranscript_Click);
            // 
            // btnUploadID
            // 
            this.btnUploadID.Location = new System.Drawing.Point(12, 279);
            this.btnUploadID.Name = "btnUploadID";
            this.btnUploadID.Size = new System.Drawing.Size(147, 36);
            this.btnUploadID.TabIndex = 4;
            this.btnUploadID.Text = "Upload ID";
            this.btnUploadID.UseVisualStyleBackColor = true;
            this.btnUploadID.Click += new System.EventHandler(this.btnUploadID_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 405);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 33);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmMyDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUploadID);
            this.Controls.Add(this.btnUploadTranscript);
            this.Controls.Add(this.btnUploadCertificate);
            this.Controls.Add(this.btnUploadResume);
            this.Controls.Add(this.dgvDocuments);
            this.Name = "frmMyDocuments";
            this.Text = "frmMyDocuments";
            this.Load += new System.EventHandler(this.frmMyDocuments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocuments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRequirementType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Button btnUploadResume;
        private System.Windows.Forms.Button btnUploadCertificate;
        private System.Windows.Forms.Button btnUploadTranscript;
        private System.Windows.Forms.Button btnUploadID;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}