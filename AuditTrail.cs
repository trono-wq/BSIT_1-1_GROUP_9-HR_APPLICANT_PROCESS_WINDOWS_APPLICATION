using HRApplicantProcessSystem.Database;
using MySql.Data.MySqlClient;
using System;

namespace COMP_003_CAPSTONE
{
    public static class AuditTrail
    {
        public static void Log(string action, string details, string formName)
        {
            try
            {
                DatabaseConnection db = new DatabaseConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO audit_trail 
                                    (user_id, full_name, action, details, form_name, timestamp) 
                                    VALUES 
                                    (@userId, @fullName, @action, @details, @formName, @timestamp)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userId", UserSession.UserId);
                    cmd.Parameters.AddWithValue("@fullName", UserSession.Email);
                    cmd.Parameters.AddWithValue("@action", action);
                    cmd.Parameters.AddWithValue("@details", details);
                    cmd.Parameters.AddWithValue("@formName", formName);
                    cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audit log error: " + ex.Message);
            }
        }
    }
}