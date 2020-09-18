using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;

namespace Model
{
    public class InvertedSearch
    {
        GetInvertedPositions GetPositions = new GetInvertedPositions();
        public Dictionary<string, string[]> searchInvertedPositions(string invertedBibleVersion, List<string> searchParamsText) // Dictionary<string, string[]>
        {
            // Normalizar a busca do usuario, retirando acentos, caracteres especiais, pontuação e passando tudo pra minusculas
            Normalizer normalizer = new Normalizer();

            string[] normalizedParamsText = new string[searchParamsText.Count];

            for (int i = 0; i < searchParamsText.Count; i++)
            {
                normalizedParamsText[i] = normalizer.normalizer(searchParamsText[i]);
            }

            Dictionary<string, string[]> invertedSearchResult = new Dictionary<string, string[]>();

            // Para cada palavra buscada, um array com todas as ocorrencias será criado
            foreach (var word in normalizedParamsText)
            {
                if (word.Length > 2)
                {
                    // buscar palavra na invertedBible e armazenar num array de possitions
                    string[] positions = new string[0];
                    positions = GetPositions.getPositions(invertedBibleVersion, word).Split('-');

                    if (positions[0] != "")
                    {
                        invertedSearchResult.Add(word, positions);
                    }

                }
            }

            return invertedSearchResult;
        }

    }
}
