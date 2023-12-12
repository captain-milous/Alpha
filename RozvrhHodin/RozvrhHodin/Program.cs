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
        public static int totalObjectsCreated = 0;
        public static int threadCount = 10;
        public static int timeLimitInSeconds = 120;

        public static object lockObject = new object();
        public static bool stopThreads = false;

        public static List<Predmet> predmety = MetodyXML.ImportPredmety();
        public static List<Ucebna> ucebny = MetodyXML.ImportUcebny();
        public static List<Ucitel> ucitele = MetodyXML.ImportUcitele();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool run = true;
            while (run)
            {

            }

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
