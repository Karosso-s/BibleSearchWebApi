using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;

namespace Model
{
    public class SearchVerses
    {
        public List<VersesDTO> searchVerses(string bibleVersion, string searchParams)
        {
            BibleVersionConverter bibleVersionConverter = new BibleVersionConverter();
            string invertedBible = bibleVersionConverter.getInvertedVersion(bibleVersion);

            InvertedSearch invertedSearch = new InvertedSearch();
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

                wordSearchResult = invertedSearch.searchInvertedPositions(invertedBible, synonymousList);

                ListUnion listUnion = new ListUnion();

                List<string> listUnionTemp = listUnion.listUnion(wordSearchResult);
                synonymousUnionList.Add(listUnionTemp);
            }

            // Será feita a interseção de toda lista de posição de sinonimo de cada palavra buscada
            ListIntersection listIntersectionTemp = new ListIntersection();
            List<string> listIntersection = listIntersectionTemp.listIntersection(synonymousUnionList);
            
            List<VersesDTO> searchVersesResult = new List<VersesDTO>();
            BibleBookConverter bibleBookConverter = new BibleBookConverter();

            GetVerseById getVerseById = new GetVerseById();
            // Buscar os versiculos no banco de dados atraves da lista de intesection
            foreach (var item in listIntersection)
            {
                BibleVerseDTO bibleVerse = new BibleVerseDTO();
                bibleVerse = getVerseById.getVerseById(bibleVersion, Convert.ToInt32(item));

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
    }
}
