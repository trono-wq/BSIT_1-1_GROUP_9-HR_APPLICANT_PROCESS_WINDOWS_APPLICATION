using System;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmMaintenanceManagement : Form
    {
        // ======================================== SECTION 26-31: ( MAINTENANCE HUB ) =================================== //
        public frmMaintenanceManagement()
        {
            InitializeComponent();
        }

        // =================== OPEN DEPARTMENT FORM ===================================================================== //
        private void btnDepartments_Click_2(object sender, EventArgs e)
        {
            frmDepartmentForm form = new frmDepartmentForm();
            form.ShowDialog();
        }

        // =================== OPEN POSITION FORM ===================================================================== //
        private void btnPositions_Click_1(object sender, EventArgs e)
        {
            frmPositionForm form = new frmPositionForm();
            form.ShowDialog();
        }

        // =================== OPEN EMPLOYMENT TYPE FORM =============================================================== //
        private void btnEmploymentTypes_Click_1(object sender, EventArgs e)
        {
            frmEmploymentTypeForm form = new frmEmploymentTypeForm();
            form.ShowDialog();
        }

        // =================== OPEN REQUIREMENT TYPE FORM ============================================================== //
        private void btnRequirementTypes_Click_1(object sender, EventArgs e)
        {
            frmRequirementTypeForm form = new frmRequirementTypeForm();
            form.ShowDialog();
        }

        // =================== OPEN INTERVIEW TYPE FORM ================================================================= //
        private void btnInterviewTypes_Click_1(object sender, EventArgs e)
        {
            frmInterviewTypeForm form = new frmInterviewTypeForm();
            form.ShowDialog();
        }

        // =================== OPEN ASSESSMENT TYPE FORM ================================================================ //
        private void btnAssessmentTypes_Click_1(object sender, EventArgs e)
        {
            frmAssessmentTypeForm form = new frmAssessmentTypeForm();
            form.ShowDialog();
        }

    }
}