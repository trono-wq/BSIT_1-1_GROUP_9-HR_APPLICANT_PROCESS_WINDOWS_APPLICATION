using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace COMP_003_CAPSTONE
{
    partial class frmHiringDecision
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvApplicants = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDecision = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSubmitDecision = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicants)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Applicants For Final Review :";
            // 
            // dgvApplicants
            // 
            this.dgvApplicants.AllowUserToAddRows = false;
            this.dgvApplicants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicants.Location = new System.Drawing.Point(11, 49);
            this.dgvApplicants.Margin = new System.Windows.Forms.Padding(2);
            this.dgvApplicants.Name = "dgvApplicants";
            this.dgvApplicants.ReadOnly = true;
            this.dgvApplicants.RowHeadersWidth = 62;
            this.dgvApplicants.Size = new System.Drawing.Size(779, 137);
            this.dgvApplicants.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 197);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Final Decision :";
            // 
            // cmbDecision
            // 
            this.cmbDecision.FormattingEnabled = true;
            this.cmbDecision.Location = new System.Drawing.Point(9, 212);
            this.cmbDecision.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDecision.Name = "cmbDecision";
            this.cmbDecision.Size = new System.Drawing.Size(781, 21);
            this.cmbDecision.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 248);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Remarks :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(9, 263);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(2);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(781, 83);
            this.txtRemarks.TabIndex = 5;
            // 
            // btnSubmitDecision
            // 
            this.btnSubmitDecision.Location = new System.Drawing.Point(348, 353);
            this.btnSubmitDecision.Margin = new System.Windows.Forms.Padding(2);
            this.btnSubmitDecision.Name = "btnSubmitDecision";
            this.btnSubmitDecision.Size = new System.Drawing.Size(98, 24);
            this.btnSubmitDecision.TabIndex = 6;
            this.btnSubmitDecision.Text = "Submit Decision";
            this.btnSubmitDecision.UseVisualStyleBackColor = true;
            this.btnSubmitDecision.Click += new System.EventHandler(this.btnSubmitDecision_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(344, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hiring Decision";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(748, 353);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(42, 24);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmHiringDecision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 383);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubmitDecision);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDecision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvApplicants);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmHiringDecision";
            this.Text = "Hiring Decision";
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private DataGridView dgvApplicants;
        private Label label2;
        private ComboBox cmbDecision;
        private Label label3;
        private TextBox txtRemarks;
        private Button btnSubmitDecision;
        private Label label4;
        private Button btnBack;
    }
}

//COMP_003_CAPSTONE
//frmHiringDecision