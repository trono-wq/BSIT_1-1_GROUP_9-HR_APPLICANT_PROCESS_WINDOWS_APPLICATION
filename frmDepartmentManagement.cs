using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
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
        private void DepartmentForm_Load(
        object sender,
        EventArgs e)
        {
            LoadDepartments();

            dgvDepartments.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            dgvDepartments.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

            dgvDepartments.MultiSelect =
            false;
        }

        // =================== SECTION 26.3: ( LOAD DEPARTMENTS FROM DATABASE ) =========================================== //
        private void LoadDepartments()
        {
            try
            {
                MySqlConnection conn =
                new DatabaseConnection()
                .GetConnection();

                conn.Open();

                string query =
                @"SELECT
                department_id,
                department_name
                FROM Departments";

                MySqlDataAdapter adapter =
                new MySqlDataAdapter(
                query,
                conn);

                DataTable dt =
                new DataTable();

                adapter.Fill(dt);

                dgvDepartments.DataSource =
                dt;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }

        // =================== SECTION 26.4: ( CELL CLICK ) =========================================== //
        private void dgvDepartments_CellClick(
        object sender,
        DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                dgvDepartments.Rows[e.RowIndex];

                txtDepartmentName.Text =
                row.Cells["department_name"]
                .Value.ToString();
            }
        }

        // =================== SECTION 26.5: ( AUDIT TRAIL ) =========================================== //
        private void AddAuditTrail(
        string action)
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

                    MySqlCommand cmd =
                    new MySqlCommand(
                    query,
                    conn);

                    cmd.Parameters.AddWithValue(
                    "@userId",
                    UserSession.UserId);

                    cmd.Parameters.AddWithValue(
                    "@action",
                    action);

                    cmd.Parameters.AddWithValue(
                    "@table",
                    "Departments");

                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                ex.Message);
            }
        }

        // =================== SECTION 26.6: ( ADD DEPARTMENT ) =========================================== //
        private void btnAdd_Click_1(
        object sender,
        EventArgs e)
        {
            if (txtDepartmentName.Text.Trim() == "")
            {
                MessageBox.Show(
                "Please enter a department name!");

                return;
            }

            MySqlConnection conn =
            new DatabaseConnection()
            .GetConnection();

            conn.Open();

            string checkQuery =
            @"SELECT COUNT(*)
            FROM Departments
            WHERE LOWER(department_name)
            = LOWER(@name)";

            MySqlCommand checkCmd =
            new MySqlCommand(
            checkQuery,
            conn);

            checkCmd.Parameters.AddWithValue(
            "@name",
            txtDepartmentName.Text.Trim());

            int count =
            Convert.ToInt32(
            checkCmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show(
                "This department already exists!");

                conn.Close();

                return;
            }

            string query =
            @"INSERT INTO Departments
            (department_name, o_department_updated_by)
            VALUES
            (@name, @updatedBy)";

            MySqlCommand cmd =
            new MySqlCommand(
            query,
            conn);

            cmd.Parameters.AddWithValue(
            "@name",
            txtDepartmentName.Text.Trim());

            cmd.Parameters.AddWithValue(    
                "@updatedBy", UserSession.UserId);

            cmd.ExecuteNonQuery();

            AddAuditTrail(
            "Added Department");

            conn.Close();

            MessageBox.Show(
            "Department added successfully!");

            txtDepartmentName.Clear();

            LoadDepartments();
        }

        // =================== SECTION 26.7: ( EDIT DEPARTMENT ) =========================================== //
        private void btnEdit_Click_1(
        object sender,
        EventArgs e)
        {
            if (dgvDepartments.CurrentRow == null)
            {
                MessageBox.Show(
                "Please select a department to edit!");

                return;
            }

            if (txtDepartmentName.Text.Trim() == "")
            {
                MessageBox.Show(
                "Please enter a new department name!");

                return;
            }

            int id =
            Convert.ToInt32(
            dgvDepartments.CurrentRow
            .Cells["department_id"]
            .Value);

            MySqlConnection conn =
            new DatabaseConnection()
            .GetConnection();

            conn.Open();

            string checkQuery =
            @"SELECT COUNT(*)
            FROM Departments
            WHERE LOWER(department_name)
            = LOWER(@name)
            AND department_id <> @id";

            MySqlCommand checkCmd =
            new MySqlCommand(
            checkQuery,
            conn);

            checkCmd.Parameters.AddWithValue(
            "@name",
            txtDepartmentName.Text.Trim());

            checkCmd.Parameters.AddWithValue(
            "@id",
            id);

            int count =
            Convert.ToInt32(
            checkCmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show(
                "This department already exists!");

                conn.Close();

                return;
            }

            string query =
            @"UPDATE Departments
            SET department_name = @name
            o_department_updated_by = @updatedBy
            WHERE department_id = @id";

            MySqlCommand cmd =
            new MySqlCommand(
            query,
            conn);

            cmd.Parameters.AddWithValue(
            "@name",
            txtDepartmentName.Text.Trim());

            cmd.Parameters.AddWithValue(
            "@id",
            id);

            cmd.Parameters.AddWithValue(
                "@updatedBy", UserSession.UserId);

            cmd.ExecuteNonQuery();

            AddAuditTrail(
            "Edited Department");

            conn.Close();

            MessageBox.Show(
            "Department updated successfully!");

            txtDepartmentName.Clear();

            LoadDepartments();
        }

        // =================== SECTION 26.8: ( DELETE DEPARTMENT ) =========================================== //
        private void btnDelete_Click_1(
        object sender,
        EventArgs e)
        {
            if (dgvDepartments.CurrentRow == null)
            {
                MessageBox.Show(
                "Please select a department to delete!");

                return;
            }

            DialogResult confirm =
            MessageBox.Show(
            "Are you sure you want to delete this department?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                int id =
                Convert.ToInt32(
                dgvDepartments.CurrentRow
                .Cells["department_id"]
                .Value);

                MySqlConnection conn =
                new DatabaseConnection()
                .GetConnection();

                conn.Open();

                try
                {
                    // CHECK OPEN VACANCIES
                    string checkQuery =
                    @"SELECT COUNT(*)
                    FROM JobVacancies
                    WHERE department_id = @id
                    AND vacancy_status = 'Open'";

                    MySqlCommand checkCmd =
                    new MySqlCommand(
                    checkQuery,
                    conn);

                    checkCmd.Parameters.AddWithValue(
                    "@id",
                    id);

                    int openCount =
                    Convert.ToInt32(
                    checkCmd.ExecuteScalar());

                    if (openCount > 0)
                    {
                        MessageBox.Show(
                        "Cannot delete this department because there are active job vacancies using it.");

                        conn.Close();
                        return;
                    }

                    // DELETE CLOSED VACANCIES
                    string deleteVacanciesQuery =
                    @"DELETE FROM JobVacancies
                    WHERE department_id = @id
                    AND vacancy_status = 'Closed'";

                    MySqlCommand deleteVacanciesCmd =
                    new MySqlCommand(
                    deleteVacanciesQuery,
                    conn);

                    deleteVacanciesCmd.Parameters.AddWithValue(
                    "@id",
                    id);

                    deleteVacanciesCmd.ExecuteNonQuery();

                    // DELETE DEPARTMENT
                    string deleteDepartmentQuery =
                    @"DELETE FROM Departments
                    WHERE department_id = @id";

                    MySqlCommand deleteDepartmentCmd =
                    new MySqlCommand(
                    deleteDepartmentQuery,
                    conn);

                    deleteDepartmentCmd.Parameters.AddWithValue(
                    "@id",
                    id);

                    deleteDepartmentCmd.ExecuteNonQuery();

                    AddAuditTrail(
                    "Deleted Department");

                    conn.Close();

                    MessageBox.Show(
                    "Department deleted successfully!");

                    txtDepartmentName.Clear();

                    LoadDepartments();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(
                    ex.Message);
                }
            }
        }
        private void dgvDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
