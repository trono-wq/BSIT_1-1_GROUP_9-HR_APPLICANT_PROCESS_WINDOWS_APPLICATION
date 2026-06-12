using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP_003_CAPSTONE
{
    public partial class FrmAddHRUsers : Form
    {
        public FrmAddHRUsers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }


        private void FrmAddHRUsers_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add ("HR Manager / Admin");
            comboBox1.Items.Add ("HR Staff");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseConnection db =
                new DatabaseConnection();

                using (MySqlConnection conn =
                db.GetConnection())
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
                            MessageBox.Show(
                            "Invalid role selected.");
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

                    MySqlCommand cmd = new MySqlCommand (query, conn);

                    cmd.Parameters.AddWithValue ("@roleId", roleId);

                    cmd.Parameters.AddWithValue ("@email", textBox1.Text.Trim());

                    cmd.Parameters.AddWithValue( "@password", textBox2.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show ("HR User Added Successfully!");

                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is frmHRManagerAdminDashboard dashboard)
                        {
                            dashboard.RefreshDashboard();
                        }
                    }

                    comboBox1.SelectedIndex = -1;
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show ("Error: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
