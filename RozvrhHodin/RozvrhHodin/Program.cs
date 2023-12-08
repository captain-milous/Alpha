using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozvrhHodin
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            /*
            Rozvrh r1 = new Rozvrh();
            Predmet pr1 = new Predmet();
            Predmet pr2 = new Predmet("Test", "T", TypVyuky.Teorie, 0);
            */
            
            Console.WriteLine();


            List<Ucitel> ucitele = new List<Ucitel>();

            ucitele.Add(new Ucitel());
            ucitele.Add(new Ucitel());


            // List<Predmet> predmety = XMLimport.ImportPredmet("C:\\Users\\milda\\source\\repos\\Alpha\\Alpha\\Data\\Predmet\\import.xml");
            // List<Ucebna> ucebny = XMLimport.ImportUcebna("C:\\Users\\milda\\source\\repos\\Alpha\\Alpha\\Data\\Ucebna\\import.xml");
            // List<Ucitel> ucitele = XMLimport.ImportUcitel("C:\\Users\\milda\\source\\repos\\Alpha\\Alpha\\Data\\Ucitel\\import.xml");

            XMLexport.ExportUcitel(ucitele, "C:\\Users\\milda\\source\\repos\\Alpha\\Alpha\\Data\\Ucitel\\import.xml");

            /*
             * Fungování aplikace
             * 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
        }
    }
}
