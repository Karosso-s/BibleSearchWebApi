using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace verses3._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSearchVerses_Click(object sender, EventArgs e)
        {
            string bibleVersion = selectBibleVersion.Text;
            string searchParams = inputSearchParams.Text;

            SearchVerses searchVerses = new SearchVerses();
            List<VersesDTO> verses = new List<VersesDTO>();

            verses = searchVerses.searchVerses(bibleVersion, searchParams);

            dataGridView1.DataSource = verses;

            if (verses.Count > 10)
            {
                Console.WriteLine("Sua busca obteve " + verses.Count + " resultados\n Aqui está uma lista com os 10 primeiros: ");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Livro: " + verses[i].book);
                    Console.WriteLine("Capítulo: " + verses[i].chapter);
                    Console.WriteLine("Versiculo: " + verses[i].verse);
                    Console.WriteLine("Texto: " + verses[i].text);
                    Console.WriteLine("--------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Sua busca obteve " + verses.Count + " resultado(s): ");
                foreach (var verse in verses)
                {
                    Console.WriteLine("Livro: " + verse.book);
                    Console.WriteLine("Capítulo: " + verse.chapter);
                    Console.WriteLine("Versiculo: " + verse.verse);
                    Console.WriteLine("Texto: " + verse.text);
                    Console.WriteLine("--------------------------------------");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateSQLCommand createSQLCommand = new CreateSQLCommand();

            BibleVersesSearchDTO searchParams = new BibleVersesSearchDTO();
            BibleVersesSearchDTO searchParams_1 = new BibleVersesSearchDTO();
            BibleVersesSearchDTO searchParams_2 = new BibleVersesSearchDTO();
            BibleVersesSearchDTO searchParams_3 = new BibleVersesSearchDTO();
            BibleVersesSearchDTO searchParams_4 = new BibleVersesSearchDTO();

            GetVersesByParams getVersesByParams = new Model.GetVersesByParams();
            List<VersesDTO> versesResultList = new List<VersesDTO>();

            searchParams.version = "bible_aa";
            searchParams.book = "Levítico";
            searchParams.chapter = 2;
            searchParams.verseInitial = 4;
            searchParams.verseFinal = 6;

            searchParams_1.version = "bible_aa";
            searchParams_1.book = "Salmos";
            // searchParams_1.chapter = ;
            // searchParams_1.verseInitial = ;
            // searchParams_1.verseFinal = ;

            searchParams_2.version = "bible_aa";
            searchParams_2.book = "Amós";
            searchParams_2.chapter = 2;
            // searchParams_2.verseInitial = "";
            // searchParams_2.verseFinal = "";

            searchParams_3.version = "bible_aa";
            searchParams_3.book = "2ª Timóteo";
            searchParams_3.chapter = 2;
            searchParams_3.verseInitial = 4;
            searchParams.verseFinal = 2;

            searchParams_4.version = "bible_aa";
            searchParams_4.book = "Miquéias";
            searchParams_4.chapter = 1;
            searchParams_4.verseInitial = 4;
            searchParams_4.verseFinal = 6;

            Console.WriteLine(createSQLCommand.createCommand(searchParams));
            Console.WriteLine("");
            Console.WriteLine(createSQLCommand.createCommand(searchParams_1));
            Console.WriteLine("");
            Console.WriteLine(createSQLCommand.createCommand(searchParams_2));
            Console.WriteLine("");
            Console.WriteLine(createSQLCommand.createCommand(searchParams_3));
            Console.WriteLine("");
            Console.WriteLine(createSQLCommand.createCommand(searchParams_4));

            versesResultList = getVersesByParams.getVersesByParams(searchParams_4);
            foreach (var verse in versesResultList)
            {
                Console.WriteLine("Livro: " + verse.book);
                Console.WriteLine("Capítulo: " + verse.chapter);
                Console.WriteLine("Versiculo: " + verse.verse);
                Console.WriteLine("Texto: " + verse.text);
                Console.WriteLine("--------------------------------------");
            }
        }
    }
}
