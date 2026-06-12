using MySql.Data.MySqlClient;

namespace HRApplicantProcessSystem.Database
{
    public class DatabaseConnection
    {
        private string connectionString =
            "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=tang1nangf1nalpr0j3ctn1t0####;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
