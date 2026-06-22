using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmPositionTypeMaintenance : Form
    {
        // ======================================== SECTION 31.1: ( FORM INITIALIZATION ) =================================== //
        public frmPositionTypeMaintenance()
        {
            InitializeComponent();
            this.Load += new EventHandler(PositionForm_Load);
            this.StartPosition = FormStartPosition.CenterScreen;    
        }

        // ======================================== SECTION 31.2: ( FORM LOAD ) ============================================ //
        private void PositionForm_Load(object sender, EventArgs e)
        {
            LoadPositions();
            dgvPositions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =================== SECTION 31.3: ( LOAD POSITIONS FROM DATABASE ) =========================================== //
        private void LoadPositions()
        {
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "SELECT position_type_id, position_type_name FROM PositionTypes";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt); //acsfault error
            dgvPositions.DataSource = dt;
            conn.Close();
        }

        // =================== SECTION 31.4: ( ADD POSITION ) =========================================================== //
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (txtPositionName.Text == "")
            {
                MessageBox.Show("Please enter a position name!");
                return;
            }
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "INSERT INTO PositionTypes (position_type_name) VALUES (@name)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtPositionName.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Position added successfully!");
            txtPositionName.Text = "";
            LoadPositions();
        }

        // =================== SECTION 31.5: ( EDIT POSITION ) =========================================================== //
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a position to edit!");
                return;
            }

            if (txtPositionName.Text == "")
            {
                MessageBox.Show("Please enter a new position name!");
                return;
            }
            int id = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["position_id"].Value);
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "UPDATE PositionTypes SET position_type_name = @name WHERE position_type_id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtPositionName.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Position updated successfully!");
            txtPositionName.Text = "";
            LoadPositions();
        }

        // =================== SECTION 31.6: ( DELETE POSITION ) ========================================================= //
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvPositions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a position to delete!");
                return;
            }
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this position?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvPositions.SelectedRows[0].Cells["position_id"].Value);
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = "DELETE FROM PositionTypes WHERE position_type_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Position deleted successfully!");
                LoadPositions();
            }
        }

        // =================== SECTION 31.7: ( BACK ) ========================================================= //
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