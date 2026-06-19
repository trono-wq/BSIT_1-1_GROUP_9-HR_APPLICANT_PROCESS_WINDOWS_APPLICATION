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

        private void button1_Click(object sender, EventArgs e)
        {
            frmApplicantList AL = new frmApplicantList();
            AL.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmApplicantReview AR = new frmApplicantReview();
            AR.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmScreening SCR = new frmScreening();
            SCR.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmInterviewScheduling IS = new frmInterviewScheduling();
            IS.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmInterviewEvaluation IE = new frmInterviewEvaluation();
            IE.Show();
        }
        private void txtOJV_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void txtRA_Click(object sender, EventArgs e) { }
        private void txtFI_Click(object sender, EventArgs e) { }
        private void txtS_Click(object sender, EventArgs e) { }
        private void txtUR_Click(object sender, EventArgs e) { }
        private void txtPA_Click(object sender, EventArgs e) { } 
        private void txtTA_Click(object sender, EventArgs e) { }
        private void txtAA_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { } 
        private void label8_Click(object sender, EventArgs e) { } 
        private void label7_Click(object sender, EventArgs e) { } 
        private void label5_Click(object sender, EventArgs e) { } 
        private void label4_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }       
    }
}
