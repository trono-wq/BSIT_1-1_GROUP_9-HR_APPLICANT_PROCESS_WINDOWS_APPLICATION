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
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblApplicationStatus = new System.Windows.Forms.Label();
            this.txtApplicationStatus = new System.Windows.Forms.TextBox();
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
            this.dgvMyApplication.Location = new System.Drawing.Point(32, 222);
            this.dgvMyApplication.Name = "dgvMyApplication";
            this.dgvMyApplication.RowHeadersWidth = 62;
            this.dgvMyApplication.RowTemplate.Height = 28;
            this.dgvMyApplication.Size = new System.Drawing.Size(675, 150);
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
            // btnSaveDraft
            // 
            this.btnSaveDraft.Location = new System.Drawing.Point(57, 483);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(107, 32);
            this.btnSaveDraft.TabIndex = 1;
            this.btnSaveDraft.Text = "Save Draft";
            this.btnSaveDraft.UseVisualStyleBackColor = true;
            this.btnSaveDraft.Click += new System.EventHandler(this.btnSaveDraft_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(189, 485);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(180, 30);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit Application";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(57, 576);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 32);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblApplicationStatus
            // 
            this.lblApplicationStatus.AutoSize = true;
            this.lblApplicationStatus.Location = new System.Drawing.Point(53, 61);
            this.lblApplicationStatus.Name = "lblApplicationStatus";
            this.lblApplicationStatus.Size = new System.Drawing.Size(138, 20);
            this.lblApplicationStatus.TabIndex = 4;
            this.lblApplicationStatus.Text = "Application Status";
            // 
            // txtApplicationStatus
            // 
            this.txtApplicationStatus.Location = new System.Drawing.Point(219, 55);
            this.txtApplicationStatus.Name = "txtApplicationStatus";
            this.txtApplicationStatus.ReadOnly = true;
            this.txtApplicationStatus.Size = new System.Drawing.Size(100, 26);
            this.txtApplicationStatus.TabIndex = 5;
            this.txtApplicationStatus.Text = "Submitted";
            // 
            // frmMyApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.txtApplicationStatus);
            this.Controls.Add(this.lblApplicationStatus);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSaveDraft);
            this.Controls.Add(this.dgvMyApplication);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMyApplication";
            this.Text = "frmMyApplication";
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
        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblApplicationStatus;
        private System.Windows.Forms.TextBox txtApplicationStatus;
    }
}