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
    public partial class frmAssessmentTypeForm : Form
    {
        // ======================================== SECTION 30.1: ( FORM INITIALIZATION ) ==================================== //
        public frmAssessmentTypeForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(AssessmentTypeForm_Load);
        }

        // ======================================== SECTION 30.2: ( FORM LOAD ) ============================================== //
        private void AssessmentTypeForm_Load(object sender, EventArgs e)
        {
            LoadAssessmentTypes();
            dgvAssessmentTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =================== SECTION 30.3: ( LOAD ASSESSMENT TYPES FROM DATABASE ) ========================================= //
        private void LoadAssessmentTypes()
        {
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "SELECT assessment_type_id, assessment_type FROM AssessmentTypes";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvAssessmentTypes.DataSource = dt;
            conn.Close();
        }

        // =================== SECTION 30.4: ( ADD ASSESSMENT TYPE ) ========================================================== //
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAssessmentTypeName.Text == "")
            {
                MessageBox.Show("Please enter an assessment type name!");
                return;
            }
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "INSERT INTO AssessmentTypes (assessment_type) VALUES (@name)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtAssessmentTypeName.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Assessment type added successfully!");
            txtAssessmentTypeName.Text = "";
            LoadAssessmentTypes();
        }

        // =================== SECTION 30.5: ( EDIT ASSESSMENT TYPE ) =========================================================== //
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAssessmentTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an assessment type to edit!");
                return;
            }
            if (txtAssessmentTypeName.Text == "")
            {
                MessageBox.Show("Please enter a new assessment type name!");
                return;
            }
            int id = Convert.ToInt32(dgvAssessmentTypes.SelectedRows[0].Cells["assessment_type_id"].Value);
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "UPDATE AssessmentTypes SET assessment_type = @name WHERE assessment_type_id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtAssessmentTypeName.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Assessment type updated successfully!");
            txtAssessmentTypeName.Text = "";
            LoadAssessmentTypes();
        }

        // =================== SECTION 30.6: ( DELETE ASSESSMENT TYPE ) ========================================================== //
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAssessmentTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an assessment type to delete!");
                return;
            }
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this assessment type?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvAssessmentTypes.SelectedRows[0].Cells["assessment_type_id"].Value);
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = "DELETE FROM AssessmentTypes WHERE assessment_type_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Assessment type deleted successfully!");
                LoadAssessmentTypes();
            }
        }
    }
}