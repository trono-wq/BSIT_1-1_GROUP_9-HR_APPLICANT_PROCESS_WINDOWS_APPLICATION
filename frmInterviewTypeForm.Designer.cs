using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace COMP_003_CAPSTONE
{
    partial class frmInterviewTypeForm
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
            txtInterviewTypeName = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvInterviewTypes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvInterviewTypes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 66);
            label1.Name = "label1";
            label1.Size = new Size(181, 25);
            label1.TabIndex = 0;
            label1.Text = "Interview Type Name:";
            // 
            // txtInterviewTypeName
            // 
            txtInterviewTypeName.Location = new Point(260, 63);
            txtInterviewTypeName.Name = "txtInterviewTypeName";
            txtInterviewTypeName.Size = new Size(891, 31);
            txtInterviewTypeName.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1157, 63);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(1157, 103);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1157, 143);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvInterviewTypes
            // 
            dgvInterviewTypes.AllowUserToAddRows = false;
            dgvInterviewTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInterviewTypes.Location = new Point(260, 103);
            dgvInterviewTypes.Name = "dgvInterviewTypes";
            dgvInterviewTypes.ReadOnly = true;
            dgvInterviewTypes.RowHeadersWidth = 62;
            dgvInterviewTypes.Size = new Size(891, 520);
            dgvInterviewTypes.TabIndex = 5;
            // 
            // InterviewTypeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1376, 771);
            Controls.Add(dgvInterviewTypes);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtInterviewTypeName);
            Controls.Add(label1);
            Name = "InterviewTypeForm";
            Text = "Interview Type Management";
            ((System.ComponentModel.ISupportInitialize)dgvInterviewTypes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox txtInterviewTypeName;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvInterviewTypes;
    }
}