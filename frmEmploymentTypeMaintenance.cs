using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmEmploymentTypeMaintenance : Form
    {
        // ======================================== SECTION 27.1: ( FORM INITIALIZATION ) =================================== //
        public frmEmploymentTypeMaintenance()
        {
            InitializeComponent();
            this.Load += new EventHandler(EmploymentTypeForm_Load);
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        // ======================================== SECTION 27.2: ( FORM LOAD ) ============================================ //
        private void EmploymentTypeForm_Load(object sender, EventArgs e)
        {
            LoadEmploymentTypes();
            dgvEmploymentTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =================== SECTION 27.3: ( LOAD EMPLOYMENT TYPES FROM DATABASE ) =========================================== //
        private void LoadEmploymentTypes()
        {
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "SELECT employment_type_id, employment_type_name FROM EmploymentTypes";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvEmploymentTypes.DataSource = dt;
            conn.Close();
        }

        // =================== SECTION 27.4: ( ADD EMPLOYMENT TYPE ) ========================================================= //
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (txtEmploymentTypeName.Text == "")
            {
                MessageBox.Show("Please enter an employment type name!");
                return;
            }
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "INSERT INTO EmploymentTypes (employment_type_name) VALUES (@name)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtEmploymentTypeName.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Employment type added successfully!");
            txtEmploymentTypeName.Text = "";
            LoadEmploymentTypes();
        }

        // =================== SECTION 27.5: ( EDIT EMPLOYMENT TYPE ) ======================================================== //
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvEmploymentTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employment type to edit!");
                return;
            }
            if (txtEmploymentTypeName.Text == "")
            {
                MessageBox.Show("Please enter a new employment type name!");
                return;
            }
            int id = Convert.ToInt32(dgvEmploymentTypes.SelectedRows[0].Cells["employment_type_id"].Value);
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "UPDATE EmploymentTypes SET employment_type_name = @name WHERE employment_type_id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtEmploymentTypeName.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Employment type updated successfully!");
            txtEmploymentTypeName.Text = "";
            LoadEmploymentTypes();
        }

        // =================== SECTION 27.6: ( DELETE EMPLOYMENT TYPE ) ========================================================= //
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvEmploymentTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employment type to delete!");
                return;
            }
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this employment type?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvEmploymentTypes.SelectedRows[0].Cells["employment_type_id"].Value);
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = "DELETE FROM EmploymentTypes WHERE employment_type_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Employment type deleted successfully!");
                LoadEmploymentTypes();
            }
        }

        // =================== SECTION 27.7: ( BACK ) ========================================================= //
        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmMaintenance)
                {
                    form.Show();
                    break;
                }
            }
            this.Close();
        }
    }
}