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
using static Mysqlx.Datatypes.Scalar.Types;

namespace COMP_003_CAPSTONE
{
    public partial class frmHRManagerAdminDashboard : Form
    {
        public frmHRManagerAdminDashboard()
        {
            InitializeComponent();
        }

        public void RefreshDashboard()
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

                    MySqlCommand cmd = new MySqlCommand (query, conn);

                    int totalOpenJobs = Convert.ToInt32 (cmd.ExecuteScalar());

                    txtOJV.Text = totalOpenJobs.ToString();

                    if (comboBox1.SelectedItem != null)
                    {
                        string tableName = comboBox1.Text;

                        string tableQuery = $"SELECT * FROM {tableName}";

                        MySqlDataAdapter adapter = new MySqlDataAdapter (tableQuery, conn);

                        DataTable dt = new DataTable();

                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show ("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmJobVacancyManagement vacancyForm = new frmJobVacancyManagement();
            vacancyForm.Show();
        }

        private void frmHRDashboard_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("ApplicantAccounts");
            comboBox1.Items.Add("ApplicantDocuments");
            comboBox1.Items.Add("Applicants");
            comboBox1.Items.Add("ApplicationStatusHistory");
            comboBox1.Items.Add("Applications");
            comboBox1.Items.Add("AssessmentScores");
            comboBox1.Items.Add("AssessmentTypes");
            comboBox1.Items.Add("AuditTrail");
            comboBox1.Items.Add("Departments");
            comboBox1.Items.Add("EmploymentTypes");
            comboBox1.Items.Add("HiringDecisions");
            comboBox1.Items.Add("InterviewEvaluations");
            comboBox1.Items.Add("InterviewSchedules");
            comboBox1.Items.Add("InterviewTypes");
            comboBox1.Items.Add("JobVacancies");
            comboBox1.Items.Add("PositionTypes");
            comboBox1.Items.Add("RequirementTypes");
            comboBox1.Items.Add("Roles");
            comboBox1.Items.Add("ScreeningResults");
            comboBox1.Items.Add("Users");

            RefreshDashboard();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string tableName = comboBox1.Text;

                    string query = $"SELECT * FROM {tableName}";

                    MySqlDataAdapter adapter = new MySqlDataAdapter (query, conn);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show ("Error: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmAddHRUsers addHRUserForm = new FrmAddHRUsers();
            addHRUserForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmHiringDecision HD = new frmHiringDecision();
            HD.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmReports RP = new frmReports();
            RP.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmMaintenanceManagement MT = new frmMaintenanceManagement();
            MT.Show();
        }

        private void label6_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void txtOJV_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


