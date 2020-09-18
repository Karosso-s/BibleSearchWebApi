using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class CreateSQLCommand
    {
        public string createCommand(BibleVersesSearchDTO searchParams)
        {
            string sqlCommand = "";

            string sqlCommandSelect = "SELECT * from";
            string sqlCommandWhere = "WHERE";
            string sqlCommandAnd = "AND";

            string sqlBook = "book =";
            string sqlChapter = "chapter =";
            string sqlVerseP = "verse >=";
            string sqlVerseM = "verse <=";

            if (!string.IsNullOrWhiteSpace(searchParams.version) && !string.IsNullOrWhiteSpace(searchParams.book))
            {
                BibleBookConverter bibleBookConverter = new BibleBookConverter();
                // Console.WriteLine(searchParams.book);
                sqlCommand = string.Join(" ", sqlCommandSelect, searchParams.version, sqlCommandWhere, sqlBook, bibleBookConverter.textToNumber(searchParams.book));
                // Console.WriteLine(sqlCommand);

                if (searchParams.chapter > 0)
                {
                    sqlCommand = string.Join(" ", sqlCommand, sqlCommandAnd, sqlChapter, searchParams.chapter.ToString());
                    // Console.WriteLine(sqlCommand);

                    if (searchParams.verseInitial > 0)
                    {
                        string verseFinal = searchParams.verseFinal.ToString();

                        if (searchParams.verseFinal < searchParams.verseInitial)
                        {
                            verseFinal = searchParams.verseInitial.ToString();
                        }

                        sqlCommand = string.Join(" ", sqlCommand, sqlCommandAnd, sqlVerseP, searchParams.verseInitial.ToString(), sqlCommandAnd, sqlVerseM, verseFinal);
                        // Console.WriteLine(sqlCommand);
                    }
                }

                return sqlCommand;
            }
            else
            {
                return "Versão e Livro são obrigatorios";
            }

        }
    }
}
