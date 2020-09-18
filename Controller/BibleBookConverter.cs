using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class BibleBookConverter
    {
        string[] books = {
                                    "Gênesis", "Êxodo", "Levítico", "Números", "Deuteronômio", "Josué", "Juízes", "Rute", "1º Samuel", "2º Samuel", "1º Reis", "2º Reis",
                                    "1º Crônicas", "2º Crônicas", "Esdras", "Neemias", "Ester", "Jó", "Salmos", "Provérbios", "Eclesiastes", "Cânticos", "Isaías", "Jeremias",
                                    "Lamentações de Jeremias", "Ezequiel", "Daniel", "Oséias", "Joel", "Amós", "Obadias", "Jonas", "Miquéias", "Naum", "Habacuque", "Sofonias",
                                    "Ageu", "Zacarias", "Malaquias", "Mateus", "Marcos", "Lucas", "João", "Atos", "Romanos", "1ª Coríntios", "2ª Coríntios", "Gálatas",
                                    "Efésios", "Filipenses", "Colossenses", "1ª Tessalonicenses", "2ª Tessalonicenses", "1ª Timóteo", "2ª Timóteo", "Tito", "Filemom", "Hebreus",
                                    "Tiago", "1ª Pedro", "2ª Pedro", "1ª João", "2ª João", "3ª João", "Judas", "Apocalipse"
                                };
        public string bookConverter(int bookNumber)
        {
            if (bookNumber > 65)
            {
                return "Livro Invalido";
            }
            else
            {
                string bookText = books[bookNumber];
                return bookText;
            }
            
        }

        public string textToNumber(string bookText)
        {
            int indexOf = Array.IndexOf(books, bookText);

            if (indexOf >= 0)
            {
                return indexOf.ToString();
            }
            else
            {
                return "Livro Invalido";
            }
        }
    }
}
