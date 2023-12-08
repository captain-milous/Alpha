using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    public class Mistnost
    {
        #region Vlastnosti
        protected string nazev;
        protected int patro;

        public string Nazev
        {
            get { return nazev; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    nazev = value;
                }
                else
                {
                    throw new Exception("Název nesmí být prázdný");
                }
            }
        }
        public int Patro
        {
            get { return patro; }
            set
            {
                if (value >= 0 && value < 5)
                {
                    patro = value;
                }
                else
                {
                    throw new Exception("Počet hodin musí být v rozmezí 0-4");
                }
            }
        }
        #endregion
        #region Konstruktory
        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Mistnost s výchozími hodnotami.
        /// </summary>
        public Mistnost()
        {
            Nazev = "Bez názvu";
            Patro = 0;
        }
        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Mistnost s konkrétními hodnotami.
        /// </summary>
        /// <param name="nazev">(string) Název místnosti</param>
        /// <param name="patro">(int) Číslo patra, na kterém se místnost nachází (musí být v rozmezí 0-4, kde 0 je přízemí)</param>
        public Mistnost(string nazev, int patro)
        {
            Nazev = nazev;
            Patro = patro;
        }
        #endregion
        #region ToString()
        /// <summary>
        /// Převede místnost na řetězec vhodný pro výpis.
        /// </summary>
        /// <returns>(string) Výpis místnosti</returns>
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}
