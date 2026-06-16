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
    public partial class frmJobVacancies : Form
    {
        public frmJobVacancies()
        {
            InitializeComponent();
        }

        private void frmJobVacancies_Load(object sender, EventArgs e)
        {
            dgvJobVacancies.Rows.Add("Programmer", "IT", "Full-Time", "Open");
            dgvJobVacancies.Rows.Add("HR Assistant", "Human Resources", "Full-Time", "Open");
            dgvJobVacancies.Rows.Add("Graphic Designer", "Marketing", "Part-Time", "Open");
        }

        private void dgvJobVacancies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvJobVacancies.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible =
                    row.Cells["colPosition"].Value.ToString()
                    .ToLower()
                    .Contains(txtSearch.Text.ToLower());

                row.Visible = visible;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dgvJobVacancies.SelectedRows.Count > 0)
            {
                string position =
                    dgvJobVacancies.SelectedRows[0].Cells[0].Value.ToString();

                MessageBox.Show("You applied for: " + position);
            }
            else
            {
                MessageBox.Show("Please select a job first.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmApplicantDashboard dashboard =
       new frmApplicantDashboard();

            dashboard.Show();
            this.Hide();
        }
    }

}