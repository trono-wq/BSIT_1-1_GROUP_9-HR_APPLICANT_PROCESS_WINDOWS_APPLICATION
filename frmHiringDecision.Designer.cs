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
            label1 = new Label();
            dgvApplicants = new DataGridView();
            label2 = new Label();
            cmbDecision = new ComboBox();
            label3 = new Label();
            txtRemarks = new TextBox();
            btnSubmitDecision = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvApplicants).BeginInit();
            SuspendLayout();

            label1.AutoSize = true;
            label1.Location = new Point(107, 54);
            label1.Name = "label1";
            label1.Size = new Size(235, 25);
            label1.TabIndex = 0;
            label1.Text = "Applicants For Final Review :";

            dgvApplicants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplicants.Location = new Point(107, 82);
            dgvApplicants.Name = "dgvApplicants";
            dgvApplicants.RowHeadersWidth = 62;
            dgvApplicants.Size = new Size(1299, 263);
            dgvApplicants.TabIndex = 1;
            dgvApplicants.ReadOnly = true;
            dgvApplicants.AllowUserToAddRows = false;

            label2.AutoSize = true;
            label2.Location = new Point(107, 362);
            label2.Name = "label2";
            label2.Size = new Size(129, 25);
            label2.TabIndex = 2;
            label2.Text = "Final Decision :";

            cmbDecision.FormattingEnabled = true;
            cmbDecision.Location = new Point(107, 390);
            cmbDecision.Name = "cmbDecision";
            cmbDecision.Size = new Size(1299, 33);
            cmbDecision.TabIndex = 3;

            label3.AutoSize = true;
            label3.Location = new Point(107, 437);
            label3.Name = "label3";
            label3.Size = new Size(88, 25);
            label3.TabIndex = 4;
            label3.Text = "Remarks :";

            txtRemarks.Location = new Point(107, 472);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(1299, 156);
            txtRemarks.TabIndex = 5;

            btnSubmitDecision.Location = new Point(662, 634);
            btnSubmitDecision.Name = "btnSubmitDecision";
            btnSubmitDecision.Size = new Size(189, 34);
            btnSubmitDecision.TabIndex = 6;
            btnSubmitDecision.Text = "Submit Decision";
            btnSubmitDecision.UseVisualStyleBackColor = true;
            btnSubmitDecision.Click += btnSubmitDecision_Click;


            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1543, 747);
            Controls.Add(btnSubmitDecision);
            Controls.Add(txtRemarks);
            Controls.Add(label3);
            Controls.Add(cmbDecision);
            Controls.Add(label2);
            Controls.Add(dgvApplicants);
            Controls.Add(label1);
            Name = "HiringDecisionForm";
            Text = "Hiring Decision";
            ((System.ComponentModel.ISupportInitialize)dgvApplicants).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private DataGridView dgvApplicants;
        private Label label2;
        private ComboBox cmbDecision;
        private Label label3;
        private TextBox txtRemarks;
        private Button btnSubmitDecision;
    }
}

//COMP_003_CAPSTONE
//frmHiringDecision