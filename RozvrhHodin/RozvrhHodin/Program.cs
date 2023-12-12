using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RozvrhHodin
{
    public static class Program
    {
        //static List<Rozvrh> threadSafeList = new List<Rozvrh>();
        static int totalObjectsCreated = 0;
        static int threadCount = 10;
        static int timeLimitInSeconds = 120; // Čas v sekundách, po kterém se mají vypnout všechna vlákna

        static object lockObject = new object();
        static bool stopThreads = false;

        static List<Predmet> predmety = MetodyXML.ImportPredmety();
        static List<Ucebna> ucebny = MetodyXML.ImportUcebny();
        static List<Ucitel> ucitele = MetodyXML.ImportUcitele();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Vytvoření vlákna pro sledování času
            Thread timeThread = new Thread(TimeThread);
            timeThread.Start();

            // Vytvoření a spuštění 10 vláken
            Thread[] threads = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(CreateObjectThread);
                threads[i].Start();
            }

            // Počkej na dokončení všech vláken
            foreach (var thread in threads)
            {
                thread.Join();
            }

            // Zastav vlákno pro sledování času
            stopThreads = true;
            timeThread.Join();

            Console.WriteLine($"Celkový počet vytvořených objektů: {totalObjectsCreated}");



            /*
             * Fungování aplikace
             * 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());*/
        }

        static void CreateObjectThread()
        {
            while (!stopThreads)
            {
                // Vytvoření objektu
                string nazev = "R";
                lock (lockObject)
                {
                    nazev += Metody.DecimalToHexadecimal(totalObjectsCreated);
                }
                Rozvrh rozvrh = new Rozvrh(nazev,"C4b",predmety,ucebny,ucitele);

                // Přidání objektu do thread-safe listu
                lock (lockObject)
                {
                    //threadSafeList.Add(rozvrh);
                    totalObjectsCreated++;
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        static void TimeThread()
        {
            Thread.Sleep(timeLimitInSeconds * 1000);
            stopThreads = true;
        }
    }
}
