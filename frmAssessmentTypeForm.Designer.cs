using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace COMP_003_CAPSTONE
{
    partial class frmAssessmentTypeForm
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
            txtAssessmentTypeName = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvAssessmentTypes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAssessmentTypes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(117, 69);
            label1.Name = "label1";
            label1.Size = new Size(204, 25);
            label1.TabIndex = 0;
            label1.Text = "Assessment Type Name:";
            // 
            // txtAssessmentTypeName
            // 
            txtAssessmentTypeName.Location = new Point(327, 66);
            txtAssessmentTypeName.Name = "txtAssessmentTypeName";
            txtAssessmentTypeName.Size = new Size(890, 31);
            txtAssessmentTypeName.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1223, 66);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(1223, 103);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1223, 143);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvAssessmentTypes
            // 
            dgvAssessmentTypes.AllowUserToAddRows = false;
            dgvAssessmentTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAssessmentTypes.Location = new Point(327, 112);
            dgvAssessmentTypes.Name = "dgvAssessmentTypes";
            dgvAssessmentTypes.ReadOnly = true;
            dgvAssessmentTypes.RowHeadersWidth = 62;
            dgvAssessmentTypes.Size = new Size(890, 614);
            dgvAssessmentTypes.TabIndex = 5;
            // 
            // AssessmentTypeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1505, 850);
            Controls.Add(dgvAssessmentTypes);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtAssessmentTypeName);
            Controls.Add(label1);
            Name = "AssessmentTypeForm";
            Text = "Assessment Type Management";
            ((System.ComponentModel.ISupportInitialize)dgvAssessmentTypes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox txtAssessmentTypeName;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvAssessmentTypes;
    }
}