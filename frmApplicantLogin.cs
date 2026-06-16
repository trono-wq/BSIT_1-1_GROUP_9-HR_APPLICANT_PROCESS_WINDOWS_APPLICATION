using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmApplicantRegistration AR = new frmApplicantRegistration();
            AR.Show();
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
 "server=localhost;port=3306;database=hr_applicant_process_window_application;user id=root;password=1234;";





            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MessageBox.Show(conn.ConnectionString);

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

                    frmApplicantDashboard dashboard = new frmApplicantDashboard();
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
        }
    }
    }
    