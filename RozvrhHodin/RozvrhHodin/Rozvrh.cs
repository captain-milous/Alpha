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
        private object lockObject = new object();

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
            Nazev = "Originál";
            Trida = "C4b";
            Tyden = VytvorTydenOriginal();
            Hodnoceni = 100;
        }
        public Rozvrh(string nazev, string trida)
        {
            Nazev = nazev;
            Trida = trida;
            Tyden = VytvorTyden();
            Hodnoceni = 100;
        }

        private List<Den> VytvorTyden()
        {
            List<Den> output = new List<Den>();
            for (int i = 1; i <= 5; i++)
            {
                output.Add(new Den(i));
            }
            return output;
        }
        private List<Den> VytvorTydenOriginal()
        {
            List<Den> output = VytvorTyden();

            return output;
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
            lock (lockObject)
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
            lock (lockObject)
            {
                if (den > 0 && den < 6)
                {
                    Tyden[den - 1].SetHodina(hodina, novaHodina);
                }
                else
                {
                    throw new Exception("Den musí být v rozmezí 1 - 5");
                }
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
            lock (lockObject)
            {
                if(den > 0 && den < 6)
                {
                    return Tyden[den - 1].GetHodina(hodina);
                }
                else
                {
                    throw new Exception("Den musí být v rozmezí 1 - 5");
                }             
            }
        }

    }
}
