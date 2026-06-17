using System;
using System.Data;
using System.Windows.Forms;
using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;

namespace COMP_003_CAPSTONE
{
    public partial class frmJobVacancies : Form
    {
        public frmJobVacancies()
        {
            InitializeComponent();
        }

        private void frmJobVacancies_Load(
        object sender,
        EventArgs e)
        {
            LoadOpenVacancies();

            dgvJobVacancies.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadOpenVacancies()
        {
            try
            {
                DatabaseConnection db =
                new DatabaseConnection();

                using (MySqlConnection conn =
                db.GetConnection())
                {
                    conn.Open();

                    string query =
                    @"SELECT
                    j.job_vacancy_id,
                    p.position_type_name,
                    d.department_name,
                    e.employment_type_name,
                    j.vacancy_status

                    FROM JobVacancies j

                    LEFT JOIN Departments d
                    ON j.department_id =
                    d.department_id

                    LEFT JOIN EmploymentTypes e
                    ON j.employment_type_id =
                    e.employment_type_id

                    LEFT JOIN PositionTypes p
                    ON j.position_type_id =
                    p.position_type_id

                    WHERE j.vacancy_status = 'Open'";

                    MySqlDataAdapter adapter =
                    new MySqlDataAdapter(query, conn);

                    DataTable table =
                    new DataTable();

                    adapter.Fill(table);

                    dgvJobVacancies.DataSource =
                    table;

                    dgvJobVacancies.Columns["job_vacancy_id"]
                    .HeaderText =
                    "ID";

                    dgvJobVacancies.Columns["position_type_name"]
                    .HeaderText =
                    "Position";

                    dgvJobVacancies.Columns["department_name"]
                    .HeaderText =
                    "Department";

                    dgvJobVacancies.Columns["employment_type_name"]
                    .HeaderText =
                    "Employment Type";

                    dgvJobVacancies.Columns["vacancy_status"]
                    .HeaderText =
                    "Status";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvJobVacancies_CellContentClick(
        object sender,
        DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(
        object sender,
        EventArgs e)
        {
            try
            {
                DataTable dt =
                (DataTable)dgvJobVacancies.DataSource;

                if (dt != null)
                {
                    string search =
                    txtSearch.Text
                    .Trim()
                    .Replace("'", "''");

                    dt.DefaultView.RowFilter =
                    $"Convert(job_vacancy_id, 'System.String') LIKE '%{search}%' " +
                    $"OR position_type_name LIKE '%{search}%' " +
                    $"OR department_name LIKE '%{search}%' " +
                    $"OR employment_type_name LIKE '%{search}%' " +
                    $"OR vacancy_status LIKE '%{search}%'";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }










        private void btnApply_Click(
 object sender,
 EventArgs e)
        {
            if (dgvJobVacancies.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                "Please select a job first.");

                return;
            }

            try
            {
                int jobVacancyId =
                Convert.ToInt32(
                dgvJobVacancies
                .SelectedRows[0]
                .Cells["job_vacancy_id"]
                .Value);

                string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

                using (MySqlConnection conn =
                new MySqlConnection(connString))
                {
                    conn.Open();

                    // =====================================
                    // GET APPLICANT ID
                    // =====================================
                    string applicantQuery =
                    @"SELECT applicant_id
            FROM Applicants
            ORDER BY applicant_id DESC
            LIMIT 1";

                    MySqlCommand applicantCmd =
                    new MySqlCommand(
                    applicantQuery,
                    conn);

                    object applicantResult =
                    applicantCmd.ExecuteScalar();

                    if (applicantResult == null)
                    {
                        MessageBox.Show(
                        "Please complete your profile first.");

                        return;
                    }

                    int applicantId =
                    Convert.ToInt32(
                    applicantResult);

                    string checkQuery =
                    @"SELECT COUNT(*)
            FROM Applications
            WHERE applicant_id = @applicantId
            AND job_vacancy_id = @jobId";

                    MySqlCommand checkCmd =
                    new MySqlCommand(
                    checkQuery,
                    conn);

                    checkCmd.Parameters.AddWithValue(
                    "@applicantId",
                    applicantId);

                    checkCmd.Parameters.AddWithValue(
                    "@jobId",
                    jobVacancyId);

                    int count =
                    Convert.ToInt32(
                    checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show(
                        "You already applied for this job.");

                        return;
                    }

  
                    string insertQuery =
                    @"INSERT INTO Applications
            (
                applicant_id,
                job_vacancy_id,
                application_status
            )
            VALUES
            (
                @applicantId,
                @jobId,
                'Submitted'
            )";

                    MySqlCommand insertCmd =
                    new MySqlCommand(
                    insertQuery,
                    conn);

                    insertCmd.Parameters.AddWithValue(
                    "@applicantId",
                    applicantId);

                    insertCmd.Parameters.AddWithValue(
                    "@jobId",
                    jobVacancyId);

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show(
                    "Application submitted successfully!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}


