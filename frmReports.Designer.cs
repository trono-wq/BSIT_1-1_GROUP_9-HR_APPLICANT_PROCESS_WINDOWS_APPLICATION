using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace COMP_003_CAPSTONE
{
    public partial class frmReports : Form
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
            cmbReportType = new ComboBox();
            label1 = new Label();
            btnGenerateReport = new Button();
            dgvReport = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();

            cmbReportType.FormattingEnabled = true;
            cmbReportType.Location = new Point(480, 129);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(524, 33);
            cmbReportType.TabIndex = 0;

            label1.AutoSize = true;
            label1.Location = new Point(480, 101);
            label1.Name = "label1";
            label1.Size = new Size(111, 25);
            label1.TabIndex = 1;
            label1.Text = "Report Type:";

            btnGenerateReport.Location = new Point(642, 234);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(182, 34);
            btnGenerateReport.TabIndex = 2;
            btnGenerateReport.Text = "Generate Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;

            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(178, 274);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersWidth = 62;
            dgvReport.Size = new Size(1117, 435);
            dgvReport.TabIndex = 3;
            dgvReport.ReadOnly = true;
            dgvReport.AllowUserToAddRows = false;

            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1454, 760);
            Controls.Add(dgvReport);
            Controls.Add(btnGenerateReport);
            Controls.Add(label1);
            Controls.Add(cmbReportType);
            Name = "ReportsForm";
            Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbReportType;
        private Label label1;
        private Button btnGenerateReport;
        private DataGridView dgvReport;
    }
}