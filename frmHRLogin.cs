using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmHRLogin : Form
    {
        // FORMS

        public frmHRLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmHRLogin_Load(object sender, EventArgs e)
        {
            lblChangePassword.Visible = false;
            lblOldPassword.Visible = false;
            lblNewPassword.Visible = false;
            lblConfirmNewPassword.Visible = false;
            lblEmail.Visible = false;
            txtOldPassword.Visible = false;
            txtNewPassword.Visible = false;
            txtConfirmNewPassword.Visible = false;
            txtEmail2.Visible = false;
            btnConfirmNewPassword.Visible = false;
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

        private void frmHRLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void ClearHRLogin()
        {
            txtEmail.Clear();
            txtPassword.Clear();
        }

        // BUTTONS

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string emailCheckQuery =
                    @"SELECT COUNT(*)
                    FROM Users
                    WHERE email = @email";

                    MySqlCommand emailCheckCmd = new MySqlCommand(emailCheckQuery, conn);
                    emailCheckCmd.Parameters.AddWithValue ("@email", txtEmail.Text.Trim());
                    int emailCount = Convert.ToInt32(emailCheckCmd.ExecuteScalar());

                    if (emailCount == 0)
                    {
                        MessageBox.Show("Email not found.");
                        return;
                    }

                    string query = 
                    @"SELECT u.user_id,
                    r.role_name
                    FROM Users u
                    INNER JOIN Roles r
                    ON u.role_id = r.role_id
                    WHERE u.email = @email
                    AND u.password = @password";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int userId = Convert.ToInt32(reader["user_id"]);

                        UserSession.UserId = userId;
                        UserSession.Email = txtEmail.Text.Trim();

                        string role = reader["role_name"].ToString();
                        reader.Close();

                        string updateQuery = @"UPDATE Users
                        SET o_last_user_login_at = NOW()
                        WHERE user_id = @userId";

                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@userId", userId);
                        updateCmd.ExecuteNonQuery();

                        if (role == "HR Manager / Admin")
                        {
                            frmHRManagerAdminDashboard HRManagerAdminDashboard = new frmHRManagerAdminDashboard();
                            HRManagerAdminDashboard.Show();
                            this.Hide();
                        }

                        else if (role == "HR Staff")
                        {
                            frmHRStaffDashboard HRStaffDashboard = new frmHRStaffDashboard();
                            HRStaffDashboard.Show();
                            this.Hide();
                        }
                    }

                    else
                    {
                        MessageBox.Show("Invalid password.");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnChangeToNewPassword_Click(object sender, EventArgs e)
        {
            lblChangePassword.Visible = true;
            lblOldPassword.Visible = true;
            lblNewPassword.Visible = true;
            lblConfirmNewPassword.Visible = true;
            lblEmail.Visible = true;
            txtOldPassword.Visible = true;
            txtNewPassword.Visible = true;
            txtConfirmNewPassword.Visible = true;
            txtEmail2.Visible = true;
            btnConfirmNewPassword.Visible = true;
        }

        private void btnConfirmNewPassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmNewPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (txtOldPassword.Text == txtNewPassword.Text)
            {
                MessageBox.Show("New password cannot be the same as the old password.");
                return;
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string emailCheckQuery =
                    @"SELECT COUNT(*)
                    FROM Users
                    WHERE email = @email";

                    MySqlCommand emailCheckCmd = new MySqlCommand(emailCheckQuery, conn);
                    emailCheckCmd.Parameters.AddWithValue("@email", txtEmail2.Text.Trim());
                    int emailCount = Convert.ToInt32(emailCheckCmd.ExecuteScalar());

                    if (emailCount == 0)
                    {
                        MessageBox.Show("Email not found.");
                        return;
                    }

                    string checkQuery = @"SELECT user_id
                    FROM Users
                    WHERE email = @email
                    AND password = @password";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@email", txtEmail2.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@password", txtOldPassword.Text.Trim());
                    object result = checkCmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Old password is incorrect.");
                        return;
                    }

                    string updateQuery = @"UPDATE Users
                    SET password = @newPassword
                    WHERE user_id = @userId";

                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@newPassword", txtNewPassword.Text.Trim());
                    updateCmd.Parameters.AddWithValue("@userId", Convert.ToInt32(result));
                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Password changed successfully!");

                    lblChangePassword.Visible = false;
                    lblOldPassword.Visible = false;
                    lblNewPassword.Visible = false;
                    lblConfirmNewPassword.Visible = false;
                    lblEmail.Visible = false;
                    txtOldPassword.Visible = false;
                    txtNewPassword.Visible = false;
                    txtConfirmNewPassword.Visible = false;
                    txtEmail2.Visible = false;
                    btnConfirmNewPassword.Visible = false;
                    txtEmail2.Clear();
                    txtOldPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmNewPassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // OTHERS

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }

            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
