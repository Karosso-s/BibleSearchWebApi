using System.Data.SqlClient;

namespace Model
{
    public class Connection
    {
        SqlConnection connection = new SqlConnection();
        public Connection()
        {
            // Chave de conexão para o BD
            connection.ConnectionString = @"Data Source=DESKTOP-OSCAR\SQLEXPRESS;Initial Catalog=bibles_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public SqlConnection openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}

