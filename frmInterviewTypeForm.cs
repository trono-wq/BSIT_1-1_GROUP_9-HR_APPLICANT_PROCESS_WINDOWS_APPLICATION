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
    public partial class frmInterviewTypeForm : Form
    {
        // ======================================== SECTION 29.1: ( FORM INITIALIZATION ) ===================================== //
        public frmInterviewTypeForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(InterviewTypeForm_Load);
        }

        // ======================================== SECTION 29.2: ( FORM LOAD ) =============================================== //
        private void InterviewTypeForm_Load(object sender, EventArgs e)
        {
            LoadInterviewTypes();
            dgvInterviewTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // =================== SECTION 29.3: ( LOAD INTERVIEW TYPES FROM DATABASE ) =========================================== //
        private void LoadInterviewTypes()
        {
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "SELECT interview_type_id, interview_type_name FROM InterviewTypes";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvInterviewTypes.DataSource = dt;
            conn.Close();
        }

        // =================== SECTION 29.4: ( ADD INTERVIEW TYPE ) =========================================================== //
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtInterviewTypeName.Text == "")
            {
                MessageBox.Show("Please enter an interview type name!");
                return;
            }
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "INSERT INTO InterviewTypes (interview_type_name) VALUES (@name)";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtInterviewTypeName.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Interview type added successfully!");
            txtInterviewTypeName.Text = "";
            LoadInterviewTypes();
        }

        // =================== SECTION 29.5: ( EDIT INTERVIEW TYPE ) ========================================================== //
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvInterviewTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an interview type to edit!");
                return;
            }
            if (txtInterviewTypeName.Text == "")
            {
                MessageBox.Show("Please enter a new interview type name!");
                return;
            }
            int id = Convert.ToInt32(dgvInterviewTypes.SelectedRows[0].Cells["interview_type_id"].Value);
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            conn.Open();
            string query = "UPDATE InterviewTypes SET interview_type_name = @name WHERE interview_type_id = @id";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", txtInterviewTypeName.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Interview type updated successfully!");
            txtInterviewTypeName.Text = "";
            LoadInterviewTypes();
        }

        // =================== SECTION 29.6: ( DELETE INTERVIEW TYPE ) ======================================================== //
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInterviewTypes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an interview type to delete!");
                return;
            }
            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this interview type?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvInterviewTypes.SelectedRows[0].Cells["interview_type_id"].Value);
                MySqlConnection conn = new DatabaseConnection().GetConnection();
                conn.Open();
                string query = "DELETE FROM InterviewTypes WHERE interview_type_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Interview type deleted successfully!");
                LoadInterviewTypes();
            }
        }
    }
}