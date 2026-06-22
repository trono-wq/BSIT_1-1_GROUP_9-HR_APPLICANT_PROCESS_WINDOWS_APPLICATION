using System;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmMaintenance : Form
    {
        // ======================================== SECTION 26-31: ( MAINTENANCE HUB ) =================================== //
        public frmMaintenance()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;    
        }

        // =================== OPEN DEPARTMENT FORM ===================================================================== //
        private void btnDepartments_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmDepartmentForm form = new frmDepartmentForm();
            form.ShowDialog();
            this.Show();
        }

        // =================== OPEN POSITION FORM ===================================================================== //
        private void btnPositions_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmPositionTypeMaintenance form = new frmPositionTypeMaintenance();
            form.ShowDialog();
            this.Show();
        }

        // =================== OPEN EMPLOYMENT TYPE FORM =============================================================== //
        private void btnEmploymentTypes_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmEmploymentTypeMaintenance form = new frmEmploymentTypeMaintenance();
            form.ShowDialog();
            this.Show();
        }

        // =================== OPEN REQUIREMENT TYPE FORM ============================================================== //
        private void btnRequirementTypes_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmRequirementTypeMaintenance form = new frmRequirementTypeMaintenance();
            form.ShowDialog();
            this.Show();
        }

        // =================== OPEN INTERVIEW TYPE FORM ================================================================= //
        private void btnInterviewTypes_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmInterviewTypeMaintenance form = new frmInterviewTypeMaintenance();
            form.ShowDialog();
            this.Show();
        }

        // =================== OPEN ASSESSMENT TYPE FORM ================================================================ //
        private void btnAssessmentTypes_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmAssessmentTypeMaintenance form = new frmAssessmentTypeMaintenance();
            form.ShowDialog();
            this.Show();
        }

        // =================== BACK ================================================================ //

        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmHRManagerAdminDashboard)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }
    }
}