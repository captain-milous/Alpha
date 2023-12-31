﻿namespace RozvrhHodin
{
    /// <summary>
    /// Obsahuje třídy a metody pro generování a ohodnocování rozvrhů.
    /// </summary>
    public static class Program
    {
        static List<Rozvrh> vygenerRozvrhy = new List<Rozvrh>();
        static List<Rozvrh> ohodnocRozvrhy = new List<Rozvrh>();

        static int pocetGenRozvrhu = 0;
        static int pocetHodRozvrhu = 0;
        static int pocetLepsichRoz = 0;
        static int threadCount = 20;
        static int casovyLimit = 120;

        static object lockObject = new object();
        static bool stopAllThreads = false;

        static string trida = "C4b";
        public static List<Predmet> predmety = new List<Predmet>();
        public static List<Ucebna> ucebny = new List<Ucebna>();
        public static List<Ucitel> ucitele = new List<Ucitel>();
        public static Rozvrh originalC4b = new Rozvrh();

        /// <summary>
        /// Hlavní metoda programu, která řídí generování a ohodnocování rozvrhů.
        /// </summary>
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
                originalC4b = Metody.OhodnotRozvrh(MetodyXML.ImportRozvrh("import.xml"));

                ohodnocRozvrhy.Add(originalC4b);
                Console.WriteLine(originalC4b);
                Console.Write("Zmáčkněte Enter pro spuštění.");
                Console.ReadLine();
                Console.WriteLine(oddelovac);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nepovedlo se načíst vstupní data..\n");
                Console.WriteLine(ex.ToString() + "\n\n");
                run = false;
            }
       
            int input = 0;
            while (run)
            {
                run = false;
                runThreads = true;
                Console.WriteLine("Vyberte prosím pro kterou třídu budete rozvrh vytvářet.\n1 - C4a\n2 - C4b\n3 - C4c");
                Console.Write("Vyberte možnost: ");
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
                        Console.WriteLine("\nVybrali jste C4b");
                        trida = "C4b";
                        break;
                    case 3:
                        Console.WriteLine("\nVybrali jste C4c");
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
                if (input >= 10 && input <= 600)
                {
                    casovyLimit = input;
                    Console.WriteLine($"\nČasový limit byl nastaven na {casovyLimit}s");
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


                Thread[] mainThreads = new Thread[threadCount*2];
                for (int i = 0; i < threadCount; i++)
                {
                    mainThreads[i] = new Thread(Generator);
                    mainThreads[i].Start();
                }
                for (int i = threadCount; i < threadCount*2; i++)
                {
                    mainThreads[i] = new Thread(Hodnotitel);
                    mainThreads[i].Start();
                }
                foreach (var thread in mainThreads)
                {
                    thread.Join();
                } 

                stopAllThreads = true;
                watchdog.Join();


                Console.WriteLine($"Celkový počet vygenerovaných rozvrhů: {pocetGenRozvrhu}");
                Console.WriteLine($"Celkový počet ohodnocených rozvrhů: {pocetHodRozvrhu}");
                Console.WriteLine($"Celkový počet lepších rozvrhů než originál: {pocetLepsichRoz}");


                Console.WriteLine($"\nTop {ohodnocRozvrhy.Count} nejlepších rozvrhů:");
                foreach(Rozvrh r in ohodnocRozvrhy)
                {
                    Console.WriteLine(r.ToString());
                }

                Console.WriteLine("Chcete podrobný výpis rozvrhů?\n1 - Ano\n2 - Ne");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Zadaná Hodnota musí být integer!");
                    input = 0;
                }
                if (input == 1)
                {
                    foreach (Rozvrh r in ohodnocRozvrhy)
                    {
                        Console.WriteLine(oddelovac);
                        Console.WriteLine(r.PodrobnyVypis());
                    }
                }

            }
            else
            {
                Console.WriteLine("Program nebyl spuštěn.");
            }
            Console.WriteLine("\n\nKonec programu");
            Console.WriteLine(oddelovac);
            Console.ReadLine();
        }

        /// <summary>
        /// Generuje rozvrh a přidá ho do seznamu vygenerovaných rozvrhů.
        /// </summary>
        static void Generator()
        {
            while (!stopAllThreads)
            {
                string nazev = "R" + Metody.DecimalToHexadecimal(pocetGenRozvrhu);
                bool rozvrhOK = true;
                Rozvrh rozvrh = new Rozvrh();
                try
                {
                    rozvrh = new Rozvrh(nazev, trida, predmety, ucebny, ucitele);
                } 
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                    rozvrhOK = false;
                }
                if (rozvrhOK) 
                {
                    
                    lock (lockObject)
                    {
                        vygenerRozvrhy.Add(rozvrh);
                        pocetGenRozvrhu++;
                    }
                }
            }
        }

        /// <summary>
        /// Hodnotí vygenerované rozvrhy a přidá je do seznamu ohodnocených rozvrhů.
        /// </summary>
        static void Hodnotitel()
        {
            while (!stopAllThreads)
            {
                Rozvrh hodnocenyRozvrh = new Rozvrh();
                
                lock (lockObject)
                {
                    if (vygenerRozvrhy.Count > 0)
                    {
                        hodnocenyRozvrh = vygenerRozvrhy[0];
                        vygenerRozvrhy.RemoveAt(0);
                        hodnocenyRozvrh = Metody.OhodnotRozvrh(hodnocenyRozvrh);
                        pocetHodRozvrhu++;
                    }
                }
                if (hodnocenyRozvrh.Hodnoceni > 0)
                {
                    lock (lockObject)
                    {
                        ohodnocRozvrhy = Metody.NajdiNejlepsiRozvrhy(ohodnocRozvrhy, hodnocenyRozvrh);
                    }
                    if (hodnocenyRozvrh.Hodnoceni > originalC4b.Hodnoceni)
                    {
                        lock(lockObject)
                        {
                            pocetLepsichRoz++;
                        }
                    }
                    
                }
                GC.SuppressFinalize(hodnocenyRozvrh);
            }
        }

        /// <summary>
        /// Watchdog metoda pro sledování časového limitu programu.
        /// </summary>
        static void Watchdog()
        {
            Thread.Sleep(casovyLimit * 1000);
            stopAllThreads = true;
        }
    }
}