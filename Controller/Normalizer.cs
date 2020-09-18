using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controller
{
    public class Normalizer
    {
        public string normalizer(string verseParam)
        {
            // Normaliza a String, removento acentos, caracteres especiais, pontuação, artigos e preposições

            string verse = verseParam;

            string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý", "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï", "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û" };
            string[] semAcento = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };

            for (int i = 0; i < acentos.Length; i++)
            {
                verse = verse.Replace(acentos[i], semAcento[i]);
            }

            string[] caracteresEspeciais = { "¹", "²", "³", "£", "¢", "¬", "º", "¨", "\"", "'", ".", ",", "-", ":", "(", ")", "ª", "|", "\\\\", "°", "_", "@", "#", "!", "$", "%", "&", "*", ";", "/", "<", ">", "?", "[", "]", "{", "}", "=", "+", "§", "´", "`", "^", "~" };

            for (int i = 0; i < caracteresEspeciais.Length; i++)
            {
                verse = verse.Replace(caracteresEspeciais[i], " ");
            }

            // verse = " " + verse + " ";
            string[] artigos_preposicoes = new string[] { " a ", " ao ", " as ", " e ", " i ", " o ", " u ", " da ", " das ", " de ", " do ", " dos ", " na ", " nas ", " no ", " nos ", " por ", " quot " };
            string[] sem_artigos_preposicoes = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };

            for (int i = 0; i < artigos_preposicoes.Length; i++)
            {
                verse = verse.Replace(artigos_preposicoes[i], sem_artigos_preposicoes[i]);
            }

            verse = verse.Replace("^\\s+", "");
            verse = verse.Replace("\\s+$", "");
            verse = verse.Replace("\\s+", " ");
            verse = verse.Replace("   ", " ");
            verse = verse.Replace("  ", " ");
            verse = Regex.Replace(verse, @"[^\w\.@-]", " ");
            verse = verse.ToLowerInvariant();

            return verse;
        }
    }
}
