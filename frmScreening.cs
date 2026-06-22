using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmScreening : Form
    {
        private int _applicationId;

        public frmScreening()
        {
            InitializeComponent();
            SetupControls();
        }

        public void SetApplicationId(int applicationId)
        {
            _applicationId = applicationId;
            LoadApplicantData();
            AuditTrail.Log("Opened Screening", "Application ID: " + _applicationId, "frmScreening");
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
            if (cmbResult.SelectedItem == null)
            {
                MessageBox.Show("Please select a screening result.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string result = cmbResult.SelectedItem.ToString();
            string remarks = rtxtRemarks.Text.Trim();

            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO ScreeningResults 
                        (application_id, screening_result, remarks) 
                        VALUES (@applicationId, @result, @remarks)
                        ON DUPLICATE KEY UPDATE 
                        screening_result = @result, 
                        remarks = @remarks";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    cmd.Parameters.AddWithValue("@result", result);
                    cmd.Parameters.AddWithValue("@remarks", remarks);
                    cmd.ExecuteNonQuery();

                    string newStatus = result == "Qualified" ? "Shortlisted" : "Rejected";

                    string updateQuery = @"UPDATE Applications 
                        SET application_status = @status 
                        WHERE application_id = @applicationId";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@status", newStatus);
                    updateCmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    updateCmd.ExecuteNonQuery();

                    string historyQuery = @"INSERT INTO ApplicationStatusHistory 
                        (application_id, old_status, new_status) 
                        VALUES (@applicationId, 'Under Review', @newStatus)";
                    MySqlCommand historyCmd = new MySqlCommand(historyQuery, conn);
                    historyCmd.Parameters.AddWithValue("@applicationId", _applicationId);
                    historyCmd.Parameters.AddWithValue("@newStatus", newStatus);
                    historyCmd.ExecuteNonQuery();

                    AuditTrail.Log("Saved Screening Result", "Application ID: " + _applicationId + " | Result: " + result + " | New Status: " + newStatus, "frmScreening");

                    MessageBox.Show("Screening result saved! Status updated to: " + newStatus,
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving screening result: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetupControls()
        {
            this.Text = "Screening";
            this.Size = new Size(600, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblTitle = new Label();
            lblTitle.Text = "Applicant Screening";
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 51, 102);
            lblTitle.Location = new Point(20, 15);
            lblTitle.AutoSize = true;
            this.Controls.Add(lblTitle);

            Label lblName = new Label();
            lblName.Text = "Applicant Name:";
            lblName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblName.Location = new Point(20, 65);
            lblName.AutoSize = true;
            this.Controls.Add(lblName);

            lblApplicantNameValue = new Label();
            lblApplicantNameValue.Font = new Font("Segoe UI", 10);
            lblApplicantNameValue.Location = new Point(170, 65);
            lblApplicantNameValue.AutoSize = true;
            this.Controls.Add(lblApplicantNameValue);

            Label lblPosition = new Label();
            lblPosition.Text = "Position:";
            lblPosition.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPosition.Location = new Point(20, 95);
            lblPosition.AutoSize = true;
            this.Controls.Add(lblPosition);

            lblPositionValue = new Label();
            lblPositionValue.Font = new Font("Segoe UI", 10);
            lblPositionValue.Location = new Point(170, 95);
            lblPositionValue.AutoSize = true;
            this.Controls.Add(lblPositionValue);

            Label lblResult = new Label();
            lblResult.Text = "Screening Result:";
            lblResult.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblResult.Location = new Point(20, 135);
            lblResult.AutoSize = true;
            this.Controls.Add(lblResult);

            cmbResult = new ComboBox();
            cmbResult.Font = new Font("Segoe UI", 10);
            cmbResult.Location = new Point(170, 132);
            cmbResult.Size = new Size(200, 30);
            cmbResult.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbResult.Items.AddRange(new string[] { "Qualified", "Not Qualified" });
            cmbResult.SelectedIndex = 0;
            this.Controls.Add(cmbResult);

            Label lblRemarks = new Label();
            lblRemarks.Text = "Remarks:";
            lblRemarks.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblRemarks.Location = new Point(20, 175);
            lblRemarks.AutoSize = true;
            this.Controls.Add(lblRemarks);

            rtxtRemarks = new RichTextBox();
            rtxtRemarks.Location = new Point(20, 195);
            rtxtRemarks.Size = new Size(540, 150);
            rtxtRemarks.Font = new Font("Segoe UI", 10);
            this.Controls.Add(rtxtRemarks);

            btnSave = new Button();
            btnSave.Text = "Save Result";
            btnSave.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSave.Size = new Size(130, 35);
            btnSave.Location = new Point(20, 365);
            btnSave.BackColor = Color.FromArgb(0, 153, 76);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += new EventHandler(this.btnSave_Click);
            this.Controls.Add(btnSave);

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(460, 365);
            btnClose.BackColor = Color.FromArgb(128, 128, 128);
            btnClose.ForeColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += new EventHandler(this.btnClose_Click);
            this.Controls.Add(btnClose);
        }

        private Label lblApplicantNameValue;
        private Label lblPositionValue;
        private ComboBox cmbResult;
        private RichTextBox rtxtRemarks;
        private Button btnSave;
        private Button btnClose;
    }
}