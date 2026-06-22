using MySql.Data.MySqlClient;

namespace HRApplicantProcessSystem.Database
{
    public class DatabaseConnection
    {
        private string connectionString =
            "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=3STARGENERAL;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}