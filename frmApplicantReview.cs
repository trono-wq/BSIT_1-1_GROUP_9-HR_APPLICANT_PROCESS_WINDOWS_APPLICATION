using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmApplicantReview : Form
    {
        private int _applicationId;

        public frmApplicantReview()
        {
            InitializeComponent();
            SetupControls();
        }

        public void SetApplicationId(int applicationId)
        {
            _applicationId = applicationId;
            LoadApplicantData();
            LoadDocuments();
            AuditTrail.Log("Viewed Applicant Profile", "Application ID: " + _applicationId, "frmApplicantReview");
        }

        private void LoadApplicantData()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                        ap.pi_full_name,
                        ap.education,
                        ap.skills,
                        ap.work_experience,
                        p.position_type_name,
                        a.application_status,
                        a.locked
                        FROM Applications a
                        JOIN Applicants ap ON a.applicant_id = ap.applicant_id
                        JOIN JobVacancies jv ON a.job_vacancy_id = jv.job_vacancy_id
                        JOIN PositionTypes p ON jv.position_type_id = p.position_type_id
                        WHERE a.application_id = @applicationId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblFullNameValue.Text = reader["pi_full_name"].ToString();
                        lblPositionValue.Text = reader["position_type_name"].ToString();
                        lblStatusValue.Text = reader["application_status"].ToString();
                        rtxtEducation.Text = reader["education"].ToString();
                        rtxtSkills.Text = reader["skills"].ToString();
                        rtxtWorkExp.Text = reader["work_experience"].ToString();

                        bool isLocked = Convert.ToBoolean(reader["locked"]);
                        if (isLocked)
                        {
                            btnLockReview.Enabled = false;
                            btnLockReview.Text = "Already Locked";
                            btnUnlock.Enabled = true;
                        }
                        else
                        {
                            btnLockReview.Enabled = true;
                            btnUnlock.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applicant data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDocuments()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 
                        rt.requirement_type_name AS 'Document Type',
                        ad.document_status AS 'Status',
                        ad.o_document_uploaded_at AS 'Uploaded At'
                        FROM ApplicantDocuments ad
                        JOIN RequirementTypes rt ON ad.requirement_type_id = rt.requirement_type_id
                        WHERE ad.application_id = @applicationId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@applicationId", _applicationId);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvDocuments.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading documents: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLockReview_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to lock this application for review?",
                "Confirm Lock", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseConnection db = new DatabaseConnection();
                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();

                        string query = @"UPDATE Applications 
                            SET application_status = 'Under Review', 
                            locked = TRUE 
                            WHERE application_id = @applicationId";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@applicationId", _applicationId);
                        cmd.ExecuteNonQuery();

                        string historyQuery = @"INSERT INTO ApplicationStatusHistory 
                            (application_id, old_status, new_status) 
                            VALUES (@applicationId, 'Submitted', 'Under Review')";
                        MySqlCommand historyCmd = new MySqlCommand(historyQuery, conn);
                        historyCmd.Parameters.AddWithValue("@applicationId", _applicationId);
                        historyCmd.ExecuteNonQuery();

                        AuditTrail.Log("Locked Application", "Application ID: " + _applicationId + " locked for review", "frmApplicantReview");

                        MessageBox.Show("Application locked successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lblStatusValue.Text = "Under Review";
                        btnLockReview.Enabled = false;
                        btnLockReview.Text = "Already Locked";
                        btnUnlock.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error locking application: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to unlock this application?",
                "Confirm Unlock", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseConnection db = new DatabaseConnection();
                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();

                        string query = @"UPDATE Applications 
                            SET application_status = 'Submitted', 
                            locked = FALSE 
                            WHERE application_id = @applicationId";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@applicationId", _applicationId);
                        cmd.ExecuteNonQuery();

                        AuditTrail.Log("Unlocked Application", "Application ID: " + _applicationId + " unlocked", "frmApplicantReview");

                        MessageBox.Show("Application unlocked successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lblStatusValue.Text = "Submitted";
                        btnLockReview.Enabled = true;
                        btnLockReview.Text = "Lock for Review";
                        btnUnlock.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error unlocking application: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetupControls()
        {
            this.Text = "Applicant Review";
            this.Size = new Size(800, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Title
            Label lblTitle = new Label();
            lblTitle.Text = "Applicant Review";
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 51, 102);
            lblTitle.Location = new Point(20, 15);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            // Full Name
            Label lblFullName = new Label();
            lblFullName.Text = "Full Name:";
            lblFullName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblFullName.Location = new Point(20, 60);
            lblFullName.AutoSize = true;
            this.Controls.Add(lblFullName);

            lblFullNameValue = new Label();
            lblFullNameValue.Font = new Font("Segoe UI", 10);
            lblFullNameValue.Location = new Point(150, 60);
            lblFullNameValue.AutoSize = true;
            this.Controls.Add(lblFullNameValue);

            // Position
            Label lblPosition = new Label();
            lblPosition.Text = "Position:";
            lblPosition.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPosition.Location = new Point(20, 90);
            lblPosition.AutoSize = true;
            this.Controls.Add(lblPosition);

            lblPositionValue = new Label();
            lblPositionValue.Font = new Font("Segoe UI", 10);
            lblPositionValue.Location = new Point(150, 90);
            lblPositionValue.AutoSize = true;
            this.Controls.Add(lblPositionValue);

            // Status
            Label lblStatus = new Label();
            lblStatus.Text = "Status:";
            lblStatus.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblStatus.Location = new Point(20, 120);
            lblStatus.AutoSize = true;
            this.Controls.Add(lblStatus);

            lblStatusValue = new Label();
            lblStatusValue.Font = new Font("Segoe UI", 10);
            lblStatusValue.Location = new Point(150, 120);
            lblStatusValue.AutoSize = true;
            this.Controls.Add(lblStatusValue);

            // Education
            Label lblEducation = new Label();
            lblEducation.Text = "Education:";
            lblEducation.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblEducation.Location = new Point(20, 160);
            lblEducation.AutoSize = true;
            this.Controls.Add(lblEducation);

            rtxtEducation = new RichTextBox();
            rtxtEducation.Location = new Point(20, 180);
            rtxtEducation.Size = new Size(350, 80);
            rtxtEducation.ReadOnly = true;
            rtxtEducation.Font = new Font("Segoe UI", 10);
            this.Controls.Add(rtxtEducation);

            // Skills
            Label lblSkills = new Label();
            lblSkills.Text = "Skills:";
            lblSkills.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblSkills.Location = new Point(400, 160);
            lblSkills.AutoSize = true;
            this.Controls.Add(lblSkills);

            rtxtSkills = new RichTextBox();
            rtxtSkills.Location = new Point(400, 180);
            rtxtSkills.Size = new Size(350, 80);
            rtxtSkills.ReadOnly = true;
            rtxtSkills.Font = new Font("Segoe UI", 10);
            this.Controls.Add(rtxtSkills);

            // Work Experience
            Label lblWorkExp = new Label();
            lblWorkExp.Text = "Work Experience:";
            lblWorkExp.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblWorkExp.Location = new Point(20, 275);
            lblWorkExp.AutoSize = true;
            this.Controls.Add(lblWorkExp);

            rtxtWorkExp = new RichTextBox();
            rtxtWorkExp.Location = new Point(20, 295);
            rtxtWorkExp.Size = new Size(730, 80);
            rtxtWorkExp.ReadOnly = true;
            rtxtWorkExp.Font = new Font("Segoe UI", 10);
            this.Controls.Add(rtxtWorkExp);

            // Documents
            Label lblDocs = new Label();
            lblDocs.Text = "Submitted Documents:";
            lblDocs.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblDocs.Location = new Point(20, 390);
            lblDocs.AutoSize = true;
            this.Controls.Add(lblDocs);

            dgvDocuments = new DataGridView();
            dgvDocuments.Location = new Point(20, 410);
            dgvDocuments.Size = new Size(730, 120);
            dgvDocuments.BackgroundColor = Color.White;
            dgvDocuments.AllowUserToAddRows = false;
            dgvDocuments.ReadOnly = true;
            dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDocuments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 51, 102);
            dgvDocuments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDocuments.RowHeadersVisible = false;
            this.Controls.Add(dgvDocuments);

            // Lock Button
            btnLockReview = new Button();
            btnLockReview.Text = "Lock for Review";
            btnLockReview.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnLockReview.Size = new Size(150, 35);
            btnLockReview.Location = new Point(20, 545);
            btnLockReview.BackColor = Color.FromArgb(255, 140, 0);
            btnLockReview.ForeColor = Color.White;
            btnLockReview.FlatStyle = FlatStyle.Flat;
            btnLockReview.Click += new EventHandler(this.btnLockReview_Click);
            this.Controls.Add(btnLockReview);

            // Unlock Button
            btnUnlock = new Button();
            btnUnlock.Text = "Unlock";
            btnUnlock.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnUnlock.Size = new Size(100, 35);
            btnUnlock.Location = new Point(180, 545);
            btnUnlock.BackColor = Color.FromArgb(0, 120, 215);
            btnUnlock.ForeColor = Color.White;
            btnUnlock.FlatStyle = FlatStyle.Flat;
            btnUnlock.Enabled = false;
            btnUnlock.Click += new EventHandler(this.btnUnlock_Click);
            this.Controls.Add(btnUnlock);

            // Close Button
            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(650, 545);
            btnClose.BackColor = Color.FromArgb(128, 128, 128);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += new EventHandler(this.btnClose_Click);
            this.Controls.Add(btnClose);
        }

        private Label lblFullNameValue;
        private Label lblPositionValue;
        private Label lblStatusValue;
        private RichTextBox rtxtEducation;
        private RichTextBox rtxtSkills;
        private RichTextBox rtxtWorkExp;
        private DataGridView dgvDocuments;
        private Button btnLockReview;
        private Button btnUnlock;
        private Button btnClose;

    }
}