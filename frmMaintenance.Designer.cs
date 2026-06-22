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
            label1 = new Label();
            btnDepartments = new Button();
            btnPositions = new Button();
            btnEmploymentTypes = new Button();
            btnRequirementTypes = new Button();
            btnInterviewTypes = new Button();
            btnAssessmentTypes = new Button();
            btnHiringDecision = new Button();
            btnReports = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(631, 47);
            label1.Name = "label1";
            label1.Size = new Size(178, 25);
            label1.TabIndex = 0;
            label1.Text = "Maintenance Module";
            // 
            // btnDepartments
            // 
            btnDepartments.Location = new Point(581, 75);
            btnDepartments.Name = "btnDepartments";
            btnDepartments.Size = new Size(270, 34);
            btnDepartments.TabIndex = 1;
            btnDepartments.Text = "Departments";
            btnDepartments.UseVisualStyleBackColor = true;
            btnDepartments.Click += btnDepartments_Click;
            // 
            // btnPositions
            // 
            btnPositions.Location = new Point(581, 115);
            btnPositions.Name = "btnPositions";
            btnPositions.Size = new Size(270, 34);
            btnPositions.TabIndex = 2;
            btnPositions.Text = "Positions";
            btnPositions.UseVisualStyleBackColor = true;
            btnPositions.Click += btnPositions_Click;
            // 
            // btnEmploymentTypes
            // 
            btnEmploymentTypes.Location = new Point(581, 155);
            btnEmploymentTypes.Name = "btnEmploymentTypes";
            btnEmploymentTypes.Size = new Size(270, 34);
            btnEmploymentTypes.TabIndex = 3;
            btnEmploymentTypes.Text = "Employment Types";
            btnEmploymentTypes.UseVisualStyleBackColor = true;
            btnEmploymentTypes.Click += btnEmploymentTypes_Click;
            // 
            // btnRequirementTypes
            // 
            btnRequirementTypes.Location = new Point(581, 195);
            btnRequirementTypes.Name = "btnRequirementTypes";
            btnRequirementTypes.Size = new Size(270, 34);
            btnRequirementTypes.TabIndex = 4;
            btnRequirementTypes.Text = "Requirement Types";
            btnRequirementTypes.UseVisualStyleBackColor = true;
            btnRequirementTypes.Click += btnRequirementTypes_Click;
            // 
            // btnInterviewTypes
            // 
            btnInterviewTypes.Location = new Point(581, 235);
            btnInterviewTypes.Name = "btnInterviewTypes";
            btnInterviewTypes.Size = new Size(270, 34);
            btnInterviewTypes.TabIndex = 5;
            btnInterviewTypes.Text = "Interview Types";
            btnInterviewTypes.UseVisualStyleBackColor = true;
            btnInterviewTypes.Click += btnInterviewTypes_Click;
            // 
            // btnAssessmentTypes
            // 
            btnAssessmentTypes.Location = new Point(581, 275);
            btnAssessmentTypes.Name = "btnAssessmentTypes";
            btnAssessmentTypes.Size = new Size(270, 34);
            btnAssessmentTypes.TabIndex = 6;
            btnAssessmentTypes.Text = "Assessment Types";
            btnAssessmentTypes.UseVisualStyleBackColor = true;
            btnAssessmentTypes.Click += btnAssessmentTypes_Click;
            // 
            // MaintenanceHub
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1461, 708);
            Controls.Add(btnReports);
            Controls.Add(btnHiringDecision);
            Controls.Add(btnAssessmentTypes);
            Controls.Add(btnInterviewTypes);
            Controls.Add(btnRequirementTypes);
            Controls.Add(btnEmploymentTypes);
            Controls.Add(btnPositions);
            Controls.Add(btnDepartments);
            Controls.Add(label1);
            Name = "MaintenanceHub";
            Text = "Maintenance Module";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnDepartments;
        private Button btnPositions;
        private Button btnEmploymentTypes;
        private Button btnRequirementTypes;
        private Button btnInterviewTypes;
        private Button btnAssessmentTypes;
        private Button btnHiringDecision;
        private Button btnReports;
    }
}