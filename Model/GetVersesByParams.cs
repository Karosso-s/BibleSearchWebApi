using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;

namespace Model
{
    public class GetVersesByParams
    {
        Connection connection = new Connection();
        

        public List<VersesDTO> getVersesByParams(BibleVersesSearchDTO searchParams)
        {
            List<VersesDTO> versesResultList = new List<VersesDTO>();
            BibleBookConverter bibleBookConverter = new BibleBookConverter();

            CreateSQLCommand createSQLCommand = new CreateSQLCommand();
            string commandText = createSQLCommand.createCommand(searchParams);

            SqlCommand command = new SqlCommand();
            // Comando SQL
            command.CommandText = commandText;

            try
            {
                // Conectar com o bd
                command.Connection = connection.openConnection();

                // Executar comando
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    VersesDTO verse = new VersesDTO();
                    int bookNumber = Convert.ToInt32(reader["book"].ToString());

                    verse.book = bibleBookConverter.bookConverter(bookNumber);
                    verse.chapter = Convert.ToInt32(reader["chapter"].ToString());
                    verse.verse = Convert.ToInt32(reader["verse"].ToString());
                    verse.text = reader["text"].ToString(); 

                    versesResultList.Add(verse);
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
            return versesResultList;
        }
    }
}
