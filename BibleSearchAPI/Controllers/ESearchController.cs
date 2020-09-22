using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;
using System.Windows.Forms;
using Controller;
using Model;
using System.Web.Http.Cors;

namespace BibleSearchAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")] 
    public class ESearchController : ApiController
    {
        public List<VersesDTO> Get(string bibleVersion, string searchParams)
        {
            return new BibleVerses().searchVerses(bibleVersion, searchParams);
        }
    }
}
