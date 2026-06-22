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
        }

        public frmMyDocuments()
        {
            InitializeComponent();
        }

        private void frmMyDocuments_Load(object sender, EventArgs e)
        {
            LoadDocuments();
            CheckIfLocked();
        }

        private void LoadDocuments()
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
                    rt.requirement_type_name,
                    ad.document_status
                FROM applicantdocuments ad
                INNER JOIN requirementtypes rt
                    ON ad.requirement_type_id = rt.requirement_type_id
                INNER JOIN applications a
                    ON ad.application_id = a.application_id
                INNER JOIN applicants ap
                    ON a.applicant_id = ap.applicant_id
                WHERE ap.applicant_account_id = @accountId
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
                        reader["requirement_type_name"].ToString(),
                        reader["document_status"].ToString());
                }

                reader.Close();
            }
        }
        private void CheckIfLocked()
        {
            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

            using (MySqlConnection conn =
                new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
        SELECT locked
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

                object result =
                    cmd.ExecuteScalar();

                if (result != null &&
                    Convert.ToBoolean(result))
                {
                    btnUploadResume.Enabled = false;
                    btnUploadTranscript.Enabled = false;
                    btnUploadID.Enabled = false;
                    btnUploadCertificate.Enabled = false;

                    MessageBox.Show(
                        "Documents are locked because HR has started reviewing your application.");
                }
            }
        }
        private void UploadDocument(int requirementTypeId)
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
                 FROM applications a
                 INNER JOIN applicants ap
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

                string checkQuery = @"
                SELECT applicant_document_id
                FROM applicantdocuments
                WHERE application_id = @applicationId
                AND requirement_type_id = @requirementTypeId";

                MySqlCommand checkCmd =
                    new MySqlCommand(checkQuery, conn);

                checkCmd.Parameters.AddWithValue(
                    "@applicationId",
                    applicationId);

                checkCmd.Parameters.AddWithValue(
                    "@requirementTypeId",
                    requirementTypeId);

                object existingDoc =
                    checkCmd.ExecuteScalar();

                if (existingDoc != null)
                {
                    string updateQuery = @"
                    UPDATE applicantdocuments
                    SET
                        document_status = 'Submitted',
                        o_file_path = @filePath
                    WHERE applicant_document_id = @docId";

                    MySqlCommand updateCmd =
                        new MySqlCommand(updateQuery, conn);

                    updateCmd.Parameters.AddWithValue(
                        "@filePath",
                        filePath);

                    updateCmd.Parameters.AddWithValue(
                        "@docId",
                        existingDoc);

                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    string insertQuery = @"
                    INSERT INTO applicantdocuments
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

                    MySqlCommand insertCmd =
                        new MySqlCommand(insertQuery, conn);

                    insertCmd.Parameters.AddWithValue(
                        "@applicationId",
                        applicationId);

                    insertCmd.Parameters.AddWithValue(
                        "@requirementTypeId",
                        requirementTypeId);

                    insertCmd.Parameters.AddWithValue(
                        "@filePath",
                        filePath);

                    insertCmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Document uploaded successfully.");

                LoadDocuments();
            }
        }
        private void btnUploadResume_Click(object sender, EventArgs e)
        {
            UploadDocument(1);
        }

        private void btnUploadTranscript_Click(object sender, EventArgs e)
        {
            UploadDocument(2);
        }

        private void btnUploadID_Click(object sender, EventArgs e)
        {
            UploadDocument(6);
        }

        private void btnUploadCertificate_Click(object sender, EventArgs e)
        {
            UploadDocument(7);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmApplicantDashboard dashboard =
                new frmApplicantDashboard(applicantAccountId);

            dashboard.Show();
            this.Hide();
        }

        private void dgvDocuments_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {

        }

        private void btnUploadNBI_Click(object sender, EventArgs e)
        {
            UploadDocument(5);
        }
    }
}    
