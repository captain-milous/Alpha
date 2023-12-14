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
        static List<Rozvrh> vygenerRozvrhy = new List<Rozvrh>();
        //static List<Rozvrh> ohodnocRozvrhy = new List<Rozvrh>();

        static int pocetGenRozvrhu = 0;
        static int pocetHodRozvrhu = 0;
        static int threadCount = 10;
        static int casovyLimit = 120;

        static object lockObject = new object();
        static bool stopAllThreads = false;

        static string trida = "C4b";
        public static List<Predmet> predmety = new List<Predmet>();
        public static List<Ucebna> ucebny = new List<Ucebna>();
        public static List<Ucitel> ucitele = new List<Ucitel>();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool run = true;
            bool runThreads = false;
            string oddelovac = "\n----------------------------------------------------------------------------------\n";
            Console.WriteLine(oddelovac);
            Console.WriteLine("Vítejte v programu Alpha! (Generátor rozvrhů)");
            Console.WriteLine("Autor: Miloš Tesař C4b");
            Console.WriteLine(oddelovac);
            try
            {
                predmety = MetodyXML.ImportPredmety();
                ucebny = MetodyXML.ImportUcebny();
                ucitele = MetodyXML.ImportUcitele();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nepovedlo se načíst soubory.");
                run = false;
            }

            int input = 0;
            while (run)
            {
                run = false;
                runThreads = true;
                Console.WriteLine("\nVyberte prosím pro kterou třídu budete rozvrh vytvářet.\n1 - C4a\n2 - C4b\n3 - C4c");
                Console.Write("Vyberte možnost: ");
                Console.ReadLine();
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Zadaná Hodnota musí být integer!");
                    input = 0;
                }
                switch (input)
                {
                    case 1:
                        Console.WriteLine("\nVybrali jste C4a");
                        trida = "C4a";
                        break;
                    case 2:
                        Console.WriteLine("\nVybrali jste C4a");
                        trida = "C4b";
                        break;
                    case 3:
                        Console.WriteLine("\nVybrali jste C4a");
                        trida = "C4c";
                        break;
                    default:
                        Console.WriteLine("\nZadejte prosím hodnotu z výběru.");
                        run = true;
                        break;
                }
                Console.WriteLine(oddelovac);
                Console.Write("Zadejte čas (v sekundách) jak dlouho má program běžet: ");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Zadaná Hodnota musí být integer!");
                    input = 0;
                }
                if(input >= 10 && input <= 600)
                {
                    casovyLimit = input;
                    Console.WriteLine($"Časový limit byl nastaven na {casovyLimit}s");                    
                }
                else
                {
                    Console.WriteLine("\nČas musí být v intervalu 10s - 600s");
                    run = true;
                }
                Console.WriteLine(oddelovac);
            }

            if (runThreads)
            {
                Thread watchdog = new Thread(Watchdog);
                watchdog.Start();

                Thread[] generatoryRozvrhu = new Thread[threadCount];
                for (int i = 0; i < threadCount; i++)
                {
                    generatoryRozvrhu[i] = new Thread(Generator);
                    generatoryRozvrhu[i].Start();
                }
                foreach (var generator in generatoryRozvrhu)
                {
                    generator.Join();
                }

                Thread[] hodnotitelRozvrhu = new Thread[threadCount];
                for (int i = 0; i < threadCount; i++)
                {
                    hodnotitelRozvrhu[i] = new Thread(Hodnotitel);
                    hodnotitelRozvrhu[i].Start();
                }
                foreach (var hodnotitel in hodnotitelRozvrhu)
                {
                    hodnotitel.Join();
                }

                stopAllThreads = true;
                watchdog.Join();


                Console.WriteLine($"Celkový počet vygenerovaných rozvrhů: {pocetGenRozvrhu}");
                Console.WriteLine($"Celkový počet ohodnocených rozvrhů: {pocetHodRozvrhu}");
            }
            else
            {
                Console.WriteLine("Program nebyl spuštěn.");
            }

            Console.WriteLine("\n\nKonec programu");
            Console.WriteLine(oddelovac);
        }
        /// <summary>
        /// 
        /// </summary>
        static void Generator()
        {
            while (!stopAllThreads)
            {
                string nazev = "R";
                lock (lockObject)
                {
                    nazev += Metody.DecimalToHexadecimal(pocetGenRozvrhu);
                }
                Rozvrh rozvrh = new Rozvrh(nazev,trida,predmety,ucebny,ucitele);

                lock (lockObject)
                {
                    vygenerRozvrhy.Add(rozvrh);
                    pocetGenRozvrhu++;
                }

            }
        }

        static void Hodnotitel()
        {
            while (!stopAllThreads)
            {
                Rozvrh hodnocenyRozvrh;
                lock (lockObject)
                {
                    if(vygenerRozvrhy.Count > 0)
                    {
                        hodnocenyRozvrh = vygenerRozvrhy[0];
                        vygenerRozvrhy.RemoveAt(0);
                    }
                }
                lock(lockObject)
                {
                    pocetHodRozvrhu++;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static void Watchdog()
        {
            Thread.Sleep(casovyLimit * 1000);
            stopAllThreads = true;
        }
    }
}
