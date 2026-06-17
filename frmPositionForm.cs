using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmPositionForm : Form
    {
        // ======================================== SECTION 31.1: ( FORM INITIALIZATION ) =================================== //
        public frmPositionForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(PositionForm_Load);
        }

        // ======================================== SECTION 31.2: ( FORM LOAD ) ============================================ //
        private void PositionForm_Load(object sender, EventArgs e)
        {
            LoadPositions();

            dgvPositions.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

            dgvPositions.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

            dgvPositions.MultiSelect =
            false;
        }

        // =================== SECTION 31.3: ( LOAD POSITIONS FROM DATABASE ) =========================================== //
        private void LoadPositions()
        {
            try
            {
                MySqlConnection conn =
                new DatabaseConnection()
                .GetConnection();

                conn.Open();

                string query =
                @"SELECT
                position_type_id,
                position_type_name
                FROM PositionTypes";

                MySqlDataAdapter adapter =
                new MySqlDataAdapter(query, conn);

                DataTable dt =
                new DataTable();

                adapter.Fill(dt);

                dgvPositions.DataSource =
                dt;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =================== SECTION 31.4: ( CELL CLICK ) =========================================== //
        private void dgvPositions_CellClick(
        object sender,
        DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                dgvPositions.Rows[e.RowIndex];

                txtPositionName.Text =
                row.Cells["position_type_name"]
                .Value.ToString();
            }
        }

        // =================== SECTION 31.5: ( AUDIT TRAIL ) =========================================== //
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
                    "PositionTypes");

                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =================== SECTION 31.6: ( ADD POSITION ) =========================================================== //
        private void btnAdd_Click(
        object sender,
        EventArgs e)
        {
            if (txtPositionName.Text.Trim() == "")
            {
                MessageBox.Show(
                "Please enter a position name!");

                return;
            }

            MySqlConnection conn =
            new DatabaseConnection()
            .GetConnection();

            conn.Open();

            string checkQuery =
            @"SELECT COUNT(*)
            FROM PositionTypes
            WHERE LOWER(position_type_name)
            = LOWER(@name)";

            MySqlCommand checkCmd =
            new MySqlCommand(checkQuery, conn);

            checkCmd.Parameters.AddWithValue(
            "@name",
            txtPositionName.Text.Trim());

            int count =
            Convert.ToInt32(
            checkCmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show(
                "This position already exists!");

                conn.Close();
                return;
            }

            string query =
            @"INSERT INTO PositionTypes
            (position_type_name, o_position_type_added_by)
            VALUES
            (@name, @updatedBy)";

            MySqlCommand cmd =
            new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
            "@name",
            txtPositionName.Text.Trim());

            cmd.Parameters.AddWithValue(
                "@updatedBy", UserSession.UserId);

            cmd.ExecuteNonQuery();

            AddAuditTrail(
            "Added Position");

            conn.Close();

            MessageBox.Show(
            "Position added successfully!");

            txtPositionName.Clear();

            LoadPositions();

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

        // =================== SECTION 31.7: ( EDIT POSITION ) =========================================================== //
        private void btnEdit_Click(
        object sender,
        EventArgs e)
        {
            if (dgvPositions.CurrentRow == null)
            {
                MessageBox.Show(
                "Please select a position to edit!");

                return;
            }

            if (txtPositionName.Text.Trim() == "")
            {
                MessageBox.Show(
                "Please enter a new position name!");

                return;
            }

            int id =
            Convert.ToInt32(
            dgvPositions.CurrentRow
            .Cells["position_type_id"]
            .Value);

            MySqlConnection conn =
            new DatabaseConnection()
            .GetConnection();

            conn.Open();

            string checkQuery =
            @"SELECT COUNT(*)
            FROM PositionTypes
            WHERE LOWER(position_type_name)
            = LOWER(@name)
            AND position_type_id <> @id";

            MySqlCommand checkCmd =
            new MySqlCommand(checkQuery, conn);

            checkCmd.Parameters.AddWithValue(
            "@name",
            txtPositionName.Text.Trim());

            checkCmd.Parameters.AddWithValue(
            "@id",
            id);

            int count =
            Convert.ToInt32(
            checkCmd.ExecuteScalar());

            if (count > 0)
            {
                MessageBox.Show(
                "This position already exists!");

                conn.Close();
                return;
            }

            string query =
            @"UPDATE PositionTypes
            SET position_type_name = @name
            o_position_type_added_by = @updatedBy  
            WHERE position_type_id = @id";

            MySqlCommand cmd =
            new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
            "@name",
            txtPositionName.Text.Trim());

            cmd.Parameters.AddWithValue(
            "@id",
            id);

            cmd.Parameters.AddWithValue(
                "@updatedBy", UserSession.UserId);  

            cmd.ExecuteNonQuery();

            AddAuditTrail(
            "Edited Position");

            conn.Close();

            MessageBox.Show(
            "Position updated successfully!");

            txtPositionName.Clear();

            LoadPositions();
        }

        // =================== SECTION 31.8: ( DELETE POSITION ) ========================================================= //
        private void btnDelete_Click(
object sender,
EventArgs e)
        {
            if (dgvPositions.CurrentRow == null)
            {
                MessageBox.Show(
                "Please select a position to delete!");

                return;
            }

            DialogResult confirm =
            MessageBox.Show(
            "Are you sure you want to delete this position?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                int id =
                Convert.ToInt32(
                dgvPositions.CurrentRow
                .Cells["position_type_id"]
                .Value);

                MySqlConnection conn =
                new DatabaseConnection()
                .GetConnection();

                conn.Open();

                try
                {
                    // ==========================================
                    // CHECK FOR OPEN VACANCIES
                    // ==========================================
                    string checkQuery =
                    @"SELECT COUNT(*)
            FROM JobVacancies
            WHERE position_type_id = @id
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

                    // STOP DELETE IF OPEN EXISTS
                    if (openCount > 0)
                    {
                        MessageBox.Show(
                        "Cannot delete this position because there are active job vacancies using it.");

                        conn.Close();

                        return;
                    }

                    // ==========================================
                    // DELETE CLOSED VACANCIES
                    // ==========================================
                    string deleteVacanciesQuery =
                    @"DELETE FROM JobVacancies
            WHERE position_type_id = @id
            AND vacancy_status = 'Closed'";

                    MySqlCommand deleteVacanciesCmd =
                    new MySqlCommand(
                    deleteVacanciesQuery,
                    conn);

                    deleteVacanciesCmd.Parameters.AddWithValue(
                    "@id",
                    id);

                    deleteVacanciesCmd.ExecuteNonQuery();

                    // ==========================================
                    // DELETE POSITION
                    // ==========================================
                    string deletePositionQuery =
                    @"DELETE FROM PositionTypes
            WHERE position_type_id = @id";

                    MySqlCommand deletePositionCmd =
                    new MySqlCommand(
                    deletePositionQuery,
                    conn);

                    deletePositionCmd.Parameters.AddWithValue(
                    "@id",
                    id);

                    deletePositionCmd.ExecuteNonQuery();

                    AddAuditTrail(
                    "Deleted Position");

                    conn.Close();

                    MessageBox.Show(
                    "Position deleted successfully!");

                    txtPositionName.Clear();

                    LoadPositions();

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




        private void label2_Click(
        object sender,
        EventArgs e)
        {

        }
    }
}


