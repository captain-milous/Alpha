using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    /// <summary>
    /// Reprezentuje učitele v akademickém prostředí.
    /// </summary>
    public class Ucitel
    {
        #region Vlastnosti
        private string celeJmeno;
        private string zkratka;
        private string tridniUcitel;
        private List<Predmet> vyucovanePredmety;

        /// <summary>
        /// Získá nebo nastaví celé jméno učitele. Jméno nesmí být prázdné.
        /// </summary>
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

        /// <summary>
        /// Získá nebo nastaví zkratku učitele. Zkratka musí obsahovat 2 znaky.
        /// </summary>
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

        /// <summary>
        /// Získá nebo nastaví informaci, zda je učitel třídním učitelem.
        /// </summary>
        public string TridniUcitel { get { return tridniUcitel; } set { tridniUcitel = value; } }

        /// <summary>
        /// Získá nebo nastaví seznam předmětů, které učitel vyučuje.
        /// </summary>
        public List<Predmet> VyucovanePredmety { get { return vyucovanePredmety; } set { vyucovanePredmety = value; } }

        #endregion

        #region Konstruktory

        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Ucitel s výchozími hodnotami.
        /// </summary>
        public Ucitel()
        {
            CeleJmeno = "Bez jména";
            Zkratka = "xx";
            TridniUcitel = "None";
            VyucovanePredmety = new List<Predmet>();
        }

        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Ucitel s konkrétními hodnotami.
        /// </summary>
        /// <param name="jmeno">(string) Celé jméno učitele</param>
        /// <param name="zkr">(string) Zkratka učitele</param>
        /// <param name="tridnictvi">(string) Informace, zda je učitel třídním učitelem</param>
        public Ucitel(string jmeno, string zkr, string tridnictvi)
        {
            CeleJmeno = jmeno;
            Zkratka = zkr;
            TridniUcitel = tridnictvi;
            VyucovanePredmety = new List<Predmet>();
        }

        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Ucitel s konkrétními hodnotami a seznamem předmětů.
        /// </summary>
        /// <param name="jmeno">(string) Celé jméno učitele</param>
        /// <param name="zkr">(string) Zkratka učitele</param>
        /// <param name="tridnictvi">(string) Informace, zda je učitel třídním učitelem</param>
        /// <param name="vyucPred">(List<Predmet>) Seznam předmětů vyučovaných učitelem</param>
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
        /// Převede učitele na řetězec vhodný pro výpis.
        /// </summary>
        /// <returns>(string) Výpis učitele</returns>
        public override string ToString()
        {
            if(tridniUcitel == "None")
            {
                return CeleJmeno + " (" +Zkratka + ")";
            }
            else
            {
                return CeleJmeno + " (" + Zkratka + ") je třídním učitelem " + tridniUcitel;
            }
        }

        #endregion

        /// <summary>
        /// Přidá předmět mezi vyučované předměty učitele.
        /// </summary>
        /// <param name="predmet">(Predmet) Předmět, který chce učitel vyučovat</param>
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
        /// Odebere předmět z vyucovaných předmětů učitele.
        /// </summary>
        /// <param name="predmet">(Predmet) Předmět, který chce učitel přestat vyučovat</param>
        public void OdeberVyucPredmet(Predmet predmet)
        {
            VyucovanePredmety.RemoveAll(p => p == predmet);
        }

        /// <summary>
        /// Odebere všechny vyucované předměty učitele.
        /// </summary>
        public void OdeberVsechnyVyucPredmety()
        {
            VyucovanePredmety.Clear();
        }
    }

}
