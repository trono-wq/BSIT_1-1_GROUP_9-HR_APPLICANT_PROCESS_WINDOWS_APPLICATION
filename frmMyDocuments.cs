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
    public partial class frmMyDocuments : Form
    {
        private int applicantAccountId;

        public frmMyDocuments(int accountId)
        {
            InitializeComponent();
            applicantAccountId = accountId;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmMyDocuments_Load(object sender, EventArgs e)
        {
            LoadDocuments();
        }

        private void LoadDocuments()
        {
            dgvDocuments.Rows.Clear();

            dgvDocuments.Rows.Clear();

            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

            using (MySqlConnection conn =
                new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
                SELECT
                    rt.requirement_type_id,
                    rt.requirement_type_name,
                    IFNULL(ad.document_status, 'Missing')
                        AS document_status
                FROM Applications a

                INNER JOIN Applicants ap
                    ON a.applicant_id = ap.applicant_id

                INNER JOIN JobVacancies jv
                    ON a.job_vacancy_id = jv.job_vacancy_id

                INNER JOIN RequirementTypes rt
                    ON FIND_IN_SET(
                        rt.requirement_type_name,
                        REPLACE(jv.required_documents, ', ', ',')
                    ) > 0

                LEFT JOIN ApplicantDocuments ad
                    ON ad.requirement_type_id = rt.requirement_type_id
                    AND ad.application_id = a.application_id

                WHERE ap.applicant_account_id = @accountId

                ORDER BY rt.requirement_type_name";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@accountId",
                    applicantAccountId);

                using (MySqlDataReader reader =
                    cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvDocuments.Rows.Add(
                            reader["requirement_type_id"],
                            reader["requirement_type_name"],
                            reader["document_status"]);
                    }
                }
            }
        }
        private void UploadDocument(int requirementTypeId)
        {
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = openFileDialog1.FileName;

                string connString =
                    "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

                using (MySqlConnection conn =
                    new MySqlConnection(connString))
                {
                    conn.Open();

                    string getApplicationQuery = @"
                    SELECT a.application_id
                    FROM Applications a
                    INNER JOIN Applicants ap
                        ON a.applicant_id = ap.applicant_id
                    WHERE ap.applicant_account_id = @accountId
                    ORDER BY a.application_id DESC
                    LIMIT 1";

                    MySqlCommand appCmd =
                        new MySqlCommand(getApplicationQuery, conn);

                    appCmd.Parameters.AddWithValue(
                        "@accountId",
                        applicantAccountId);

                    object result = appCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show(
                            "Please apply for a job first.");
                        return;
                    }

                    int applicationId =
                        Convert.ToInt32(result);

                    string query = @"
                    INSERT INTO ApplicantDocuments
                    (
                        application_id,
                        requirement_type_id,
                        document_status,
                        o_file_path
                    )
                    VALUES
                    (
                        @applicationId,
                        @requirementTypeId,
                        'Submitted',
                        @filePath
                    )";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@applicationId",
                        applicationId);

                    cmd.Parameters.AddWithValue(
                        "@requirementTypeId",
                        requirementTypeId);

                    cmd.Parameters.AddWithValue(
                        "@filePath",
                        filePath);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Document uploaded successfully.");

                    LoadDocuments();
                }
            }
        }


        private void btnUploadDocument_Click(object sender,EventArgs e)
        {
            dgvDocuments.Rows.Clear();

            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

            using (MySqlConnection conn =
                new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
                SELECT
                    rt.requirement_type_id,
                    rt.requirement_type_name,
                    IFNULL(ad.document_status,'Missing')
                        AS document_status
                FROM RequirementTypes rt

                LEFT JOIN ApplicantDocuments ad
                    ON rt.requirement_type_id =
                        ad.requirement_type_id

                LEFT JOIN Applications a
                    ON ad.application_id =
                        a.application_id

                LEFT JOIN Applicants ap
                    ON a.applicant_id =
                        ap.applicant_id

                WHERE
                    ap.applicant_account_id = @accountId
                    OR ap.applicant_account_id IS NULL

                ORDER BY rt.requirement_type_name";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@accountId",
                    applicantAccountId);

                MySqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvDocuments.Rows.Add(
                        reader["requirement_type_id"],
                        reader["requirement_type_name"],
                        reader["document_status"]);
                }

                reader.Close();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.CurrentRow == null)
            {
                MessageBox.Show(
                    "Please select a document type.");
                return;
            }

            int requirementTypeId =
                Convert.ToInt32(
                    dgvDocuments.CurrentRow
                    .Cells["colRequirementTypeId"]
                    .Value);

            UploadDocument(requirementTypeId);
        }

        private void dgvDocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    