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
        public List<Den> VytvorNahodnyRozvrh(List<Predmet> predmety, List<Ucebna> ucebny, List<Ucitel> ucitele)
        {
            lock (lockRozvrh)
            {
                List<Den> output = VytvorPrazdnyTyden();
                List<Hodina> rawRozvrh = new List<Hodina>();
                for (int i = 0; i < predmety.Count; i++)
                {
                    int maxHodin = predmety[i].HodinTydne;
                    for (int j = 0; j < maxHodin; j++)
                    {
                        rawRozvrh.Add(new Hodina(predmety[i]));
                    }
                }
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

                int hodina = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        output[i].AddHodina(rawRozvrh[hodina]);
                        hodina++;
                    }
                }

                return output;
            }
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
            string output = string.Empty;
            for(int i = 0;i<Tyden.Count;i++)
            {
                output += Tyden[i].Nazev + ":\n";
                for(int j = 0; j < Tyden[i].RozvrhDne.Count; j++)
                {
                    int x = j + 1;
                    output += x + ". " + Tyden[i].GetHodina(j).Predmet.ToString() + Tyden[i].GetHodina(j).Ucitel.ToString() +"\n";
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
