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

public partial class frmApplicationStatus : Form
{
    private int applicantAccountId;

    public frmApplicationStatus()
    {
        InitializeComponent();
        }

        public frmApplicationStatus(int accountId)
        {
            InitializeComponent();
            applicantAccountId = accountId;
        }
        private void LoadStatusHistory()
        {
            dgvApplicationStatus.Rows.Clear();

            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

            using (MySqlConnection conn =
                new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
                SELECT
                   ash.new_status,
                   ash.updated_at
                FROM ApplicationStatusHistory ash
                INNER JOIN Applications a
                   ON ash.application_id = a.application_id
                INNER JOIN Applicants ap
                   ON a.applicant_id = ap.applicant_id
                WHERE ap.applicant_account_id = @accountId
                ORDER BY ash.updated_at";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@accountId",
                    applicantAccountId);

                MySqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvApplicationStatus.Rows.Add(
                        reader["new_status"].ToString(),
                        Convert.ToDateTime(
                            reader["updated_at"])
                            .ToString("MMM dd, yyyy hh:mm tt")
                    );
                }
            }
        }


        private void frmApplicationStatus_Load(object sender, EventArgs e)
        {
            LoadStatusHistory();
        }

        private void dgvApplicationStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmApplicantDashboard dashboard =
                new frmApplicantDashboard(applicantAccountId);

            dashboard.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvApplicationStatus_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
