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
    public partial class frmGeneralLogin : Form
    {
        public frmGeneralLogin()
        {
            InitializeComponent();
        }

        private void cmbBox2_Click(object sender, EventArgs e)
        {
            frmHRLogin HRLogin =  new frmHRLogin();
            HRLogin.Show();
        }

        private void cmbBox1_Click(object sender, EventArgs e)
        {
            frmApplicantLogin AL = new frmApplicantLogin();
            AL.Show();
        }

        private void frmGeneralLogin_Load(object sender, EventArgs e) { }
 
    }
}
