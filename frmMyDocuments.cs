using System;
using System.Data;
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

        // =========================
        // LOAD DOCUMENTS
        // =========================
        private void LoadDocuments()
        {
            dgvDocuments.Rows.Clear();

            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
                SELECT
                    rt.requirement_type_id,
                    rt.requirement_type_name,
                    IFNULL(ad.document_status, 'Missing') AS document_status
                FROM Applications a

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

                WHERE a.application_id = @applicationId
                ORDER BY rt.requirement_type_name";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@applicationId", applicantAccountId);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvDocuments.Rows.Add(
                        reader["requirement_type_id"],
                        reader["requirement_type_name"],
                        reader["document_status"]
                    );
                }
            }
        }

        // =========================
        // UPLOAD DOCUMENT
        // =========================
        private void UploadDocument(int requirementTypeId)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            string filePath = openFileDialog1.FileName;

            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

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

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@applicationId", applicantAccountId);
                cmd.Parameters.AddWithValue("@requirementTypeId", requirementTypeId);
                cmd.Parameters.AddWithValue("@filePath", filePath);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Document uploaded successfully.");

                LoadDocuments();
            }
        }

        // =========================
        // BUTTON UPLOAD
        // =========================
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.CurrentRow == null)
            {
                MessageBox.Show("Please select a document type.");
                return;
            }

            int requirementTypeId =
                Convert.ToInt32(dgvDocuments.CurrentRow.Cells["colRequirementTypeId"].Value);

            UploadDocument(requirementTypeId);
        }

        // =========================
        // BACK BUTTON
        // =========================
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmApplicantDashboard dashboard =
                new frmApplicantDashboard(applicantAccountId);

            dashboard.Show();
            this.Hide();
        }
    }
}


