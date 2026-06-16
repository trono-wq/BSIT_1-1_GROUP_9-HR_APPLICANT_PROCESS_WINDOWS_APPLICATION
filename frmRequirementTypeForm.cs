using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmRequirementTypeForm : Form
    {
        // ======================================== SECTION 28.1: ( FORM INITIALIZATION ) =================================== //
        public frmRequirementTypeForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(RequirementTypeForm_Load);
        }

        // ======================================== SECTION 28.2: ( FORM LOAD ) ============================================ //
        private void RequirementTypeForm_Load(
        object sender,
        EventArgs e)
        {
            LoadRequirementTypes();

            dgvRequirementTypes.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            dgvRequirementTypes.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

            dgvRequirementTypes.MultiSelect =
            false;
        }

        // =================== SECTION 28.3: ( LOAD REQUIREMENT TYPES FROM DATABASE ) =========================================== //
        private void LoadRequirementTypes()
        {
            try
            {
                MySqlConnection conn =
                new DatabaseConnection()
                .GetConnection();

                conn.Open();

                string query =
                @"SELECT
                requirement_type_id,
                requirement_type_name
                FROM RequirementTypes";

                MySqlDataAdapter adapter =
                new MySqlDataAdapter(query, conn);

                DataTable dt =
                new DataTable();

                adapter.Fill(dt);

                dgvRequirementTypes.DataSource =
                dt;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =================== SECTION 28.4: ( AUDIT TRAIL ) =========================================== //
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
                    "RequirementTypes");

                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =================== SECTION 28.5: ( ADD REQUIREMENT TYPE ) =========================================================== //
        private void button1_Click(
        object sender,
        EventArgs e)
        {
            if (txtRequirementTypeName.Text.Trim() == "")
            {
                MessageBox.Show(
                "Please enter a requirement type name!");

                return;
            }

            MySqlConnection conn =
            new DatabaseConnection()
            .GetConnection();

            conn.Open();

            string checkQuery =
            @"SELECT COUNT(*)
            FROM RequirementTypes
            WHERE LOWER(requirement_type_name)
            = LOWER(@name)";

            MySqlCommand checkCmd =
            new MySqlCommand(checkQuery, conn);

            checkCmd.Parameters.AddWithValue(
            "@name",
            txtRequirementTypeName.Text.Trim());

            int count =
            Convert.ToInt32(
            checkCmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show(
                "This requirement type already exists!");

                conn.Close();
                return;
            }

            string query =
            @"INSERT INTO RequirementTypes
            (requirement_type_name)
            VALUES
            (@name)";

            MySqlCommand cmd =
            new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
            "@name",
            txtRequirementTypeName.Text.Trim());

            cmd.ExecuteNonQuery();

            AddAuditTrail(
            "Added Requirement Type");

            conn.Close();

            MessageBox.Show(
            "Requirement type added successfully!");

            txtRequirementTypeName.Clear();

            LoadRequirementTypes();

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

        // =================== SECTION 28.6: ( EDIT REQUIREMENT TYPE ) ========================================================== //
        private void button2_Click(
        object sender,
        EventArgs e)
        {
            if (dgvRequirementTypes.CurrentRow == null)
            {
                MessageBox.Show(
                "Please select a requirement type to edit!");

                return;
            }

            if (txtRequirementTypeName.Text.Trim() == "")
            {
                MessageBox.Show(
                "Please enter a new requirement type name!");

                return;
            }

            int id =
            Convert.ToInt32(
            dgvRequirementTypes.CurrentRow
            .Cells["requirement_type_id"]
            .Value);

            MySqlConnection conn =
            new DatabaseConnection()
            .GetConnection();

            conn.Open();

            string checkQuery =
            @"SELECT COUNT(*)
            FROM RequirementTypes
            WHERE LOWER(requirement_type_name)
            = LOWER(@name)
            AND requirement_type_id <> @id";

            MySqlCommand checkCmd =
            new MySqlCommand(checkQuery, conn);

            checkCmd.Parameters.AddWithValue(
            "@name",
            txtRequirementTypeName.Text.Trim());

            checkCmd.Parameters.AddWithValue(
            "@id",
            id);

            int count =
            Convert.ToInt32(
            checkCmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show(
                "This requirement type already exists!");

                conn.Close();
                return;
            }

            string query =
            @"UPDATE RequirementTypes
            SET requirement_type_name = @name
            WHERE requirement_type_id = @id";

            MySqlCommand cmd =
            new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
            "@name",
            txtRequirementTypeName.Text.Trim());

            cmd.Parameters.AddWithValue(
            "@id",
            id);

            cmd.ExecuteNonQuery();

            AddAuditTrail(
            "Edited Requirement Type");

            conn.Close();

            MessageBox.Show(
            "Requirement type updated successfully!");

            txtRequirementTypeName.Clear();

            LoadRequirementTypes();

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

        // =================== SECTION 28.7: ( DELETE REQUIREMENT TYPE ) ======================================================= //
        private void button3_Click(
 object sender,
 EventArgs e)
        {
            if (dgvRequirementTypes.CurrentRow == null)
            {
                MessageBox.Show(
                "Please select a requirement type to delete!");

                return;
            }

            DialogResult confirm =
            MessageBox.Show(
            "Are you sure you want to delete this requirement type?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                int id =
                Convert.ToInt32(
                dgvRequirementTypes.CurrentRow
                .Cells["requirement_type_id"]
                .Value);

                MySqlConnection conn =
                new DatabaseConnection()
                .GetConnection();

                conn.Open();

                try
                {
                    string query =
                    @"DELETE FROM RequirementTypes
            WHERE requirement_type_id = @id";

                    MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                    "@id",
                    id);

                    cmd.ExecuteNonQuery();

                    AddAuditTrail(
                    "Deleted Requirement Type");

                    conn.Close();

                    MessageBox.Show(
                    "Requirement type deleted successfully!");

                    txtRequirementTypeName.Clear();

                    LoadRequirementTypes();

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




        // =================== SECTION 28.8: ( CELL CLICK ) =========================================== //
        private void dgvRequirementTypes_CellClick(
        object sender,
        DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                dgvRequirementTypes.Rows[e.RowIndex];

                txtRequirementTypeName.Text =
                row.Cells["requirement_type_name"]
                .Value.ToString();
            }
        }

        private void txtRequirementTypeName_TextChanged(
        object sender,
        EventArgs e)
        {

        }
    }
}


