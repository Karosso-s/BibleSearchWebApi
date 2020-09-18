using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;

namespace Model
{
    public class GetVerseById
    {
        Connection connection = new Connection();
        BibleVerseDTO verse = new BibleVerseDTO();

        public BibleVerseDTO getVerseById(string bibleVersion, int verseId)
        {
            SqlCommand command = new SqlCommand();
            // Comando SQL
            command.CommandText = "SELECT * from " + bibleVersion + " WHERE id = @id";
            // Parametros
            command.Parameters.AddWithValue("@id", verseId);

            try
            {
                // Conectar com o bd
                command.Connection = connection.openConnection();

                // Executar comando
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    verse.id = Convert.ToInt32(reader["id"].ToString());
                    verse.version = reader["version"].ToString();
                    verse.testament = Convert.ToInt32(reader["testament"].ToString());
                    verse.book = Convert.ToInt32(reader["book"].ToString());
                    verse.chapter = Convert.ToInt32(reader["chapter"].ToString());
                    verse.verse = Convert.ToInt32(reader["verse"].ToString());
                    verse.text = reader["text"].ToString();
                }
            }
            catch (SqlException err)
            {
                Console.WriteLine("GetVerses class: " + err.Message);
            }
            finally
            {
                if (connection != null)
                {
                    connection.closeConnection();
                }
            }
            return verse;
        }
    }
}
