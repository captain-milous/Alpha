using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    /// <summary>
    /// 
    /// </summary>
    public class Rozvrh
    {
        private object lockRozvrh = new object();

        private string nazev;
        private string trida;
        private List<Den> tyden;
        private double hodnoceni;

        /// <summary>
        /// 
        /// </summary>
        public string Nazev { get { return nazev; } set { nazev = value; } }
        /// <summary>
        /// 
        /// </summary>
        public string Trida { get { return trida; } set { trida = value; } }
        /// <summary>
        /// 
        /// </summary>
        public List<Den> Tyden { get { return tyden; } private set { tyden = value; } }
        /// <summary>
        /// 
        /// </summary>
        public double Hodnoceni { get { return hodnoceni; } set { hodnoceni = value; } }

        public Rozvrh()
        {
            Nazev = "Prázdný";
            Trida = "C4b";
            Tyden = VytvorPrazdnyTyden();
            Hodnoceni = 100;
        }
        /*
        public Rozvrh(string nazev, string trida)
        {
            Nazev = nazev;
            Trida = trida;
            Tyden = VytvorPrazdnyTyden();
            Hodnoceni = 100;
        }*/

        public Rozvrh(string nazev, string trida)
        {
            Nazev = nazev;
            Trida = trida;
            Hodnoceni = 100;
            Tyden = VytvorNahodnyRozvrh(MetodyXML.ImportPredmety(), MetodyXML.ImportUcebny(), MetodyXML.ImportUcitele());
        }

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

        public List<Den> VytvorNahodnyRozvrh(List<Predmet> predmety, List<Ucebna> ucebny, List<Ucitel> ucitele)
        {
            lock (lockRozvrh)
            {
                List<Den> output = VytvorPrazdnyTyden();
                List<Hodina> rawRozvrh = new List<Hodina>();
                for (int i = 0; i < predmety.Count;i++)
                {
                    int maxHodin = predmety[i].HodinTydne;
                    for (int j = 0; j < maxHodin; j++)
                    {
                        rawRozvrh.Add(new Hodina(predmety[i]));
                    }
                }
                Console.WriteLine(rawRozvrh.Count);
                if(rawRozvrh.Count < 50) 
                { 
                    for(int i = rawRozvrh.Count; i < 50; i++)
                    {
                        rawRozvrh.Add(new Hodina());
                    }
                }
                else
                {
                    throw new Exception("Moc hodin na jeden týden");
                }
                Console.WriteLine(rawRozvrh.Count);

                int hodina = 0;
                for(int i = 0;i < 5; i++)
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
        /// 
        /// </summary>
        /// <param name="points"></param>
        public void Ohodnotit(int points)
        {
            lock (lockRozvrh)
            {
                Hodnoceni += points;
            }
        } 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="den"></param>
        /// <param name="hodina"></param>
        /// <param name="novaHodina"></param>
        public void SetHodina(int den, int hodina, Hodina novaHodina)
        {
            if(!(den > 0 && den < 6))
            {
                throw new Exception("Den musí být v rozmezí 1 - 5");
            }
            lock (lockRozvrh)
            {
                Tyden[den - 1].SetHodina(hodina, novaHodina);             
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="den"></param>
        /// <param name="hodina"></param>
        /// <returns></returns>
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
