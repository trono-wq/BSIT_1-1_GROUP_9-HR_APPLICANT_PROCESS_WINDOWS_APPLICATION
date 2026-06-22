using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace COMP_003_CAPSTONE
{
    public partial class frmApplicantDashboard : Form
    {
        private int applicantAccountId;

        public frmApplicantDashboard()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;        
        }

        public frmApplicantDashboard(int accountId)
        {
            InitializeComponent();
            applicantAccountId = accountId;
        }
        private void frmApplicantDashboard_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Dashboard Loaded");
            LoadDashboardData();
        }
        private void LoadDashboardData()
        {
            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

            using (MySqlConnection conn =
                new MySqlConnection(connString))
            {
                conn.Open();

                // ==========================
                // CURRENT STATUS
                // ==========================
                string statusQuery = @"
                SELECT application_status
                FROM Applications a
                INNER JOIN Applicants ap
                    ON a.applicant_id = ap.applicant_id
                WHERE ap.applicant_account_id = @accountId
                ORDER BY a.application_id DESC
                LIMIT 1";

                MySqlCommand statusCmd =
                    new MySqlCommand(statusQuery, conn);

                statusCmd.Parameters.AddWithValue(
                    "@accountId",
                    applicantAccountId);

                object statusResult =
                    statusCmd.ExecuteScalar();

                lblCurrentStatus.Text =
                    statusResult != null
                    ? statusResult.ToString()
                    : "No Application";

                // ==========================
                // INTERVIEW SCHEDULE
                // ==========================
                string interviewQuery = @"
                SELECT interview_date_time
                FROM interviewschedules i
                INNER JOIN applications a
                    ON i.application_id = a.application_id
                INNER JOIN applicants ap
                    ON a.applicant_id = ap.applicant_id
                WHERE ap.applicant_account_id = @accountId
                LIMIT 1";

                MySqlCommand interviewCmd =
                    new MySqlCommand(interviewQuery, conn);

                interviewCmd.Parameters.AddWithValue(
                    "@accountId",
                    applicantAccountId);

                object interviewResult =
                    interviewCmd.ExecuteScalar();

                if (interviewResult != null)
                {
                    lblInterviewSchedule.Text =
                        Convert.ToDateTime(interviewResult)
                        .ToString("MMMM dd, yyyy hh:mm tt");
                }
                else
                {
                    lblInterviewSchedule.Text =
                        "No Interview Scheduled";
                }

                // ==========================
                // MISSING DOCUMENTS
                // ==========================
                lstMissingDocuments.Items.Clear();

                string query = @"
                SELECT rt.requirement_type_name
                FROM requirementtypes rt
                WHERE rt.requirement_type_id NOT IN
                (
                SELECT ad.requirement_type_id
                FROM applicantdocuments ad
                INNER JOIN applications a
                    ON ad.application_id = a.application_id
                INNER JOIN applicants ap
                    ON a.applicant_id = ap.applicant_id
                WHERE ap.applicant_account_id = @accountId
                AND ad.document_status = 'Submitted'
                )";

                MySqlCommand docCmd =
                    new MySqlCommand(query, conn);

                docCmd.Parameters.AddWithValue(
                    "@accountId",
                    applicantAccountId);

                MySqlDataReader docReader =
                    docCmd.ExecuteReader();

                lstMissingDocuments.Items.Clear();

                while (docReader.Read())
                {
                    lstMissingDocuments.Items.Add(
                        docReader["requirement_type_name"].ToString());
                }

                docReader.Close();

                // ==========================
                // RECENT UPDATES
                // ==========================
                lstRecentUpdates.Items.Clear();

                string updateQuery = @"
                SELECT old_status, new_status
                FROM applicationstatushistory h
                INNER JOIN applications a
                    ON h.application_id = a.application_id
                INNER JOIN applicants ap
                    ON a.applicant_id = ap.applicant_id
                WHERE ap.applicant_account_id = @accountId";

                MySqlCommand updateCmd =
                    new MySqlCommand(updateQuery, conn);

                updateCmd.Parameters.AddWithValue(
                    "@accountId",
                    applicantAccountId);

                MySqlDataReader updateReader =
                    updateCmd.ExecuteReader();

                while (updateReader.Read())
                {
                    lstRecentUpdates.Items.Add(
                        updateReader["old_status"].ToString()
                        + " → "
                        + updateReader["new_status"].ToString());
                }

                updateReader.Close();
            }
        }

        private void btnMyApplication_Click(object sender, EventArgs e)

        {
            frmMyApplication MA = new frmMyApplication(applicantAccountId);

            MA.Show();
            this.Hide();
        }

        private void btnMyDocuments_Click(object sender, EventArgs e)
        {
            frmMyDocuments MD =
                new frmMyDocuments(applicantAccountId);

            MD.Show();
            this.Hide();
        }

        private void btnApplicationStatus_Click(object sender, EventArgs e)
        {
            frmApplicationStatus AS =
                new frmApplicationStatus(applicantAccountId);

            AS.Show();
            this.Hide();
        }

        private void btnMyProfile_Click_1(object sender, EventArgs e)
        {
            frmMyProfile MP = new frmMyProfile(applicantAccountId);

            MP.Show();
            this.Hide();
        }

        private void btnJobVacancies_Click_1(object sender, EventArgs e)
        {
            frmJobVacancies JV = new frmJobVacancies(applicantAccountId);
            JV.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmApplicantLogin login = new frmApplicantLogin();
            login.Show();
            this.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grpMissingDocuments_Enter(object sender, EventArgs e)
        {

        }

        private void grpInterviewSchedule_Enter(object sender, EventArgs e)
        {

        }
    }
}
