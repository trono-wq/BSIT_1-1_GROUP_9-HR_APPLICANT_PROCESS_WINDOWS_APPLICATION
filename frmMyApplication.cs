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
    public partial class frmMyApplication : Form
    {
        private int applicantAccountId;

        public frmMyApplication(int accountId)
        {
            InitializeComponent();
            applicantAccountId = accountId;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void LoadApplications()
        {
            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
                   SELECT
                      p.position_type_id, 
                      p.position_type_name,
                      d.department_name,
                      a.application_status,
                      a.o_application_updated_at
                   FROM Applications a
                   INNER JOIN JobVacancies j
                      ON a.job_vacancy_id = j.job_vacancy_id
                   INNER JOIN Departments d
                      ON j.department_id = d.department_id
                   INNER JOIN Applicants ap
                      ON a.applicant_id = ap.applicant_id
                     INNER JOIN PositionTypes p 
                        ON j.position_type_id = p.position_type_id  
                   WHERE ap.applicant_account_id = @accountId";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@accountId", applicantAccountId);

                MySqlDataReader reader = cmd.ExecuteReader();

                dgvMyApplication.Rows.Clear();

                while (reader.Read())
                {
                    {
                        dgvMyApplication.Rows.Add(
                            reader["position_type_name"].ToString(),
                            reader["department_name"].ToString(),
                            reader["application_status"].ToString(),
                            Convert.ToDateTime(
                                reader["o_application_updated_at"])
                            .ToShortDateString()
                        );
                    }
                }
            }
        }
        private void CheckIfApplicationEditable()
        {
            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

            using (MySqlConnection conn =
                new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
                SELECT
                    application_status,
                    locked
                FROM Applications a
                INNER JOIN Applicants ap
                    ON a.applicant_id = ap.applicant_id
                WHERE ap.applicant_account_id = @accountId
                ORDER BY a.application_id DESC
                LIMIT 1";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@accountId",
                    applicantAccountId);

                MySqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    string status =
                        reader["application_status"].ToString();

                    bool locked =
                        Convert.ToBoolean(
                            reader["locked"]);

                    if (locked)
                    {
                        btnSaveDraft.Enabled = false;
                        btnEditApplication.Enabled = false;
                        btnSubmit.Enabled = false;

                        MessageBox.Show(
                            "Application can no longer be edited.");
                    }
                }
            }
        }

        private void frmMyApplication_Load(object sender, EventArgs e)
        {
            LoadApplications();
            CheckIfApplicationEditable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dgvMyApplication.CurrentRow == null)
            {
                MessageBox.Show("Please select an application.");
                return;
            }

            string position =
                dgvMyApplication.CurrentRow.Cells[0].Value.ToString();

            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

            using (MySqlConnection conn =
                   new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
                UPDATE Applications a
                INNER JOIN JobVacancies j
                    ON a.job_vacancy_id = j.job_vacancy_id
                INNER JOIN Applicants ap
                    ON a.applicant_id = ap.applicant_id
                INNER JOIN PositionTypes p
                    ON j.position_type_id = p.position_type_id
                SET a.application_status = 'Submitted'
                WHERE p.position_type_name  = @position
                AND ap.applicant_account_id = @accountId";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@position", position);
                cmd.Parameters.AddWithValue("@accountId", applicantAccountId);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Application submitted successfully!");

                LoadApplications(); // Refresh grid
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmApplicantDashboard dashboard =
                new frmApplicantDashboard(applicantAccountId);

            dashboard.Show();
            this.Hide();
        }

        private void btnEditApplication_Click(object sender, EventArgs e)
        {
            {
                if (dgvMyApplication.CurrentRow == null)
                {
                    MessageBox.Show("Please select an application.");
                    return;
                }

                string position =
                    dgvMyApplication.CurrentRow.Cells[0].Value.ToString();

                string connString =
                    "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

                using (MySqlConnection conn =
                    new MySqlConnection(connString))
                {
                    conn.Open();

                    string query = @"
                UPDATE Applications a
                INNER JOIN JobVacancies j
                    ON a.job_vacancy_id = j.job_vacancy_id
                INNER JOIN Applicants ap
                    ON a.applicant_id = ap.applicant_id
                INNER JOIN PositionTypes p
                    ON j.position_type_id = p.position_type_id 
                SET a.application_status = 'Draft'
                WHERE p.position_type_name = @position
                AND ap.applicant_account_id = @accountId";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.Parameters.AddWithValue("@accountId", applicantAccountId);

                    cmd.ExecuteNonQuery();

                    string getApplicationIdQuery = @"
                    SELECT a.application_id
                    FROM Applications a
                    INNER JOIN Applicants ap
                        ON a.applicant_id = ap.applicant_id
                    INNER JOIN JobVacancies j
                        ON a.job_vacancy_id = j.job_vacancy_id
                    INNER JOIN PositionTypes p
                        ON j.position_type_id = p.position_type_id    
                    WHERE ap.applicant_account_id = @accountId
                    
                    AND p.position_type_name = @position    
                    LIMIT 1";
  
                    MySqlCommand getIdCmd =
                        new MySqlCommand(getApplicationIdQuery, conn);

                    getIdCmd.Parameters.AddWithValue(
                        "@accountId",
                        applicantAccountId);

                    getIdCmd.Parameters.AddWithValue(
                        "@position",
                        position);

                    int applicationId =
                        Convert.ToInt32(getIdCmd.ExecuteScalar());

                    // Insert history
                    string historyQuery = @"
                    INSERT INTO ApplicationStatusHistory
                    (
                        application_id,
                        old_status,
                        new_status,
                        updated_at
                    )
                    VALUES
                    (
                        @applicationId,
                        'Submitted',
                        'Draft',
                         NOW()
                    )";

                    MySqlCommand historyCmd =
                        new MySqlCommand(historyQuery, conn);

                    historyCmd.Parameters.AddWithValue(
                        "@applicationId",
                        applicationId);

                    historyCmd.ExecuteNonQuery();

                    MessageBox.Show("Application returned to Draft status.");

                    LoadApplications();
                }
            }
        }

        private void btnSaveDraft_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Application saved as Draft.");
        }
    }
}
