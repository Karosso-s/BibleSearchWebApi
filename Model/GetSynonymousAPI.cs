using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Controller;

namespace Model
{
    public class GetSynonymousAPI
    {
        public async Task<List<string>> getSynonymousAPI(string word)
        {
            List<string> synounymousList = new List<string>();

            if (word != "")
            {
                synounymousList.Add(word); // Adicionado uma palavra da busca na lista de sinonimos

                try
                {
                    if (word != "jesus" && word != "Jesus") // palavra jesus tem um retorno inesperado pela API
                    {
                        var synonymousSearch = RestService.For<SynonymousTaskAPI>("https://significado.herokuapp.com");
                        string[] synonymousResult = await synonymousSearch.GetSynonymousAsync(word);

                        foreach (var synonyms in synonymousResult)
                        {
                            synounymousList.Add(synonyms); // Adicionado cada sininomo da palavra na lista de sinonimos
                        }
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("GetSynonymousAPI class: " + err.Message);
                }
            }
            else
            {
                Console.WriteLine("Digite uma palavra");
            }
            return synounymousList;
        }
    }
}
