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
    public partial class frmApplicationStatus : Form
    {
        public frmApplicationStatus()
        {
            InitializeComponent();
        }

    private void frmApplicationStatus_Load(object sender, EventArgs e)
    {

    }

        private void dgvApplicationStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmApplicantDashboard dashboard = new frmApplicantDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
