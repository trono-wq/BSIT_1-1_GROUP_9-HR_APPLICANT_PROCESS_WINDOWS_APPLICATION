using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmInterviewScheduling : Form
    {
        private int _applicationId;
        private Label lblApplicantNameValue;
        private Label lblPositionValue;
        private DateTimePicker dtpInterviewDate;
        private ComboBox cmbInterviewer;
        private TextBox txtModeLocation;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnClose;

        public frmInterviewScheduling()
        {
            InitializeComponent();
            SetupControls();
        }

        private void frmInterviewScheduling_Load(object sender, EventArgs e)
        {
        }

        public void SetApplicationId(int applicationId)
        {
            _applicationId = applicationId;
            LoadApplicantData();
            LoadInterviewers();
            AuditTrail.Log("Opened Interview Scheduling", "Application ID: " + _applicationId, "frmInterviewScheduling");
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
                        p.position_type_name
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
                        lblApplicantNameValue.Text = reader["pi_full_name"].ToString();
                        lblPositionValue.Text = reader["position_type_name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInterviewers()
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT user_id, email FROM Users WHERE role_id = 3";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    cmbInterviewer.Items.Clear();
                    cmbInterviewer.Items.Add("-- Select Interviewer --");
                    while (reader.Read())
                    {
                        cmbInterviewer.Items.Add(reader["email"].ToString());
                    }
                    cmbInterviewer.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading interviewers: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtModeLocation.Text.Trim() == "")
            {
                MessageBox.Show("Please enter mode/location.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpInterviewDate.Value <= DateTime.Now)
            {
                MessageBox.Show("Interview date must be in the future.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string scheduleStatus = cmbStatus.SelectedItem.ToString();
            string interviewer = cmbInterviewer.SelectedItem.ToString();

            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO InterviewSchedules 
                        (application_id, interview_date_time, mode_location, status) 
                        VALUES (@applicationId, @dateTime, @modeLocation, @status)
                        ON DUPLICATE KEY UPDATE
                        interview_date_time = @dateTime,
                        mode_location = @modeLocation,
                        status = @status";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    cmd.Parameters.AddWithValue("@dateTime", dtpInterviewDate.Value);
                    cmd.Parameters.AddWithValue("@modeLocation", txtModeLocation.Text.Trim());
                    cmd.Parameters.AddWithValue("@status", scheduleStatus);
                    cmd.ExecuteNonQuery();

                    string updateQuery = @"UPDATE Applications 
                        SET application_status = 'For Interview' 
                        WHERE application_id = @applicationId";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    updateCmd.ExecuteNonQuery();

                    string historyQuery = @"INSERT INTO ApplicationStatusHistory 
                        (application_id, old_status, new_status) 
                        VALUES (@applicationId, 'Shortlisted', 'For Interview')";
                    MySqlCommand historyCmd = new MySqlCommand(historyQuery, conn);
                    historyCmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    historyCmd.ExecuteNonQuery();

                    AuditTrail.Log("Saved Interview Schedule",
                        "Application ID: " + _applicationId +
                        " | Date: " + dtpInterviewDate.Value.ToString("yyyy-MM-dd HH:mm") +
                        " | Location: " + txtModeLocation.Text.Trim() +
                        " | Interviewer: " + interviewer +
                        " | Status: " + scheduleStatus,
                        "frmInterviewScheduling");

                    MessageBox.Show("Interview scheduled successfully!",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving schedule: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetupControls()
        {
            this.Text = "Interview Scheduling";
            this.Size = new Size(650, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblTitle = new Label();
            lblTitle.Text = "Interview Scheduling";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 51, 102);
            lblTitle.Location = new Point(20, 15);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            Label lblName = new Label();
            lblName.Text = "Applicant Name:";
            lblName.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblName.Location = new Point(20, 65);
            lblName.AutoSize = true;
            this.Controls.Add(lblName);

            lblApplicantNameValue = new Label();
            lblApplicantNameValue.Font = new System.Drawing.Font("Segoe UI", 10);
            lblApplicantNameValue.Location = new Point(170, 65);
            lblApplicantNameValue.AutoSize = true;
            this.Controls.Add(lblApplicantNameValue);

            Label lblPosition = new Label();
            lblPosition.Text = "Position:";
            lblPosition.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblPosition.Location = new Point(20, 95);
            lblPosition.AutoSize = true;
            this.Controls.Add(lblPosition);

            lblPositionValue = new Label();
            lblPositionValue.Font = new System.Drawing.Font("Segoe UI", 10);
            lblPositionValue.Location = new Point(170, 95);
            lblPositionValue.AutoSize = true;
            this.Controls.Add(lblPositionValue);

            Label lblDate = new Label();
            lblDate.Text = "Interview Date:";
            lblDate.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblDate.Location = new Point(20, 135);
            lblDate.AutoSize = true;
            this.Controls.Add(lblDate);

            dtpInterviewDate = new DateTimePicker();
            dtpInterviewDate.Font = new System.Drawing.Font("Segoe UI", 10);
            dtpInterviewDate.Location = new Point(170, 132);
            dtpInterviewDate.Size = new Size(250, 30);
            dtpInterviewDate.Format = DateTimePickerFormat.Custom;
            dtpInterviewDate.CustomFormat = "yyyy-MM-dd HH:mm";
            dtpInterviewDate.ShowUpDown = true;
            this.Controls.Add(dtpInterviewDate);

            Label lblInterviewer = new Label();
            lblInterviewer.Text = "Interviewer:";
            lblInterviewer.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblInterviewer.Location = new Point(20, 175);
            lblInterviewer.AutoSize = true;
            this.Controls.Add(lblInterviewer);

            cmbInterviewer = new ComboBox();
            cmbInterviewer.Font = new System.Drawing.Font("Segoe UI", 10);
            cmbInterviewer.Location = new Point(170, 172);
            cmbInterviewer.Size = new Size(250, 30);
            cmbInterviewer.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmbInterviewer);

            Label lblMode = new Label();
            lblMode.Text = "Mode/Location:";
            lblMode.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblMode.Location = new Point(20, 215);
            lblMode.AutoSize = true;
            this.Controls.Add(lblMode);

            txtModeLocation = new TextBox();
            txtModeLocation.Font = new System.Drawing.Font("Segoe UI", 10);
            txtModeLocation.Location = new Point(170, 212);
            txtModeLocation.Size = new Size(250, 30);
            this.Controls.Add(txtModeLocation);

            Label lblStatus = new Label();
            lblStatus.Text = "Schedule Status:";
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblStatus.Location = new Point(20, 255);
            lblStatus.AutoSize = true;
            this.Controls.Add(lblStatus);

            cmbStatus = new ComboBox();
            cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10);
            cmbStatus.Location = new Point(170, 252);
            cmbStatus.Size = new Size(200, 30);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new string[] { "Scheduled", "Completed", "Cancelled" });
            cmbStatus.SelectedIndex = 0;
            this.Controls.Add(cmbStatus);

            btnSave = new Button();
            btnSave.Text = "Save Schedule";
            btnSave.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnSave.Size = new Size(140, 35);
            btnSave.Location = new Point(20, 310);
            btnSave.BackColor = Color.FromArgb(0, 153, 76);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += new EventHandler(this.btnSave_Click);
            this.Controls.Add(btnSave);

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(510, 310);
            btnClose.BackColor = Color.FromArgb(128, 128, 128);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += new EventHandler(this.btnClose_Click);
            this.Controls.Add(btnClose);
        }
    }
}