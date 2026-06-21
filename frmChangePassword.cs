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
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }
        private int applicantAccountId;

        public frmChangePassword(int accountId)
        {
            InitializeComponent();
            applicantAccountId = accountId;
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=09303281417Ms;";

            using (MySqlConnection conn =
                new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
                UPDATE ApplicantAccounts
                SET
                    password = @newPassword,
                    o_last_account_password_update = CURRENT_TIMESTAMP
                WHERE
                    email = @email
                AND
                    password = @currentPassword";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@email",
                    txtEmail.Text);

                cmd.Parameters.AddWithValue(
                    "@currentPassword",
                    txtCurrentPassword.Text);

                cmd.Parameters.AddWithValue(
                    "@newPassword",
                    txtNewPassword.Text);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show(
                        "Password changed successfully!");

                    txtEmail.Clear();
                    txtCurrentPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                }
                else
                {
                    MessageBox.Show(
                        "Invalid email or current password.");
                }
            }
        }
        

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string connString =
                "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=09303281417Ms;";

            using (MySqlConnection conn =
                new MySqlConnection(connString))
            {
                conn.Open();

                string query = @"
                UPDATE ApplicantAccounts
                SET
                     password = @newPassword,
                     o_last_account_password_update = CURRENT_TIMESTAMP
                WHERE
                     email = @email
                AND
                     password = @currentPassword";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@email",
                    txtEmail.Text);

                cmd.Parameters.AddWithValue(
                    "@currentPassword",
                    txtCurrentPassword.Text);

                cmd.Parameters.AddWithValue(
                    "@newPassword",
                    txtNewPassword.Text);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show(
                        "Password changed successfully!");

                    txtEmail.Clear();
                    txtCurrentPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                }
                else
                {
                    MessageBox.Show(
                        "Invalid email or current password.");
                }
            }
        }
       
         private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
