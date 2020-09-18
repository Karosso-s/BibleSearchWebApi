using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class BibleVersionConverter
    {
        public string getInvertedVersion(string bibleVersion)
        {
            switch (bibleVersion)
            {
                case "bible_acf":
                    return "bible_acf_inverted";
                case "bible_aa":
                    return "bible_aa_inverted";
                case "bible_nvi":
                    return "bible_nvi_inverted";
                default:
                    return "Versão da biblia não econtrada!";
            }
        }

        public string getVersion(string invertedBibleVersion)
        {
            switch (invertedBibleVersion)
            {
                case "bible_acf_inverted":
                    return "bible_acf";
                case "bible_aa_inverted":
                    return "bible_aa";
                case "bible_nvi_inverted":
                    return "bible_nvi";
                default:
                    return "Versão da biblia não econtrada!";
            }
        }
    }
}
