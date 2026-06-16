using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmApplicantDashboard : Form
    {
        public frmApplicantDashboard()
        {
            InitializeComponent();
        }

        private void frmApplicantDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnMyApplication_Click(object sender, EventArgs e)
        {
            frmMyApplication MA = new frmMyApplication();
            MA.Show();
            this.Hide();
        }

        private void btnMyDocuments_Click(object sender, EventArgs e)
        {
            frmMyDocuments MD = new frmMyDocuments();
            MD.Show();
            this.Hide();
        }

        private void btnApplicationStatus_Click(object sender, EventArgs e)
        {
            frmApplicationStatus AS = new frmApplicationStatus();
            AS.Show();
            this.Hide();
        }

        private void btnMyProfile_Click_1(object sender, EventArgs e)
        {
            frmMyProfile MP = new frmMyProfile();
            MP.Show();
        }

        private void btnJobVacancies_Click_1(object sender, EventArgs e)
        {
            frmJobVacancies JV = new frmJobVacancies();
            JV.Show();
            this.Hide();
        }
    }
}
