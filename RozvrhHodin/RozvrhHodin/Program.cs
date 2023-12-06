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
            List<Predmet> predmety = XMLimport.ImportPredmet("C:\\Users\\milda\\source\\repos\\Alpha\\Alpha\\Data\\Predmet\\import.xml");
            predmety.Add(new Predmet());
            XMLexport.ExportPredmet(predmety, "C:\\Users\\milda\\source\\repos\\Alpha\\Alpha\\Data\\Predmet\\zkouska.xml");

            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
        }
    }
}
