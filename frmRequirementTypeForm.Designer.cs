using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace COMP_003_CAPSTONE
{
    partial class frmRequirementTypeForm
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
            txtRequirementTypeName = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvRequirementTypes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRequirementTypes).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 68);
            label1.Name = "label1";
            label1.Size = new Size(210, 25);
            label1.TabIndex = 0;
            label1.Text = "Requirement Type Name:";
            // 
            // txtRequirementTypeName
            // 
            txtRequirementTypeName.Location = new Point(260, 63);
            txtRequirementTypeName.Name = "txtRequirementTypeName";
            txtRequirementTypeName.Size = new Size(909, 31);
            txtRequirementTypeName.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1175, 63);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(1175, 103);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1175, 143);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvRequirementTypes
            // 
            dgvRequirementTypes.AllowUserToAddRows = false;
            dgvRequirementTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRequirementTypes.Location = new Point(260, 103);
            dgvRequirementTypes.Name = "dgvRequirementTypes";
            dgvRequirementTypes.ReadOnly = true;
            dgvRequirementTypes.RowHeadersWidth = 62;
            dgvRequirementTypes.Size = new Size(909, 504);
            dgvRequirementTypes.TabIndex = 5;
            // 
            // RequirementTypeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1433, 774);
            Controls.Add(dgvRequirementTypes);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtRequirementTypeName);
            Controls.Add(label1);
            Name = "RequirementTypeForm";
            Text = "Requirement Type Management";
            ((System.ComponentModel.ISupportInitialize)dgvRequirementTypes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox txtRequirementTypeName;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvRequirementTypes;
    }
}