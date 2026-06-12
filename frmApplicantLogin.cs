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
    public partial class frmApplicantLogin : Form
    {
        public frmApplicantLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmApplicantDashboard AD = new frmApplicantDashboard();
            AD.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmApplicantRegistration AR = new frmApplicantRegistration();
            AR.Show();
        }
    }
}
