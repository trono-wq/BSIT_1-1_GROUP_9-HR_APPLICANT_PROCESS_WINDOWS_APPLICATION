using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmApplicantList : Form
    {
        public frmApplicantList()
        {
            InitializeComponent();
            SetupControls();
        }

        private void SetupControls()
        {
            this.Text = "HR Applicant List";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblTitle = new Label();
            lblTitle.Text = "Applicant List";
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 51, 102);
            lblTitle.Location = new Point(20, 20);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            Label lblSearch = new Label();
            lblSearch.Text = "Search:";
            lblSearch.Font = new Font("Segoe UI", 10);
            lblSearch.Location = new Point(20, 65);
            lblSearch.AutoSize = true;
            this.Controls.Add(lblSearch);

            txtSearch = new TextBox();
            txtSearch.Font = new Font("Segoe UI", 10);
            txtSearch.Location = new Point(80, 62);
            txtSearch.Size = new Size(250, 30);
            this.Controls.Add(txtSearch);

            Label lblStatus = new Label();
            lblStatus.Text = "Status:";
            lblStatus.Font = new Font("Segoe UI", 10);
            lblStatus.Location = new Point(350, 65);
            lblStatus.AutoSize = true;
            this.Controls.Add(lblStatus);

            cmbStatus = new ComboBox();
            cmbStatus.Font = new Font("Segoe UI", 10);
            cmbStatus.Location = new Point(410, 62);
            cmbStatus.Size = new Size(180, 30);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new string[] { "All", "Submitted", "Under Review", "Shortlisted", "For Interview", "Rejected", "For Final Review" });
            cmbStatus.SelectedIndex = 0;
            this.Controls.Add(cmbStatus);

            btnSearch = new Button();
            btnSearch.Text = "Search";
            btnSearch.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSearch.Size = new Size(90, 30);
            btnSearch.Location = new Point(600, 61);
            btnSearch.BackColor = Color.FromArgb(0, 120, 215);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Click += new EventHandler(this.btnSearch_Click);
            this.Controls.Add(btnSearch);

            dgvApplicants = new DataGridView();
            dgvApplicants.Location = new Point(20, 110);
            dgvApplicants.Size = new Size(840, 380);
            dgvApplicants.BackgroundColor = Color.White;
            dgvApplicants.AllowUserToAddRows = false;
            dgvApplicants.AllowUserToDeleteRows = false;
            dgvApplicants.ReadOnly = true;
            dgvApplicants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplicants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplicants.BorderStyle = BorderStyle.Fixed3D;
            dgvApplicants.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 51, 102);
            dgvApplicants.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvApplicants.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvApplicants.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvApplicants.RowHeadersVisible = false;
            this.Controls.Add(dgvApplicants);

            btnReview = new Button();
            btnReview.Text = "Review Applicant";
            btnReview.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnReview.Size = new Size(160, 35);
            btnReview.Location = new Point(20, 505);
            btnReview.BackColor = Color.FromArgb(0, 153, 76);
            btnReview.ForeColor = Color.White;
            btnReview.FlatStyle = FlatStyle.Flat;
            btnReview.Click += new EventHandler(this.btnReview_Click);
            this.Controls.Add(btnReview);
        }

        private void frmApplicantList_Load(object sender, EventArgs e)
        {
            LoadApplicants();
            AuditTrail.Log("Viewed Applicant List", "HR Staff opened the applicant list", "frmApplicantList");
        }

        private void LoadApplicants(string search = "", string status = "All")
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                        a.application_id,
                        ap.pi_full_name AS 'Full Name',
                        jv.position AS 'Position',
                        a.application_status AS 'Status',
                        a.o_application_updated_at AS 'Last Updated'
                        FROM Applications a
                        JOIN Applicants ap ON a.applicant_id = ap.applicant_id
                        JOIN JobVacancies jv ON a.job_vacancy_id = jv.job_vacancy_id
                        WHERE 1=1";

                    if (search != "")
                        query += " AND ap.pi_full_name LIKE @search";
                    if (status != "All")
                        query += " AND a.application_status = @status";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    if (search != "")
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                    if (status != "All")
                        cmd.Parameters.AddWithValue("@status", status);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvApplicants.DataSource = dt;

                    if (dgvApplicants.Columns["application_id"] != null)
                        dgvApplicants.Columns["application_id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applicants: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim();
            string status = cmbStatus.SelectedItem.ToString();
            LoadApplicants(search, status);
            AuditTrail.Log("Searched Applicants", "Search: " + search + " | Status: " + status, "frmApplicantList");
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            if (dgvApplicants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an applicant first.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int applicationId = Convert.ToInt32(dgvApplicants.SelectedRows[0].Cells["application_id"].Value);
            AuditTrail.Log("Opened Applicant Review", "Application ID: " + applicationId, "frmApplicantList");
            frmApplicantReview review = new frmApplicantReview();
            review.SetApplicationId(applicationId);
            review.Show();
        }

        private TextBox txtSearch;
        private ComboBox cmbStatus;
        private Button btnSearch;
        private Button btnReview;
        private DataGridView dgvApplicants;
    }
}