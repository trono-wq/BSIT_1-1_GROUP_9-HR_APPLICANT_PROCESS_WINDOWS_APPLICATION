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
using HRApplicantProcessSystem.Database;
namespace COMP_003_CAPSTONE
{
    public partial class frmApplicantRegistration : Form
    {
        public frmApplicantRegistration()
        {
            InitializeComponent();
        }

    private void frmApplicantRegistration_Load(object sender, EventArgs e)
    {
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmApplicantLogin login = new frmApplicantLogin();
            login.Show();
            this.Hide();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(
                txtEmail.Text.Trim(),
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }
            try
            {
                if (txtEmail.Text == "" || txtPassword.Text == "" || txtConfirmPassword.Text == "")
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.");
                    return;
                }

                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Check if email already exists
                    string checkQuery = @"SELECT COUNT(*) 
                                  FROM ApplicantAccounts 
                                  WHERE email = @email";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Email already exists.");
                        return;
                    }

                    // Insert new account
                    string insertQuery = @"INSERT INTO ApplicantAccounts
                                  (email, password, account_status)
                                  VALUES
                                  (@email, @password, 'Active')";

                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Account created successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
