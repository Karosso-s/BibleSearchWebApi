using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class GetInvertedPositions
    {
        public string getPositions(string invertedBibleVersion, string searchWord)
        {
            Connection connection = new Connection();
            SqlCommand command = new SqlCommand(); // Instanciar o command fora do metodo pode gerar erro!

            string wordPositions = "";

            // Comando SQL
            command.CommandText = "SELECT word_positions from " + invertedBibleVersion + " WHERE word_index = @word_index";

            // Parametros
            command.Parameters.AddWithValue("@word_index", searchWord);

            try
            {
                // Conectar com o bd
                command.Connection = connection.openConnection();

                // Executar comando
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    wordPositions = reader["word_positions"].ToString();
                }
            }
            catch (SqlException err)
            {
                Console.WriteLine("GetInvertedPositions class: " + err.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.closeConnection();
                }
            }
            return wordPositions;
        }
    }
}
