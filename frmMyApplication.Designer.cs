namespace COMP_003_CAPSTONE
{
    partial class frmMyApplication
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
            this.dgvMyApplication = new System.Windows.Forms.DataGridView();
            this.colPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnEditApplication = new System.Windows.Forms.Button();
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyApplication)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMyApplication
            // 
            this.dgvMyApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyApplication.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPosition,
            this.colDepartment,
            this.colStatus,
            this.colDate});
            this.dgvMyApplication.Location = new System.Drawing.Point(11, 50);
            this.dgvMyApplication.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvMyApplication.Name = "dgvMyApplication";
            this.dgvMyApplication.RowHeadersWidth = 62;
            this.dgvMyApplication.RowTemplate.Height = 28;
            this.dgvMyApplication.Size = new System.Drawing.Size(663, 167);
            this.dgvMyApplication.TabIndex = 0;
            this.dgvMyApplication.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // colPosition
            // 
            this.colPosition.HeaderText = "Job Position";
            this.colPosition.MinimumWidth = 8;
            this.colPosition.Name = "colPosition";
            this.colPosition.Width = 150;
            // 
            // colDepartment
            // 
            this.colDepartment.HeaderText = "Department";
            this.colDepartment.MinimumWidth = 8;
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 8;
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 150;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date applied";
            this.colDate.MinimumWidth = 8;
            this.colDate.Name = "colDate";
            this.colDate.Width = 150;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(120, 221);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(105, 20);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit Application";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(624, 221);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(50, 20);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnEditApplication
            // 
            this.btnEditApplication.Location = new System.Drawing.Point(229, 221);
            this.btnEditApplication.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditApplication.Name = "btnEditApplication";
            this.btnEditApplication.Size = new System.Drawing.Size(105, 20);
            this.btnEditApplication.TabIndex = 4;
            this.btnEditApplication.Text = "Edit Application";
            this.btnEditApplication.UseVisualStyleBackColor = true;
            this.btnEditApplication.Click += new System.EventHandler(this.btnEditApplication_Click);
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.Location = new System.Drawing.Point(11, 221);
            this.btnSaveDraft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(105, 20);
            this.btnSaveDraft.TabIndex = 5;
            this.btnSaveDraft.Text = "Save Draft";
            this.btnSaveDraft.UseVisualStyleBackColor = true;
            this.btnSaveDraft.Click += new System.EventHandler(this.btnSaveDraft_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "My Application";
            // 
            // frmMyApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 248);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveDraft);
            this.Controls.Add(this.btnEditApplication);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.dgvMyApplication);
            this.Name = "frmMyApplication";
            this.Text = "My Application";
            this.Load += new System.EventHandler(this.frmMyApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyApplication)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMyApplication;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnEditApplication;
        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Label label1;
    }
}