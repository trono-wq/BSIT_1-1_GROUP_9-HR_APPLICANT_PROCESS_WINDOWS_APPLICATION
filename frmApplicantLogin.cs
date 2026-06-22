using System;
using System.Windows.Forms;
using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;

namespace COMP_003_CAPSTONE
{
    public partial class frmApplicantLogin : Form
    {
        public frmApplicantLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;    
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT applicant_account_id
                             FROM ApplicantAccounts
                             WHERE email = @email
                             AND password = @password
                             AND account_status = 'Active'";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string updateLogin =
                            @"UPDATE ApplicantAccounts
                      SET o_last_account_login_at = NOW()
                      WHERE applicant_account_id = @id";

                        MySqlCommand updateCmd =
                            new MySqlCommand(updateLogin, conn);

                        updateCmd.Parameters.AddWithValue("@id", result);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Login Successful!");

                        frmApplicantDashboard dashboard =
                            new frmApplicantDashboard();

                        dashboard.Show();
                        this.Hide(); 
                    }
                    else
                    {
                        MessageBox.Show(
                            "Invalid email/password or account inactive.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmApplicantRegistration AR = new frmApplicantRegistration();
            AR.Show();
            this.Hide();
        }

        private void frmApplicantLogin_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

            string connString =
        "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=1234;";

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"SELECT applicant_account_id
                 FROM ApplicantAccounts
                 WHERE email = @user
                 AND password = @pass";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@user", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show("Login Successful!");

                    int applicantAccountId =
                        Convert.ToInt32(result);

                    frmApplicantDashboard dashboard =
                        new frmApplicantDashboard(applicantAccountId);

                    dashboard.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Email or Password");
                }
            }
        }

            

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            frmApplicantRegistration AR = new frmApplicantRegistration();
            AR.Show();
            this.Hide();    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmChangePassword cp =
                new frmChangePassword();

            cp.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmGeneralLogin)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }
    }
    }
    