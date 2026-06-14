using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace COMP_003_CAPSTONE
{
    partial class frmPositionForm
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
            label1 = new Label();
            txtPositionName = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvPositions = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPositions).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 68);
            label1.Name = "label1";
            label1.Size = new Size(131, 25);
            label1.TabIndex = 0;
            label1.Text = "Position Name:";
            // 
            // txtPositionName
            // 
            txtPositionName.Location = new Point(245, 68);
            txtPositionName.Name = "txtPositionName";
            txtPositionName.Size = new Size(866, 31);
            txtPositionName.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(1117, 68);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(1117, 105);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1117, 145);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvPositions
            // 
            dgvPositions.AllowUserToAddRows = false;
            dgvPositions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPositions.Location = new Point(245, 105);
            dgvPositions.Name = "dgvPositions";
            dgvPositions.ReadOnly = true;
            dgvPositions.RowHeadersWidth = 62;
            dgvPositions.Size = new Size(866, 461);
            dgvPositions.TabIndex = 5;
            // 
            // PositionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 725);
            Controls.Add(dgvPositions);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtPositionName);
            Controls.Add(label1);
            Name = "PositionForm";
            Text = "Position Management";
            ((System.ComponentModel.ISupportInitialize)dgvPositions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPositionName;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvPositions;
    }
}