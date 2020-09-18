using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace Controller
{
    public interface SynonymousTaskAPI
    {
        [Get("/synonyms/{word}")]
        Task<string[]> GetSynonymousAsync(string word);
    }
}
