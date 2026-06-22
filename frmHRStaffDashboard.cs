using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmHRStaffDashboard : Form
    {

        public frmHRStaffDashboard()
        {
            InitializeComponent();
        }

        private void label18_Click(object sender, EventArgs e) { }

        private void frmStaffDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query =
                    @"SELECT COUNT(*)
                    FROM JobVacancies
                    WHERE vacancy_status = 'Open'";

                    MySqlCommand cmd =
                    new MySqlCommand(
                    query,
                    conn);

                    int totalOpenJobs =
                    Convert.ToInt32(
                    cmd.ExecuteScalar());

                    txtOJV.Text =
                    totalOpenJobs.ToString();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmApplicantList AL = new frmApplicantList(frmApplicantList.ReviewTarget.ApplicantReview);
            AL.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmApplicantList AL = new frmApplicantList(frmApplicantList.ReviewTarget.Screening);
            AL.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmApplicantList AL = new frmApplicantList(frmApplicantList.ReviewTarget.InterviewScheduling);
            AL.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmApplicantList AL = new frmApplicantList(frmApplicantList.ReviewTarget.InterviewEvaluation);
            AL.Show();
            this.Hide();
        }
    }
}