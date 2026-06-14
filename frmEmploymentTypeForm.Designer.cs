using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace COMP_003_CAPSTONE
{
    partial class frmEmploymentTypeForm
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
            txtEmploymentTypeName = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvEmploymentTypes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvEmploymentTypes).BeginInit();
            SuspendLayout();

            label1.AutoSize = true;
            label1.Location = new Point(91, 105);
            label1.Name = "label1";
            label1.Size = new Size(211, 25);
            label1.TabIndex = 0;
            label1.Text = "Employment Type Name:";

            txtEmploymentTypeName.Location = new Point(304, 100);
            txtEmploymentTypeName.Name = "txtEmploymentTypeName";
            txtEmploymentTypeName.Size = new Size(700, 31);
            txtEmploymentTypeName.TabIndex = 1;

            btnAdd.Location = new Point(1010, 100);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            btnEdit.Location = new Point(1010, 140);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;

            btnDelete.Location = new Point(1010, 180);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            dgvEmploymentTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmploymentTypes.Location = new Point(304, 137);
            dgvEmploymentTypes.Name = "dgvEmploymentTypes";
            dgvEmploymentTypes.RowHeadersWidth = 62;
            dgvEmploymentTypes.Size = new Size(698, 406);
            dgvEmploymentTypes.TabIndex = 5;
            dgvEmploymentTypes.ReadOnly = true;
            dgvEmploymentTypes.AllowUserToAddRows = false;

            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 706);
            Controls.Add(dgvEmploymentTypes);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtEmploymentTypeName);
            Controls.Add(label1);
            Name = "EmploymentTypeForm";
            Text = "Employment Type Management";
            ((System.ComponentModel.ISupportInitialize)dgvEmploymentTypes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox txtEmploymentTypeName;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvEmploymentTypes;
    }
}