using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Connection
    {
        SqlConnection connection = new SqlConnection();

        // Construtor
        public Connection()
        {
            // Chave de conexão para o BD
            connection.ConnectionString = @"Data Source=DESKTOP-OSCAR\SQLEXPRESS;Initial Catalog=bibles_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        // Abrir Conexão com o BD
        public SqlConnection openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        // Fechar Conexão com o BD
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}

