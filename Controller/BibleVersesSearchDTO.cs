using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class BibleVersesSearchDTO
    {
        public string version { get; set; }
        public string book { get; set; }
        public int chapter { get; set; }
        public int verseInitial { get; set; }
        public int verseFinal { get; set; }
    }
}
