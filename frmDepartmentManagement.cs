using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmDepartmentForm : Form
    {
        // ======================================== SECTION 26.1: ( FORM INITIALIZATION ) =================================== //
        public frmDepartmentForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(DepartmentForm_Load);
        }

        // ======================================== SECTION 26.2: ( FORM LOAD ) ============================================ //
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            dgvDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =================== SECTION 26.3: ( LOAD DEPARTMENTS FROM DATABASE ) =========================================== //
        private void LoadDepartments()
        {
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "SELECT department_id, department_name FROM Departments";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvDepartments.DataSource = dt;
            conn.Close();
        }
        private void AddAuditTrail(string action)
        {
            try
            {
                DatabaseConnection db =
                new DatabaseConnection();

                using (MySqlConnection conn =
                db.GetConnection())
                {
                    conn.Open();

                    string query =
                    @"INSERT INTO AuditTrail
                    (
                        user_id,
                        action,
                        affected_table,
                        affected_record_id
                    )
                    VALUES
                    (
                        @userId,
                        @action,
                        @table,
                        NULL
                    )";

                    MySqlCommand cmd = new MySqlCommand (query, conn);

                    cmd.Parameters.AddWithValue ("@userId", UserSession.UserId);
                    cmd.Parameters.AddWithValue ("@action", action);
                    cmd.Parameters.AddWithValue("@table", "Departments");

                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =================== SECTION 26.4: ( ADD DEPARTMENT ) =================================================================== //
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (txtDepartmentName.Text == "")
            {
                MessageBox.Show("Please enter a department name!");
                return;
            }

            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();

            string checkQuery = @"SELECT COUNT(*)
            FROM Departments
            WHERE LOWER(department_name)
            = LOWER(@name)";

            MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);

            checkCmd.Parameters.AddWithValue ("@name", txtDepartmentName.Text.Trim());

            int count = Convert.ToInt32 (checkCmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show ("This department already exists!");
                conn.Close();
                return;
            }

            string query = @"INSERT INTO Departments
            (department_name)
            VALUES (@name)";

            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
            "@name",
            txtDepartmentName.Text.Trim());

            cmd.ExecuteNonQuery();

            AddAuditTrail ("Added department");

            conn.Close();

            MessageBox.Show("Department added successfully!");
            txtDepartmentName.Text = "";
            LoadDepartments();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmHRManagerAdminDashboard dashboard)
                {
                    dashboard.RefreshDashboard();
                }
            }
        }
        // =================== SECTION 26.5: ( EDIT DEPARTMENT ) ========================================================= //
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a department to edit!");
                return;
            }
            if (txtDepartmentName.Text == "")
            {
                MessageBox.Show("Please enter a new department name!");
                return;
            }

            int id = Convert.ToInt32(dgvDepartments.SelectedRows[0].Cells["department_id"].Value);

            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();

            string checkQuery = @"SELECT COUNT(*)
            FROM Departments
            WHERE LOWER(department_name) = LOWER(@name)
            AND department_id <> @id";

            MySqlCommand checkCmd =
            new MySqlCommand(checkQuery, conn);

            checkCmd.Parameters.AddWithValue ("@name", txtDepartmentName.Text.Trim());
            checkCmd.Parameters.AddWithValue ("@id", id);

            int count = Convert.ToInt32 (checkCmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show ("This department already exists!");
                conn.Close();
                return;
            }
            
            string query = "UPDATE Departments SET department_name = @name WHERE department_id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtDepartmentName.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            AddAuditTrail ("Edited department");

            conn.Close();
            MessageBox.Show("Department updated successfully!");
            txtDepartmentName.Text = "";
            LoadDepartments();

            foreach (Form form in Application.OpenForms)
            {
                if (form is frmHRManagerAdminDashboard dashboard)
                {
                    dashboard.RefreshDashboard();
                }
            }
        }

        // =================== SECTION 26.6: ( DELETE DEPARTMENT ) ===================================================== //
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a department to delete!");
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this department?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvDepartments.SelectedRows[0].Cells["department_id"].Value);
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = "DELETE FROM Departments WHERE department_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                AddAuditTrail ("Deleted department");
                
                conn.Close();
                MessageBox.Show("Department deleted successfully!");
                LoadDepartments();

                foreach (Form form in Application.OpenForms)
                {
                    if (form is frmHRManagerAdminDashboard dashboard)
                    {
                        dashboard.RefreshDashboard();
                    }
                }
            }
        }
    }
}