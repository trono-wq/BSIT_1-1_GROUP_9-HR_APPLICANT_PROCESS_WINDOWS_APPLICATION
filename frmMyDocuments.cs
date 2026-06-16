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
    public partial class frmMyDocuments : Form
    {
        public frmMyDocuments()
        {
            InitializeComponent();
        }

        private void frmMyDocuments_Load(object sender, EventArgs e)
        {
            dgvDocuments.Rows.Add("Resume", "Missing");
            dgvDocuments.Rows.Add("Valid ID", "Missing");
            dgvDocuments.Rows.Add("Transcript", "Missing");
            dgvDocuments.Rows.Add("Certificate", "Missing");
        }

        private void btnUploadResume_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Resume uploaded successfully.");

                dgvDocuments.Rows[0].Cells[1].Value = "Submitted";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmApplicantDashboard dashboard = new frmApplicantDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnUploadID_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Valid ID uploaded successfully.");
                dgvDocuments.Rows[1].Cells[1].Value = "Submitted";
            }
        }

        private void btnUploadTranscript_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Transcript uploaded successfully.");
            dgvDocuments.Rows[2].Cells[1].Value = "Submitted";
        }

        private void btnUploadCertificate_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Certificate uploaded successfully.");
                dgvDocuments.Rows[3].Cells[1].Value = "Submitted";
            }
        }

        private void dgvDocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}