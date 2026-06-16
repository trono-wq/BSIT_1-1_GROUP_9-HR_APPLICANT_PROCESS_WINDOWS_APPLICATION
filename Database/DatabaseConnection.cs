using MySql.Data.MySqlClient;

namespace HRApplicantProcessSystem.Database
{
    public class DatabaseConnection
    {
        private string connectionString =
            "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=09303281417Ms;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
