using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class BibleVerseDTO
    {
        public int id { get; set; }
        public string version { get; set; }
        public int testament { get; set; }
        public int book { get; set; }
        public int chapter { get; set; }
        public int verse { get; set; }
        public string text { get; set; }
    }
}
