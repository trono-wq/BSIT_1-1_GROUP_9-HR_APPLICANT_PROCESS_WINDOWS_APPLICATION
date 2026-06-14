using MySql.Data.MySqlClient;

namespace HRApplicantProcessSystem.Database
{
    public class DatabaseConnection
    {
        private string connectionString =
            "server=localhost;database=hr_applicant_process_window_application;uid=root;pwd=GROUPnine1!;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
