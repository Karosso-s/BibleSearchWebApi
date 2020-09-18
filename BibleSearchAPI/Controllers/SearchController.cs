using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Controller;
using Model;

namespace BibleSearchAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class SearchController : ApiController
    {
        // GET: api/Search
        public List<VersesDTO> Get(string version, string book, int chapter = 0, int verseInitial = 0, int verseFinal = 0)
        {
            BibleVersesSearchDTO searchParams = new BibleVersesSearchDTO();

            searchParams.version = version;
            searchParams.book = book;
            searchParams.chapter = chapter;
            searchParams.verseInitial = verseInitial;
            searchParams.verseFinal = verseFinal;

            return new GetVersesByParams().getVersesByParams(searchParams);
        }


    }
}
