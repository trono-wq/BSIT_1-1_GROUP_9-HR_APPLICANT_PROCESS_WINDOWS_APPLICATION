using Org.BouncyCastle.Asn1.Crmf;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace COMP_003_CAPSTONE
{
    partial class frmMaintenance
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnDepartments = new System.Windows.Forms.Button();
            this.btnPositions = new System.Windows.Forms.Button();
            this.btnEmploymentTypes = new System.Windows.Forms.Button();
            this.btnRequirementTypes = new System.Windows.Forms.Button();
            this.btnInterviewTypes = new System.Windows.Forms.Button();
            this.btnAssessmentTypes = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Maintenance";
            // 
            // btnDepartments
            // 
            this.btnDepartments.Location = new System.Drawing.Point(11, 42);
            this.btnDepartments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDepartments.Name = "btnDepartments";
            this.btnDepartments.Size = new System.Drawing.Size(111, 23);
            this.btnDepartments.TabIndex = 1;
            this.btnDepartments.Text = "Departments";
            this.btnDepartments.UseVisualStyleBackColor = true;
            this.btnDepartments.Click += new System.EventHandler(this.btnDepartments_Click_1);
            // 
            // btnPositions
            // 
            this.btnPositions.Location = new System.Drawing.Point(11, 69);
            this.btnPositions.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPositions.Name = "btnPositions";
            this.btnPositions.Size = new System.Drawing.Size(111, 23);
            this.btnPositions.TabIndex = 2;
            this.btnPositions.Text = "Position Types";
            this.btnPositions.UseVisualStyleBackColor = true;
            this.btnPositions.Click += new System.EventHandler(this.btnPositions_Click_1);
            // 
            // btnEmploymentTypes
            // 
            this.btnEmploymentTypes.Location = new System.Drawing.Point(11, 96);
            this.btnEmploymentTypes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEmploymentTypes.Name = "btnEmploymentTypes";
            this.btnEmploymentTypes.Size = new System.Drawing.Size(111, 23);
            this.btnEmploymentTypes.TabIndex = 3;
            this.btnEmploymentTypes.Text = "Employment Types";
            this.btnEmploymentTypes.UseVisualStyleBackColor = true;
            this.btnEmploymentTypes.Click += new System.EventHandler(this.btnEmploymentTypes_Click_1);
            // 
            // btnRequirementTypes
            // 
            this.btnRequirementTypes.Location = new System.Drawing.Point(126, 42);
            this.btnRequirementTypes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRequirementTypes.Name = "btnRequirementTypes";
            this.btnRequirementTypes.Size = new System.Drawing.Size(111, 23);
            this.btnRequirementTypes.TabIndex = 4;
            this.btnRequirementTypes.Text = "Requirement Types";
            this.btnRequirementTypes.UseVisualStyleBackColor = true;
            this.btnRequirementTypes.Click += new System.EventHandler(this.btnRequirementTypes_Click_1);
            // 
            // btnInterviewTypes
            // 
            this.btnInterviewTypes.Location = new System.Drawing.Point(126, 69);
            this.btnInterviewTypes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnInterviewTypes.Name = "btnInterviewTypes";
            this.btnInterviewTypes.Size = new System.Drawing.Size(111, 23);
            this.btnInterviewTypes.TabIndex = 5;
            this.btnInterviewTypes.Text = "Interview Types";
            this.btnInterviewTypes.UseVisualStyleBackColor = true;
            this.btnInterviewTypes.Click += new System.EventHandler(this.btnInterviewTypes_Click_1);
            // 
            // btnAssessmentTypes
            // 
            this.btnAssessmentTypes.Location = new System.Drawing.Point(126, 96);
            this.btnAssessmentTypes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAssessmentTypes.Name = "btnAssessmentTypes";
            this.btnAssessmentTypes.Size = new System.Drawing.Size(111, 23);
            this.btnAssessmentTypes.TabIndex = 6;
            this.btnAssessmentTypes.Text = "Assessment Types";
            this.btnAssessmentTypes.UseVisualStyleBackColor = true;
            this.btnAssessmentTypes.Click += new System.EventHandler(this.btnAssessmentTypes_Click_1);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(103, 123);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(42, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 155);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAssessmentTypes);
            this.Controls.Add(this.btnInterviewTypes);
            this.Controls.Add(this.btnRequirementTypes);
            this.Controls.Add(this.btnEmploymentTypes);
            this.Controls.Add(this.btnPositions);
            this.Controls.Add(this.btnDepartments);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMaintenance";
            this.Text = "Maintenance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnDepartments;
        private Button btnPositions;
        private Button btnEmploymentTypes;
        private Button btnRequirementTypes;
        private Button btnInterviewTypes;
        private Button btnAssessmentTypes;
        private Button btnBack;
    }
}