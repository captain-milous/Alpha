using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    /// <summary>
    /// Tato třída reprezentuje rozvrh pro konkrétní třídu na jednu školní třídu.
    /// </summary>
    public class Rozvrh
    {
        private object lockRozvrh = new object();

        private string nazev;
        private string trida;
        private List<Den> tyden;
        private double hodnoceni;

        /// <summary>
        /// Získá nebo nastaví název rozvrhu.
        /// </summary>
        public string Nazev { get { return nazev; } set { nazev = value; } }

        /// <summary>
        /// Získá nebo nastaví název třídy, pro kterou je rozvrh vytvořen.
        /// </summary>
        public string Trida { get { return trida; } set { trida = value; } }

        /// <summary>
        /// Získá seznam dnů v týdnu s jejich rozvrhem.
        /// </summary>
        public List<Den> Tyden { get { return tyden; } private set { tyden = value; } }

        /// <summary>
        /// Získá nebo nastaví hodnocení rozvrhu.
        /// </summary>
        public double Hodnoceni { get { return hodnoceni; } set { hodnoceni = value; } }

        /// <summary>
        /// Konstruktor pro vytvoření prázdného rozvrhu s výchozími hodnotami.
        /// </summary>
        public Rozvrh()
        {
            Nazev = "Prázdný";
            Trida = "C4b";
            Tyden = VytvorPrazdnyTyden();
            Hodnoceni = 100;
        }

        /// <summary>
        /// Konstruktor pro vytvoření rozvrhu s konkrétním obsahem na základě zadaných dat.
        /// </summary>
        /// <param name="nazev">Název rozvrhu</param>
        /// <param name="trida">Název třídy</param>
        /// <param name="predmety">Seznam předmětů</param>
        /// <param name="ucebny">Seznam učeben</param>
        /// <param name="ucitele">Seznam učitelů</param>
        public Rozvrh(string nazev, string trida, List<Predmet> predmety, List<Ucebna> ucebny, List<Ucitel> ucitele)
        {
            Nazev = nazev;
            Trida = trida;
            Hodnoceni = 100;
            Tyden = VytvorNahodnyRozvrh(predmety, ucebny, ucitele);
        }

        /// <summary>
        /// Vytvoří prázdný týden s nastavením jednotlivých dnů.
        /// </summary>
        /// <returns>Seznam dnů s prázdným rozvrhem</returns>
        private List<Den> VytvorPrazdnyTyden()
        {
            lock (this)
            {
                List<Den> output = new List<Den>();
                for (int i = 1; i <= 5; i++)
                {
                    output.Add(new Den(i));
                }
                return output;
            }
        }

        /// <summary>
        /// Vytvoří náhodný rozvrh na základě zadaných předmětů, učeben a učitelů.
        /// </summary>
        /// <param name="predmety">Seznam předmětů</param>
        /// <param name="ucebny">Seznam učeben</param>
        /// <param name="ucitele">Seznam učitelů</param>
        /// <returns>Seznam dnů s náhodným rozvrhem</returns>
        /// <exception cref="Exception">Vyvolá výjimku, pokud je počet hodin v rozvrhu větší než 50</exception>
        /// <remarks>
        /// Nejduležitější metoda pro můj generátor rozvrhů.
        /// </remarks>
        public List<Den> VytvorNahodnyRozvrh(List<Predmet> predmety, List<Ucebna> ucebny, List<Ucitel> ucitele)
        {
            Random rnd = new Random();

            // stage 1 - RND přiřazení učitele k předmětu (tak aby nebyli jiní učitelé na jeden předmět)
            List<Hodina> hodinySUcitelem = new List<Hodina>();
            foreach (Predmet predmet in predmety)
            {
                Hodina hodSUc = new Hodina(predmet);
                List<Ucitel> ucitelSPredmetem = new List<Ucitel>();
                for (int i = 0; i < ucitele.Count; i++)
                {
                    foreach (Predmet vp in ucitele[i].VyucovanePredmety)
                    {
                        if(vp.Nazev == predmet.Nazev)
                        {
                            ucitelSPredmetem.Add(ucitele[i]);
                        }
                    }
                }
                if(ucitelSPredmetem.Count > 1)
                {
                    hodSUc.Ucitel = ucitelSPredmetem[(rnd.Next(1, ucitelSPredmetem.Count)) - 1];
                } 
                else if(ucitelSPredmetem.Count == 1)
                {
                    hodSUc.Ucitel = ucitelSPredmetem[0];
                } 
                else
                {
                    throw new Exception("V listů s učiteli chybí učitel co by učil tento předmět");
                }                
                hodinySUcitelem.Add(hodSUc);
            }

            // stage 2 - RND Přiřazení učeben
            foreach(Hodina hodSUc in hodinySUcitelem)
            {
                    List<Ucebna> ucebnyPredmetu = new List<Ucebna>();
                    for (int i = 0; i < ucebny.Count; i++)
                    {
                        foreach(Predmet vp in ucebny[i].VyucovanePredmety)
                        {
                            if(vp.Nazev == hodSUc.Predmet.Nazev)
                            {
                                ucebnyPredmetu.Add(ucebny[i]);
                            }
                        }
                    }
                    if (ucebnyPredmetu.Count > 1)
                    {
                        hodSUc.Ucebna = ucebnyPredmetu[(rnd.Next(1, ucebnyPredmetu.Count)) - 1];
                    }
                    else if (ucebnyPredmetu.Count == 1)
                    {
                        hodSUc.Ucebna = ucebnyPredmetu[0];
                    }
                    else
                    {
                        throw new Exception("V listu učeben není žádná, která by dovolila učit tento předmět."); 
                    }
            }

            // stage 3 - Vytvoření surového rozvrhu, s tolika Hodinami, kolik daný předmět potřebuje
            List<Hodina> rawRozvrh = new List<Hodina>();
            foreach(Hodina hodSUc in hodinySUcitelem)
            {
                int maxHodin = hodSUc.Predmet.HodinTydne;
                for (int i = 0; i < maxHodin; i++)
                {
                    rawRozvrh.Add(hodSUc);
                }
            }

            // stage 4 - Přidání volných hodin a RND promíchání 
            if (rawRozvrh.Count < 50)
            {
                for (int i = rawRozvrh.Count; i < 50; i++)
                {
                    rawRozvrh.Add(new Hodina());
                }
            }
            else
            {
                throw new Exception("Moc hodin na jeden týden");
            }
            rawRozvrh = Metody.PromichejList(rawRozvrh);

            // stage 5 - Vytvoření strukturovaného rozvrhu
            List<Den> output = VytvorPrazdnyTyden();
            int hodina = 0;
            foreach (Den den in output)
            {
                for (int i = 0; i < 10; i++)
                {
                    den.AddHodina(rawRozvrh[hodina]);
                    hodina++;
                }
            }
            return output;
        }

        /// <summary>
        /// Převede rozvrh na řetězec vhodný pro výpis.
        /// </summary>
        /// <returns>(string) Textový výpis rozvrhu</returns>
        public override string ToString()
        {
            string output = "    Rozvrh " + Nazev + " pro třídu " + Trida + ":\n";
            string line = "+----+-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+\n";
            output = output + line + "|    |  1h |  2h |  3h |  4h |  5h |  6h |  7h |  8h |  9h | 10h |\n" + line;
            for (int i = 0; i < Tyden.Count; i++)
            {
                output = output + Tyden[i].ToString() + "\n" + line;
            }
            return output + "    Hodnocení: " + Hodnoceni + " bodů\n";
        }

        /// <summary>
        /// Dodělat!!!!!
        /// </summary>
        /// <returns></returns>
        public string PodrobnyVypis()
        {
            string output = "Rozvrh " + Nazev + " pro třídu " + Trida + ":\nHodnocení: " + Hodnoceni + " bodů\n\n";
            foreach (Den den in Tyden)
            {
                output += den.Nazev + ":\n";
                int n = 1;
                foreach(Hodina hodina in den.RozvrhDne)
                {
                    output += n + ". hodina:\n";
                    if(hodina.Predmet.Nazev != "Volna")
                    {
                        output += hodina.Predmet.ToString() + "\n" + hodina.Ucitel.ToString() + "\n" + hodina.Ucebna.ToString() + "\n\n";
                    }
                    else
                    {
                        output += "Volná hodina\n\n";
                    }
                    n++;
                }
            }
            return output;
        }

        /// <summary>
        /// Ohodnotí rozvrh přidáním bodů k hodnocení.
        /// </summary>
        /// <param name="points">Počet bodů k přidání</param>
        public void Ohodnotit(int points)
        {
            lock (lockRozvrh)
            {
                Hodnoceni += points;
            }
        }

        /// <summary>
        /// Nastaví vyučovací hodinu v daném dni a hodině.
        /// </summary>
        /// <param name="den">Číslo dne (1-5)</param>
        /// <param name="hodina">Číslo hodiny (1-10)</param>
        /// <param name="novaHodina">Nová vyučovací hodina</param>
        public void SetHodina(int den, int hodina, Hodina novaHodina)
        {
            if (!(den > 0 && den < 6))
            {
                throw new Exception("Den musí být v rozmezí 1 - 5");
            }
            lock (lockRozvrh)
            {
                Tyden[den - 1].SetHodina(hodina, novaHodina);
            }
        }

        /// <summary>
        /// Získá vyučovací hodinu v daném dni a hodině.
        /// </summary>
        /// <param name="den">Číslo dne (1-5)</param>
        /// <param name="hodina">Číslo hodiny (1-10)</param>
        /// <returns>Vyučovací hodina v daném dni a hodině</returns>
        public Hodina GetHodina(int den, int hodina)
        {
            if (den > 0 && den < 6)
            {
                throw new Exception("Den musí být v rozmezí 1 - 5");
            }
            lock (lockRozvrh)
            {
                return Tyden[den - 1].GetHodina(hodina);
            }
        }
    }

}
