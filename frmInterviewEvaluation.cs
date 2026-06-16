using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmInterviewEvaluation : Form
    {
        private int _applicationId;
        private Label lblApplicantNameValue;
        private Label lblPositionValue;
        private TextBox txtScore;
        private RichTextBox rtxtRemarks;
        private RichTextBox rtxtRecommendations;
        private ComboBox cmbResult;
        private Button btnSave;
        private Button btnClose;

        public frmInterviewEvaluation()
        {
            InitializeComponent();
            SetupControls();
        }

        public void SetApplicationId(int applicationId)
        {
            _applicationId = applicationId;
            LoadApplicantData();
            AuditTrail.Log("Opened Interview Evaluation", "Application ID: " + _applicationId, "frmInterviewEvaluation");
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
                        jv.position
                        FROM Applications a
                        JOIN Applicants ap ON a.applicant_id = ap.applicant_id
                        JOIN JobVacancies jv ON a.job_vacancy_id = jv.job_vacancy_id
                        WHERE a.application_id = @applicationId";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblApplicantNameValue.Text = reader["pi_full_name"].ToString();
                        lblPositionValue.Text = reader["position"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtScore.Text.Trim() == "")
            {
                MessageBox.Show("Please enter a score.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int score;
            if (!int.TryParse(txtScore.Text.Trim(), out score) || score < 0 || score > 100)
            {
                MessageBox.Show("Please enter a valid score between 0 and 100.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string result = cmbResult.SelectedItem.ToString();
            string remarks = rtxtRemarks.Text.Trim();
            string recommendations = rtxtRecommendations.Text.Trim();

            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO InterviewEvaluations 
                        (application_id, interview_score, interview_remarks, 
                        interview_evaluation_result, recommendations) 
                        VALUES (@applicationId, @score, @remarks, @result, @recommendations)
                        ON DUPLICATE KEY UPDATE
                        interview_score = @score,
                        interview_remarks = @remarks,
                        interview_evaluation_result = @result,
                        recommendations = @recommendations";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    cmd.Parameters.AddWithValue("@score", score);
                    cmd.Parameters.AddWithValue("@remarks", remarks);
                    cmd.Parameters.AddWithValue("@result", result);
                    cmd.Parameters.AddWithValue("@recommendations", recommendations);
                    cmd.ExecuteNonQuery();

                    string newStatus = result == "Pass" ? "For Final Review" : "Rejected";

                    string updateQuery = @"UPDATE Applications 
                        SET application_status = @status 
                        WHERE application_id = @applicationId";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@status", newStatus);
                    updateCmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    updateCmd.ExecuteNonQuery();

                    string historyQuery = @"INSERT INTO ApplicationStatusHistory 
                        (application_id, old_status, new_status) 
                        VALUES (@applicationId, 'For Interview', @newStatus)";
                    MySqlCommand historyCmd = new MySqlCommand(historyQuery, conn);
                    historyCmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    historyCmd.Parameters.AddWithValue("@newStatus", newStatus);
                    historyCmd.ExecuteNonQuery();

                    string scheduleQuery = @"UPDATE InterviewSchedules 
                        SET status = 'Completed' 
                        WHERE application_id = @applicationId";
                    MySqlCommand scheduleCmd = new MySqlCommand(scheduleQuery, conn);
                    scheduleCmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    scheduleCmd.ExecuteNonQuery();

                    AuditTrail.Log("Saved Interview Evaluation",
                        "Application ID: " + _applicationId +
                        " | Score: " + score +
                        " | Result: " + result +
                        " | New Status: " + newStatus,
                        "frmInterviewEvaluation");

                    MessageBox.Show("Evaluation saved! Status updated to: " + newStatus,
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving evaluation: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetupControls()
        {
            this.Text = "Interview Evaluation";
            this.Size = new Size(650, 580);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblTitle = new Label();
            lblTitle.Text = "Interview Evaluation";
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

            Label lblScore = new Label();
            lblScore.Text = "Score (0-100):";
            lblScore.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblScore.Location = new Point(20, 135);
            lblScore.AutoSize = true;
            this.Controls.Add(lblScore);

            txtScore = new TextBox();
            txtScore.Font = new System.Drawing.Font("Segoe UI", 10);
            txtScore.Location = new Point(170, 132);
            txtScore.Size = new Size(100, 30);
            this.Controls.Add(txtScore);

            Label lblResult = new Label();
            lblResult.Text = "Result:";
            lblResult.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblResult.Location = new Point(20, 175);
            lblResult.AutoSize = true;
            this.Controls.Add(lblResult);

            cmbResult = new ComboBox();
            cmbResult.Font = new System.Drawing.Font("Segoe UI", 10);
            cmbResult.Location = new Point(170, 172);
            cmbResult.Size = new Size(150, 30);
            cmbResult.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResult.Items.AddRange(new string[] { "Pass", "Fail" });
            cmbResult.SelectedIndex = 0;
            this.Controls.Add(cmbResult);

            Label lblRemarks = new Label();
            lblRemarks.Text = "Remarks:";
            lblRemarks.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblRemarks.Location = new Point(20, 215);
            lblRemarks.AutoSize = true;
            this.Controls.Add(lblRemarks);

            rtxtRemarks = new RichTextBox();
            rtxtRemarks.Location = new Point(20, 235);
            rtxtRemarks.Size = new Size(590, 100);
            rtxtRemarks.Font = new System.Drawing.Font("Segoe UI", 10);
            this.Controls.Add(rtxtRemarks);

            Label lblRecommendations = new Label();
            lblRecommendations.Text = "Recommendations:";
            lblRecommendations.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            lblRecommendations.Location = new Point(20, 345);
            lblRecommendations.AutoSize = true;
            this.Controls.Add(lblRecommendations);

            rtxtRecommendations = new RichTextBox();
            rtxtRecommendations.Location = new Point(20, 365);
            rtxtRecommendations.Size = new Size(590, 100);
            rtxtRecommendations.Font = new System.Drawing.Font("Segoe UI", 10);
            this.Controls.Add(rtxtRecommendations);

            btnSave = new Button();
            btnSave.Text = "Save Evaluation";
            btnSave.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnSave.Size = new Size(150, 35);
            btnSave.Location = new Point(20, 480);
            btnSave.BackColor = Color.FromArgb(0, 153, 76);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += new EventHandler(this.btnSave_Click);
            this.Controls.Add(btnSave);

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(510, 480);
            btnClose.BackColor = Color.FromArgb(128, 128, 128);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += new EventHandler(this.btnClose_Click);
            this.Controls.Add(btnClose);
        }
    }
}