using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmEmploymentTypeForm : Form
    {
        // ======================================== SECTION 27.1: ( FORM INITIALIZATION ) =================================== //
        public frmEmploymentTypeForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(EmploymentTypeForm_Load);
        }

        // ======================================== SECTION 27.2: ( FORM LOAD ) ============================================ //
        private void EmploymentTypeForm_Load(
        object sender,
        EventArgs e)
        {
            LoadEmploymentTypes();

            dgvEmploymentTypes.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            dgvEmploymentTypes.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

            dgvEmploymentTypes.MultiSelect =
            false;
        }

        // =================== SECTION 27.3: ( LOAD EMPLOYMENT TYPES FROM DATABASE ) =========================================== //
        private void LoadEmploymentTypes()
        {
            try
            {
                MySqlConnection conn =
                new DatabaseConnection()
                .GetConnection();

                conn.Open();

                string query =
                @"SELECT
                employment_type_id,
                employment_type_name
                FROM EmploymentTypes";

                MySqlDataAdapter adapter =
                new MySqlDataAdapter(query, conn);

                DataTable dt =
                new DataTable();

                adapter.Fill(dt);

                dgvEmploymentTypes.DataSource =
                dt;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =================== SECTION 27.4: ( AUDIT TRAIL ) =========================================== //
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

                    MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                    "@userId",
                    UserSession.UserId);

                    cmd.Parameters.AddWithValue(
                    "@action",
                    action);

                    cmd.Parameters.AddWithValue(
                    "@table",
                    "EmploymentTypes");

                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =================== SECTION 27.5: ( ADD EMPLOYMENT TYPE ) ========================================================= //
        private void btnAdd_Click_1(
        object sender,
        EventArgs e)
        {
            if (txtEmploymentTypeName.Text.Trim() == "")
            {
                MessageBox.Show(
                "Please enter an employment type name!");

                return;
            }

            MySqlConnection conn =
            new DatabaseConnection()
            .GetConnection();

            conn.Open();

            string checkQuery =
            @"SELECT COUNT(*)
            FROM EmploymentTypes
            WHERE LOWER(employment_type_name)
            = LOWER(@name)";

            MySqlCommand checkCmd =
            new MySqlCommand(checkQuery, conn);

            checkCmd.Parameters.AddWithValue(
            "@name",
            txtEmploymentTypeName.Text.Trim());

            int count =
            Convert.ToInt32(
            checkCmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show(
                "This employment type already exists!");

                conn.Close();
                return;
            }

            string query =
            @"INSERT INTO EmploymentTypes
            (employment_type_name)
            VALUES
            (@name)";

            MySqlCommand cmd =
            new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
            "@name",
            txtEmploymentTypeName.Text.Trim());

            cmd.ExecuteNonQuery();

            AddAuditTrail(
            "Added Employment Type");

            conn.Close();

            MessageBox.Show(
            "Employment type added successfully!");

            txtEmploymentTypeName.Clear();

            LoadEmploymentTypes();

            foreach (Form form in
            Application.OpenForms)
            {
                if (form is
                frmHRManagerAdminDashboard dashboard)
                {
                    dashboard.RefreshDashboard();
                }
            }
        }

        // =================== SECTION 27.6: ( EDIT EMPLOYMENT TYPE ) ======================================================== //
        private void btnEdit_Click_1(
        object sender,
        EventArgs e)
        {
            if (dgvEmploymentTypes.CurrentRow == null)
            {
                MessageBox.Show(
                "Please select an employment type to edit!");

                return;
            }

            if (txtEmploymentTypeName.Text.Trim() == "")
            {
                MessageBox.Show(
                "Please enter a new employment type name!");

                return;
            }

            int id =
            Convert.ToInt32(
            dgvEmploymentTypes.CurrentRow
            .Cells["employment_type_id"]
            .Value);

            MySqlConnection conn =
            new DatabaseConnection()
            .GetConnection();

            conn.Open();

            string checkQuery =
            @"SELECT COUNT(*)
            FROM EmploymentTypes
            WHERE LOWER(employment_type_name)
            = LOWER(@name)
            AND employment_type_id <> @id";

            MySqlCommand checkCmd =
            new MySqlCommand(checkQuery, conn);

            checkCmd.Parameters.AddWithValue(
            "@name",
            txtEmploymentTypeName.Text.Trim());

            checkCmd.Parameters.AddWithValue(
            "@id",
            id);

            int count =
            Convert.ToInt32(
            checkCmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show(
                "This employment type already exists!");

                conn.Close();
                return;
            }

            string query =
            @"UPDATE EmploymentTypes
            SET employment_type_name = @name
            WHERE employment_type_id = @id";

            MySqlCommand cmd =
            new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
            "@name",
            txtEmploymentTypeName.Text.Trim());

            cmd.Parameters.AddWithValue(
            "@id",
            id);

            cmd.ExecuteNonQuery();

            AddAuditTrail(
            "Edited Employment Type");

            conn.Close();

            MessageBox.Show(
            "Employment type updated successfully!");

            txtEmploymentTypeName.Clear();

            LoadEmploymentTypes();

            foreach (Form form in
            Application.OpenForms)
            {
                if (form is
                frmHRManagerAdminDashboard dashboard)
                {
                    dashboard.RefreshDashboard();
                }
            }
        }

        // =================== SECTION 27.7: ( DELETE EMPLOYMENT TYPE ) ========================================================= //
        private void btnDelete_Click_1(
        object sender,
        EventArgs e)
        {
            if (dgvEmploymentTypes.CurrentRow == null)
            {
                MessageBox.Show(
                "Please select an employment type to delete!");

                return;
            }

            DialogResult confirm =
            MessageBox.Show(
            "Are you sure you want to delete this employment type?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                int id =
                Convert.ToInt32(
                dgvEmploymentTypes.CurrentRow
                .Cells["employment_type_id"]
                .Value);

                MySqlConnection conn =
                new DatabaseConnection()
                .GetConnection();

                conn.Open();

                try
                {
                    string checkQuery =
                    @"SELECT COUNT(*)
                    FROM JobVacancies
                    WHERE employment_type_id = @id
                    AND vacancy_status = 'Open'";

                    MySqlCommand checkCmd =
                    new MySqlCommand(checkQuery, conn);

                    checkCmd.Parameters.AddWithValue(
                    "@id",
                    id);

                    int openCount =
                    Convert.ToInt32(
                    checkCmd.ExecuteScalar());

                    if (openCount > 0)
                    {
                        MessageBox.Show(
                        "Cannot delete this employment type because there are active job vacancies using it.");

                        conn.Close();
                        return;
                    }

                    string deleteVacanciesQuery =
                    @"DELETE FROM JobVacancies
                    WHERE employment_type_id = @id
                    AND vacancy_status = 'Closed'";

                    MySqlCommand deleteVacanciesCmd =
                    new MySqlCommand(deleteVacanciesQuery, conn);

                    deleteVacanciesCmd.Parameters.AddWithValue(
                    "@id",
                    id);

                    deleteVacanciesCmd.ExecuteNonQuery();

                    string query =
                    @"DELETE FROM EmploymentTypes
                    WHERE employment_type_id = @id";

                    MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                    "@id",
                    id);

                    cmd.ExecuteNonQuery();

                    AddAuditTrail(
                    "Deleted Employment Type");

                    conn.Close();

                    MessageBox.Show(
                    "Employment type deleted successfully!");

                    txtEmploymentTypeName.Clear();

                    LoadEmploymentTypes();

                    foreach (Form form in
                    Application.OpenForms)
                    {
                        if (form is
                        frmHRManagerAdminDashboard dashboard)
                        {
                            dashboard.RefreshDashboard();
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // =================== SECTION 27.8: ( CELL CLICK ) =========================================== //
        private void dgvEmploymentTypes_CellClick(
        object sender,
        DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                dgvEmploymentTypes.Rows[e.RowIndex];

                txtEmploymentTypeName.Text =
                row.Cells["employment_type_name"]
                .Value.ToString();
            }
        }

        private void label2_Click(
        object sender,
        EventArgs e)
        {

        }
    }
}


