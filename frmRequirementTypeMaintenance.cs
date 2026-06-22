using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class frmRequirementTypeMaintenance : Form
    {
        // ======================================== SECTION 28.1: ( FORM INITIALIZATION ) =================================== //
        public frmRequirementTypeMaintenance()
        {
            InitializeComponent();
            this.Load += new EventHandler(RequirementTypeForm_Load);
            this.StartPosition = FormStartPosition.CenterScreen;    
        }

        // ======================================== SECTION 28.2: ( FORM LOAD ) ============================================ //
        private void RequirementTypeForm_Load(object sender, EventArgs e)
        {
            LoadRequirementTypes();
            dgvRequirementTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =================== SECTION 28.3: ( LOAD REQUIREMENT TYPES FROM DATABASE ) =========================================== //
        private void LoadRequirementTypes()
        {
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "SELECT requirement_type_id, requirement_type_name FROM RequirementTypes";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvRequirementTypes.DataSource = dt;
            conn.Close();
        }

        // =================== SECTION 28.4: ( ADD REQUIREMENT TYPE ) =========================================================== //
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (txtRequirementTypeName.Text == "")
            {
                MessageBox.Show("Please enter a requirement type name!");
                return;
            }
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "INSERT INTO RequirementTypes (requirement_type_name) VALUES (@name)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtRequirementTypeName.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Requirement type added successfully!");
            txtRequirementTypeName.Text = "";
            LoadRequirementTypes();
        }

        // =================== SECTION 28.5: ( EDIT REQUIREMENT TYPE ) ========================================================== //
        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvRequirementTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a requirement type to edit!");
                return;
            }
            if (txtRequirementTypeName.Text == "")
            {
                MessageBox.Show("Please enter a new requirement type name!");
                return;
            }
            int id = Convert.ToInt32(dgvRequirementTypes.SelectedRows[0].Cells["requirement_type_id"].Value);
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "UPDATE RequirementTypes SET requirement_type_name = @name WHERE requirement_type_id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtRequirementTypeName.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Requirement type updated successfully!");
            txtRequirementTypeName.Text = "";
            LoadRequirementTypes();
        }

        // =================== SECTION 28.6: ( DELETE REQUIREMENT TYPE ) ======================================================= //
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvRequirementTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a requirement type to delete!");
                return;
            }
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this requirement type?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvRequirementTypes.SelectedRows[0].Cells["requirement_type_id"].Value);
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = "DELETE FROM RequirementTypes WHERE requirement_type_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Requirement type deleted successfully!");
                LoadRequirementTypes();
            }
        }

        // =================== SECTION 28.7: ( BACK ) ======================================================= //
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