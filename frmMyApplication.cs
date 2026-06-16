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
    public partial class frmMyApplication : Form
    {
        public frmMyApplication()
        {
            InitializeComponent();
        }

        private void frmMyApplication_Load(object sender, EventArgs e)
        {
            dgvMyApplication.Rows.Add(
            "Programmer",
            "IT",
            "Draft",
            DateTime.Now.ToShortDateString()
        );

            dgvMyApplication.Rows.Add(
                "HR Assistant",
                "HR",
                "Submitted",
                DateTime.Now.ToShortDateString()
        );
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvMyApplication.Rows.Add(
                "1",
                "Programmer",
                "Submitted",
                 DateTime.Now.ToShortDateString()
           );

            dgvMyApplication.Rows.Add(
                "2",
                "HR Assistant",
                "Under Review",
                DateTime.Now.ToShortDateString()
            );

        }

        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application saved as Draft.");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Application submitted successfully.");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmApplicantDashboard dashboard = new frmApplicantDashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
