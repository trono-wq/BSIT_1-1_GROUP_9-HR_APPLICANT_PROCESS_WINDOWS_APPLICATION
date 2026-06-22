using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.BC;
using System;
using System.Data;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmHiringDecision : Form
    {
        // ============================ SECTION 22.1: ( FORM INITIALIZATION ) =============================================================================== //
        public frmHiringDecision()
        {
            InitializeComponent();
            this.Load += new EventHandler(HiringDecisionForm_Load);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // ============================ SECTION 22.2: ( FORM LOAD ) ========================================================================================= //
        private void HiringDecisionForm_Load(object sender, EventArgs e)
        {
            cmbDecision.Items.Add("Accepted");
            cmbDecision.Items.Add("Rejected");
            cmbDecision.Items.Add("On Hold");
            cmbDecision.SelectedIndex = 0;

            LoadApplicants();
            dgvApplicants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        // ============================ SECTION 22.3: ( LOAD APPLICANTS FOR FINAL REVIEW ) ================================================================== //
        private void LoadApplicants()
        {
            try
            {
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = @"SELECT ap.application_id, a.pi_full_name, p.position_type_name, ap.application_status
                        FROM Applications ap
                        JOIN Applicants a ON ap.applicant_id = a.applicant_id
                        JOIN JobVacancies jv ON ap.job_vacancy_id = jv.job_vacancy_id
                        JOIN PositionTypes p ON jv.position_type_id = p.position_type_id
                        WHERE ap.application_status = 'For Final Review'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvApplicants.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applicants: " + ex.Message);
            }
        }
        // ============================ SECTION 22.4: ( SUBMIT HIRING DECISION ) ============================================================================= //
        private void btnSubmitDecision_Click_1(object sender, EventArgs e)
        {
            if (dgvApplicants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an applicant!");
                return;
            }
            if (cmbDecision.SelectedItem == null)
            {
                MessageBox.Show("Please select a decision!");
                return;
            }

            int applicationId = Convert.ToInt32(dgvApplicants.SelectedRows[0].Cells["application_id"].Value);
            string decision = cmbDecision.SelectedItem.ToString();
            string remarks = txtRemarks.Text;
            string oldStatus = dgvApplicants.SelectedRows[0].Cells["application_status"].Value.ToString();

            try
            {
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();

                // ======= SECTION 22.5: ( INSERT INTO HIRING DECISIONS ) =================================================================================== //

                string insertQuery = @"INSERT INTO HiringDecisions 
                          (application_id, final_decision, final_remarks) 
                          VALUES (@appId, @decision, @remarks)
                          ON DUPLICATE KEY UPDATE 
                          final_decision = @decision, 
                          final_remarks = @remarks";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@appId", applicationId);
                insertCmd.Parameters.AddWithValue("@decision", decision);
                insertCmd.Parameters.AddWithValue("@remarks", remarks);
                insertCmd.ExecuteNonQuery();

                // ======= SECTION 22.6: ( UPDATE APPLICATION STATUS ) =================================================================================== //

                string updateQuery = "UPDATE Applications SET application_status = @status WHERE application_id = @appId";
                MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@status", decision);
                updateCmd.Parameters.AddWithValue("@appId", applicationId);
                updateCmd.ExecuteNonQuery();

                // ======= SECTION 22.7: ( RECORD STATUS HISTORY ) ======================================================================================= //

                string historyQuery = @"INSERT INTO ApplicationStatusHistory 
                       (application_id, old_status, new_status) 
                       VALUES (@appId, @oldStatus, @newStatus)";
                MySqlCommand historyCmd = new MySqlCommand(historyQuery, conn);
                historyCmd.Parameters.AddWithValue("@appId", applicationId);
                historyCmd.Parameters.AddWithValue("@oldStatus", oldStatus);
                historyCmd.Parameters.AddWithValue("@newStatus", decision);
                historyCmd.ExecuteNonQuery();


                conn.Close();
                MessageBox.Show("Decision submitted successfully!");
                txtRemarks.Text = "";
                LoadApplicants();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }

        // ======= SECTION 22.8: ( BACK ) ======================================================================================= //
        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmHRManagerAdminDashboard)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }
    }
}




