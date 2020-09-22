using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Controller;

namespace Model
{
    public class BibleVerses
    {

        public string getInvertedPositions(string invertedBibleVersion, string searchWord)
        {
            Connection connection = new Connection();
            SqlCommand command = new SqlCommand(); // Instanciar o command fora do metodo pode gerar erro!

            string wordPositions = "";

            command.CommandText = "SELECT word_positions from " + invertedBibleVersion + " WHERE word_index = @word_index";

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
                Console.WriteLine("GetInvertedPositions: " + err.Message);
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

        public Dictionary<string, string[]> searchInvertedPositions(string invertedBibleVersion, List<string> searchParamsText)
        {
            // GetInvertedPositions GetPositions = new GetInvertedPositions();

            Normalizer normalizer = new Normalizer();

            string[] normalizedParamsText = new string[searchParamsText.Count];

            for (int i = 0; i < searchParamsText.Count; i++)
            {
                normalizedParamsText[i] = normalizer.normalizer(searchParamsText[i]);
            }

            Dictionary<string, string[]> invertedSearchResult = new Dictionary<string, string[]>();

            foreach (var word in normalizedParamsText)
            {
                if (word.Length > 2)
                {
                    string[] positions = new string[0];
                    positions = this.getInvertedPositions(invertedBibleVersion, word).Split('-');

                    if (positions[0] != "")
                    {
                        invertedSearchResult.Add(word, positions);
                    }
                }
            }
            return invertedSearchResult;
        }

        public List<VersesDTO> searchVerses(string bibleVersion, string searchParams)
        {
            BibleVersionConverter bibleVersionConverter = new BibleVersionConverter();
            string invertedBible = bibleVersionConverter.getInvertedVersion(bibleVersion);

            // InvertedSearch invertedSearch = new InvertedSearch();
            GetSynonymousAPI getSynonymousAPI = new GetSynonymousAPI();

            Dictionary<string, string[]> wordSearchResult = new Dictionary<string, string[]>();
            List<List<string>> synonymousUnionList = new List<List<string>>();

            // Separar os parametros da busca por palavras
            string[] searchParamsList = searchParams.Split();

            // Para cada palavra da busca será buscado uma lista de sinonimos na API
            // Para cada sinonimo será feita uma busca por posições na lista invertida
            // ao final será feita uma união de todas as buscas
            foreach (var searchParamWord in searchParamsList)
            {
                var taskResult = Task.Run(() => getSynonymousAPI.getSynonymousAPI(searchParamWord));

                List<string> synonymousList = taskResult.Result;

                wordSearchResult = this.searchInvertedPositions(invertedBible, synonymousList);

                ListUnion listUnion = new ListUnion();

                List<string> listUnionTemp = listUnion.listUnion(wordSearchResult);
                synonymousUnionList.Add(listUnionTemp);
            }

            // Será feita a interseção de toda lista de posição de sinonimo de cada palavra buscada
            ListIntersection listIntersectionTemp = new ListIntersection();
            List<string> listIntersection = listIntersectionTemp.listIntersection(synonymousUnionList);

            List<VersesDTO> searchVersesResult = new List<VersesDTO>();
            BibleBookConverter bibleBookConverter = new BibleBookConverter();

            // GetVerseById getVerseById = new GetVerseById();
            // Buscar os versiculos no banco de dados atraves da lista de intesection
            foreach (var item in listIntersection)
            {
                BibleVerseDTO bibleVerse = new BibleVerseDTO();
                bibleVerse = this.getVerseById(bibleVersion, Convert.ToInt32(item));

                VersesDTO verse = new VersesDTO();
                Console.WriteLine("Livro: " + bibleVerse.book);
                verse.book = bibleBookConverter.bookConverter(bibleVerse.book);
                verse.chapter = bibleVerse.chapter;
                verse.verse = bibleVerse.verse;
                verse.text = bibleVerse.text;

                searchVersesResult.Add(verse);
            }

            return searchVersesResult;
        }

        public BibleVerseDTO getVerseById(string bibleVersion, int verseId)
        {
            Connection connection = new Connection();
            SqlCommand command = new SqlCommand();

            BibleVerseDTO verse = new BibleVerseDTO();

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
                Console.WriteLine("getVerseById: " + err.Message);
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

        public List<VersesDTO> getVersesByParams(BibleVersesSearchDTO searchParams)
        {
            Connection connection = new Connection();

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
                Console.WriteLine("getVersesByParams: " + err.Message);
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
