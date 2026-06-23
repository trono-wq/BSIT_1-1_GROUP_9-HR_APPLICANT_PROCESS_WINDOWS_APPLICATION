using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmHRManagerAdminDashboard : Form
    {
        // FORMS

        public frmHRManagerAdminDashboard()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmHRManagerAdminDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SHOW TABLES";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        cmbDatabases.Items.Add(reader.GetString(0));
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmHRLogin HRL)
                {
                    HRL.ClearHRLogin();
                    form.Show();
                    break;
                }
            }
            this.Close();
        }

        public void ClearHRManagerAdminDashboard()
        {
            cmbDatabases.SelectedIndex = -1;
            dataGridView1.DataSource = null;
        }

        // BUTTONS

        private void btnJobVacancyManagement_Click(object sender, EventArgs e)
        {
            frmJobVacancyManagement vacancyForm = new frmJobVacancyManagement();
            vacancyForm.Show();
            this.Hide();
        }

        private void btnHiringDecision_Click(object sender, EventArgs e)
        {
            frmHiringDecision HiringDecision = new frmHiringDecision();
            HiringDecision.Show();
            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmReports Reports = new frmReports();
            Reports.Show();
            this.Hide();
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            frmMaintenance Maintenance = new frmMaintenance();
            Maintenance.Show();
            this.Hide();
        }

        private void btnAddHRUsers_Click(object sender, EventArgs e)
        {
            FrmAddHRUsers addHRUserForm = new FrmAddHRUsers();
            addHRUserForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmApplicantList list = new frmApplicantList(frmApplicantList.ReviewTarget.MA);
            list.Show();
            this.Hide();
        }

        // OTHERS

        private void cmbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    if (cmbDatabases.SelectedIndex == -1)
                    {
                        return;
                    }   
                    conn.Open();
                    string tableName = cmbDatabases.Text;
                    string query = $"SELECT * FROM {tableName}";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


    }
}


