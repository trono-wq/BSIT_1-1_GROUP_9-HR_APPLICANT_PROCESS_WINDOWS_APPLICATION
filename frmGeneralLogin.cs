using System;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmGeneralLogin : Form
    {
        // FORMS
        
        public frmGeneralLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // BUTTONS

        private void btn_Applicant_Click(object sender, EventArgs e)
        {
            frmApplicantLogin ApplicationLogin = new frmApplicantLogin();
            ApplicationLogin.Show();
            this.Hide();
        }

        private void btn_HumanResources_Click(object sender, EventArgs e)
        {
            frmHRLogin HRLogin = new frmHRLogin();
            HRLogin.Show();
            this.Hide();
        }
    }
}
