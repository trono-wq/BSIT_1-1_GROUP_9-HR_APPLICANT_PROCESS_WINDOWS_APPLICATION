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
    public partial class frmMyProfile : Form
    {
        string connString = "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=09303281417Ms;";
        private int applicantAccountId;

        public frmMyProfile()
        {
            InitializeComponent();
        }
        public frmMyProfile(int accountId)
        {
            InitializeComponent();
            applicantAccountId = accountId;
        }
        private void CheckIfLocked()
        {
            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=09303281417Ms;";

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

                object result = cmd.ExecuteScalar();

                if (result != null &&
                    Convert.ToBoolean(result))
                {
                    btnSave.Enabled = false;

                    MessageBox.Show(
                        "Profile is locked because HR has started reviewing your application.");
                }
            }
        }
        private void LoadProfile()
        {
            string query = "SELECT * FROM Applicants WHERE applicant_account_id=@id";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", applicantAccountId);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtFullName.Text = reader["pi_full_name"].ToString();

                    dtpDOB.Value =
                        Convert.ToDateTime(reader["pi_date_of_birth"]);

                    cmbGender.Text =
                        reader["pi_gender"].ToString();

                    cmbCivilStatus.Text =
                        reader["pi_civil_status"].ToString();

                    txtNationality.Text =
                        reader["pi_nationality"].ToString();

                    txtAddress.Text =
                        reader["address"].ToString();

                    txtContact.Text =
                        reader["contact"].ToString();

                    txtEducation.Text =
                        reader["education"].ToString();

                    txtSkills.Text =
                        reader["skills"].ToString();

                    txtExperience.Text =
                        reader["work_experience"].ToString();
                }
            }
        }
        private void frmMyProfile_Load(object sender, EventArgs e)
        {
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            cmbGender.Items.Add("Prefer not say");

            cmbCivilStatus.Items.Add("Single");
            cmbCivilStatus.Items.Add("Married");

            LoadProfile();
            CheckIfLocked();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(
                 txtContact.Text,
                 @"^09\d{9}$"))
            {
                MessageBox.Show(
                    "Please enter a valid Philippine mobile number.\nExample: 09123456789");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string checkQuery =
                    "SELECT COUNT(*) FROM Applicants WHERE applicant_account_id=@id";

                MySqlCommand checkCmd =
                    new MySqlCommand(checkQuery, conn);

                checkCmd.Parameters.AddWithValue("@id", applicantAccountId);

                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                string query;

                if (count > 0)
                {
                    query = @"UPDATE Applicants SET
                pi_full_name=@fullname,
                pi_date_of_birth=@dob,
                pi_gender=@gender,
                pi_civil_status=@civil,
                pi_nationality=@nationality,
                address=@address,
                contact=@contact,
                education=@education,
                skills=@skills,
                work_experience=@experience
                WHERE applicant_account_id=@accountId";
                }
                else
                {
                    query = @"INSERT INTO Applicants
            (
                applicant_account_id,
                pi_full_name,
                pi_date_of_birth,
                pi_gender,
                pi_civil_status,
                pi_nationality,
                address,
                contact,
                education,
                skills,
                work_experience
            )
            VALUES
            (
                @accountId,
                @fullname,
                @dob,
                @gender,
                @civil,
                @nationality,
                @address,
                @contact,
                @education,
                @skills,
                @experience
            )";
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@accountId", applicantAccountId);
                cmd.Parameters.AddWithValue("@fullname", txtFullName.Text);
                cmd.Parameters.AddWithValue("@dob", dtpDOB.Value.Date);
                cmd.Parameters.AddWithValue("@gender", cmbGender.Text);
                cmd.Parameters.AddWithValue("@civil", cmbCivilStatus.Text);
                cmd.Parameters.AddWithValue("@nationality", txtNationality.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@education", txtEducation.Text);
                cmd.Parameters.AddWithValue("@skills", txtSkills.Text);
                cmd.Parameters.AddWithValue("@experience", txtExperience.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Profile saved successfully!");
            }
        }
    }
}


