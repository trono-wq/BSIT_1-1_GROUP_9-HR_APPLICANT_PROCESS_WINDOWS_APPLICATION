using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class FrmAddHRUsers : Form
    {
        // FORMS
        
        public FrmAddHRUsers()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmAddHRUsers_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("HR Manager / Admin");
            comboBox1.Items.Add("HR Staff");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmHRManagerAdminDashboard HRMAD)
                {
                    HRMAD.ClearHRManagerAdminDashboard();
                    form.Show();
                    break;
                }
            }
            this.Close();
        }

        // BUTTONS

        private void btn_AddNewUser_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            try
            {
                DatabaseConnection db = new DatabaseConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    int roleId = 0;

                    switch (comboBox1.Text.Trim())
                    {
                        case "HR Manager / Admin":
                            roleId = 1;
                            break;

                        case "HR Staff":
                            roleId = 2;
                            break;

                        default:
                            MessageBox.Show("Invalid role selected.");
                            return;
                    }

                    string query =
                    @"INSERT INTO Users
                    (
                        role_id,
                        email,
                        password,
                        o_user_created_at
                    )

                    VALUES
                    (
                        @roleId,
                        @email,
                        @password,
                        NOW()
                    )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@roleId", roleId);
                    cmd.Parameters.AddWithValue("@email", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", textBox2.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("HR User Added Successfully!");
                    comboBox1.SelectedIndex = -1;

                    textBox1.Clear();
                    textBox2.Clear();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
