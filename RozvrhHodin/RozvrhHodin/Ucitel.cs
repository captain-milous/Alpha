using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    public class Ucitel
    {
        #region Vlastnosti
        private string celeJmeno;
        private string zkratka;
        private string tridniUcitel;
        private List<Predmet> vyucovanePredmety;

        public string CeleJmeno
        {
            get { return celeJmeno; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    celeJmeno = value;
                }
                else
                {
                    throw new Exception("Jméno nesmí být prázdné");
                }
            }
        }
        public string Zkratka
        {
            get { return zkratka; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (value.Length == 2)
                    {
                        zkratka = value;
                    } 
                    else
                    {
                        throw new Exception("Zkratka musí obsahovat 2 znaky");
                    }
                }
                else
                {
                    throw new Exception("Zkratka nesmí být prázdná");
                }
            }
        }
        public string TridniUcitel { get { return tridniUcitel; } set { tridniUcitel = value; } }
        public List<Predmet> VyucovanePredmety { get { return vyucovanePredmety; } set { vyucovanePredmety = value; } }
        #endregion
        #region Konstruktory
        public Ucitel()
        {
            CeleJmeno = "Bez jména";
            Zkratka = "N/A";
            TridniUcitel = string.Empty;
            VyucovanePredmety = new List<Predmet>();
        }

        public Ucitel(string jmeno, string zkr, string tridnictvi)
        {
            CeleJmeno = jmeno;
            Zkratka = zkr;
            TridniUcitel = tridnictvi;
            VyucovanePredmety = new List<Predmet>();
        }

        public Ucitel(string jmeno, string zkr, string tridnictvi, List<Predmet> vyucPred)
        {
            CeleJmeno = jmeno;
            Zkratka = zkr;
            TridniUcitel = tridnictvi;
            VyucovanePredmety = vyucPred;
        }
        #endregion
        #region ToString()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predmet"></param>
        public void PridejVyucPredmet(Predmet predmet)
        {
            if (!VyucovanePredmety.Contains(predmet))
            {
                VyucovanePredmety.Add(predmet);
            }
            else
            {
                throw new Exception($"Učitel již vyučuje předmět {predmet.Nazev}.");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predmet"></param>
        public void OdeberVyucPredmet(Predmet predmet)
        {
            VyucovanePredmety.RemoveAll(p => p == predmet);
        }
        /// <summary>
        /// 
        /// </summary>
        public void OdeberVsechnyVyucPredmety()
        {
            VyucovanePredmety.Clear();
        }
        
    }
}
