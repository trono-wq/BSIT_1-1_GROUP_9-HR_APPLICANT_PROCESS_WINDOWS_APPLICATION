using System;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmGeneralLogin : Form
    {
        public frmGeneralLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmGeneralLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

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
