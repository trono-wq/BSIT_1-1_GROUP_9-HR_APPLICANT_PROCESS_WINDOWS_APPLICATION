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
    public partial class frmJobVacancies : Form
    {
        private int applicantAccountId;

        public frmJobVacancies(int accountId)
        {
            InitializeComponent();
            applicantAccountId = accountId;
        }
        public frmJobVacancies()
        {
            InitializeComponent();
        }

        private void frmJobVacancies_Load(object sender, EventArgs e)
        {
            string connString =
            "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=09303281417Ms;";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
                SELECT
                   j.job_vacancy_id,
                   j.position,
                   d.department_name,
                   e.employment_type_name,
                   j.vacancy_status
                FROM JobVacancies j
                JOIN Departments d
                    ON j.department_id = d.department_id
                JOIN EmploymentTypes e
                    ON j.employment_type_id = e.employment_type_id
                WHERE j.vacancy_status = 'Open'";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                dgvJobVacancies.Rows.Clear();

                while (reader.Read())
                {
                    dgvJobVacancies.Rows.Add(
                        reader["job_vacancy_id"],
                        reader["position"],
                        reader["department_name"],
                        reader["employment_type_name"],
                        reader["vacancy_status"]
                    );

                }
            }
        }

        private void dgvJobVacancies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText =
                txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in dgvJobVacancies.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible =
                    (row.Cells["colPosition"].Value?.ToString() ?? "")
                        .ToLower().Contains(searchText)

                    || (row.Cells["colDepartment"].Value?.ToString() ?? "")
                        .ToLower().Contains(searchText)

                    || (row.Cells["colEmployment"].Value?.ToString() ?? "")
                        .ToLower().Contains(searchText);

                row.Visible = visible;
            }
        }
    

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (dgvJobVacancies.CurrentRow == null)
            {
                MessageBox.Show("Please select a job first.");
                return;
            }

            try
            {
                int jobVacancyId =
                    Convert.ToInt32(
                        dgvJobVacancies.CurrentRow
                        .Cells["colJobVacancyId"].Value);

                string connString =
                    "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=09303281417Ms;";

                using (MySqlConnection conn =
                       new MySqlConnection(connString))
                {
                    conn.Open();

                    // Get actual applicant_id
                    string getApplicantQuery = @"
                    SELECT applicant_id
                    FROM Applicants
                    WHERE applicant_account_id = @accountId";

                    MySqlCommand applicantCmd =
                        new MySqlCommand(getApplicantQuery, conn);

                    applicantCmd.Parameters.AddWithValue(
                        "@accountId",
                        applicantAccountId);

                    object applicantResult =
                        applicantCmd.ExecuteScalar();

                    if (applicantResult == null)
                    {
                        MessageBox.Show("Applicant profile not found.");
                        return;
                    }

                    int applicantId =
                        Convert.ToInt32(applicantResult);

                    // Insert application
                    string query = @"
                    INSERT INTO Applications
                    (
                        applicant_id,
                        job_vacancy_id,
                        application_status
                    )
                    VALUES
                    (
                        @applicantId,
                        @jobVacancyId,
                        'Draft'
                    )";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@applicantId",
                        applicantId);

                    cmd.Parameters.AddWithValue(
                        "@jobVacancyId",
                        jobVacancyId);

                    cmd.ExecuteNonQuery();

                    int applicationId =
                        Convert.ToInt32(cmd.LastInsertedId);

                    string historyQuery = @"
                    INSERT INTO ApplicationStatusHistory
                    (
                        application_id,
                        old_status,
                        new_status
                    )
                    VALUES
                    (
                        @applicationId,
                        NULL,
                       'Draft'
                    )";

                    MySqlCommand historyCmd =
                        new MySqlCommand(historyQuery, conn);

                    historyCmd.Parameters.AddWithValue(
                        "@applicationId",
                        applicationId);

                    historyCmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Application saved as Draft.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            frmApplicantDashboard dashboard =
                new frmApplicantDashboard(applicantAccountId);

            dashboard.Show();
            this.Hide();
        }
    }
}

