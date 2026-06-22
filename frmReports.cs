using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmReports : Form
    {
        // ======= SECTION 23.1: ( FORM INITIALIZATION ) ======================================================================== //
        public frmReports()
        {
            InitializeComponent();
            this.Load += new EventHandler(ReportsForm_Load);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // ======= SECTION 23.2: ( FORM LOAD ) ================================================================================== //
        private void ReportsForm_Load(object sender, EventArgs e)
        {
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cmbReportType.Items.Add("Applicant List");
            cmbReportType.Items.Add("Pending Applications");
            cmbReportType.Items.Add("Interviews");
            cmbReportType.Items.Add("Accepted / Rejected");
            cmbReportType.Items.Add("Missing Requirements");
            cmbReportType.SelectedIndex = 0;
        }

        // ======= SECTION 23.3: ( GENERATE REPORT ) ============================================================================ //
        private void btnGenerateReport_Click_1(object sender, EventArgs e)
        {
            string selected = cmbReportType.SelectedItem.ToString();
            if (selected == "Applicant List") LoadApplicantList();
            else if (selected == "Pending Applications") LoadPendingApplications();
            else if (selected == "Interviews") LoadInterviews();
            else if (selected == "Accepted / Rejected") LoadAcceptedRejected();
            else if (selected == "Missing Requirements") LoadMissingRequirements();
        }
        // ======= SECTION 23.4: ( ALL APPLICANTS REPORT ) ======================================================================= //
        private void LoadApplicantList()
        {
            try
            {
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = @"SELECT a.pi_full_name, jv.position, ap.application_status
                        FROM Applicants a
                        JOIN Applications ap ON a.applicant_id = ap.applicant_id
                        JOIN JobVacancies jv ON ap.job_vacancy_id = jv.job_vacancy_id";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvReport.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // ======= SECTION 23.5: ( PENDING APPLICATIONS REPORT ) ================================================================= //
        private void LoadPendingApplications()
        {
            try
            {
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = @"SELECT a.pi_full_name, jv.position, ap.application_status
        FROM Applicants a
        JOIN Applications ap ON a.applicant_id = ap.applicant_id
        JOIN JobVacancies jv ON ap.job_vacancy_id = jv.job_vacancy_id
        WHERE ap.application_status NOT IN ('Accepted','Rejected','Withdrawn')";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvReport.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ======= SECTION 23.6: ( ACCEPTED / REJECTED REPORT ) ================================================================ //
        private void LoadAcceptedRejected()
        {
            try
            {
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = @"SELECT a.pi_full_name, jv.position, hd.final_decision, hd.final_remarks
                        FROM Applicants a
                        JOIN Applications ap ON a.applicant_id = ap.applicant_id
                        JOIN JobVacancies jv ON ap.job_vacancy_id = jv.job_vacancy_id
                        JOIN HiringDecisions hd ON ap.application_id = hd.application_id
                        WHERE hd.final_decision IN ('Accepted','Rejected')";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvReport.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ======= SECTION 23.7: ( INTERVIEWS REPORT ) ========================================================================== //
        private void LoadInterviews()
        {
            try
            {
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = @"SELECT a.pi_full_name, jv.position, isch.interview_date_time, isch.mode_location, isch.status
                        FROM Applicants a
                        JOIN Applications ap ON a.applicant_id = ap.applicant_id
                        JOIN JobVacancies jv ON ap.job_vacancy_id = jv.job_vacancy_id
                        JOIN InterviewSchedules isch ON ap.application_id = isch.application_id";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvReport.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ======= SECTION 23.8: ( MISSING REQUIREMENTS REPORT ) =================================================================== //
        private void LoadMissingRequirements()
        {
            try
            {
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = @"SELECT a.pi_full_name, rt.requirement_type_name, ad.document_status
                        FROM Applicants a
                        JOIN Applications ap ON a.applicant_id = ap.applicant_id
                        JOIN ApplicantDocuments ad ON ap.application_id = ad.application_id
                        JOIN RequirementTypes rt ON ad.requirement_type_id = rt.requirement_type_id
                        WHERE ad.document_status = 'Missing'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvReport.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ======= SECTION 23.9: ( BACK ) =================================================================== //

        private void btnBack_Click_1(object sender, EventArgs e)
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