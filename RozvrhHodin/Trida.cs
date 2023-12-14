using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    /// <summary>
    /// Reprezentuje učebnu v budově, která je odvozena od třídy Mistnost.
    /// </summary>
    public class Ucebna : Mistnost
    {
        #region Vlastnosti
        protected string kmenovaTrida;
        protected TypVyuky typ;
        protected List<Predmet> vyucovanePredmety;

        /// <summary>
        /// Získá nebo nastaví název kmenové třídy k této učebně.
        /// </summary>
        public string KmenovaTrida { get; set; }

        /// <summary>
        /// Získá nebo nastaví typ výuky v učebně.
        /// </summary>
        public TypVyuky Typ { get; set; }

        /// <summary>
        /// Získá nebo nastaví seznam předmětů vyučovaných v učebně.
        /// </summary>
        public List<Predmet> VyucovanePredmety { get; set; }

        #endregion

        #region Konstruktory

        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Ucebna s výchozími hodnotami.
        /// </summary>
        public Ucebna() : base()
        {
            KmenovaTrida = string.Empty;
            Typ = TypVyuky.Teorie;
            VyucovanePredmety = new List<Predmet>();
        }

        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Ucebna s konkrétními hodnotami.
        /// </summary>
        /// <param name="nazev">(string) Název místnosti</param>
        /// <param name="patro">(int) Číslo patra, na kterém se místnost nachází (musí být v rozmezí 0-4, kde 0 je přízemí)</param>
        /// <param name="kmenTrida">(string) Název kmenové třídy k této učebně</param>
        /// <param name="typ">(Enum TypVyuky) Typ výuky v učebně</param>
        public Ucebna(string nazev, int patro, string kmenTrida, TypVyuky typ) : base(nazev, patro)
        {
            KmenovaTrida = kmenTrida;
            Typ = typ;
            VyucovanePredmety = new List<Predmet>();
        }

        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Ucebna s konkrétními hodnotami a seznamem předmětů.
        /// </summary>
        /// <param name="nazev">(string) Název místnosti</param>
        /// <param name="patro">(int) Číslo patra, na kterém se místnost nachází (musí být v rozmezí 0-4, kde 0 je přízemí)</param>
        /// <param name="kmenTrida">(string) Název kmenové třídy k této učebně</param>
        /// <param name="typ">(Enum TypVyuky) Typ výuky v učebně</param>
        /// <param name="predmety">(List<Predmet>) Seznam předmětů vyučovaných v učebně</param>
        public Ucebna(string nazev, int patro, string kmenTrida, TypVyuky typ, List<Predmet> predmety) : base(nazev, patro)
        {
            KmenovaTrida = kmenTrida;
            Typ = typ;
            VyucovanePredmety = predmety;
        }

        #endregion

        #region ToString()

        /// <summary>
        /// Převede učebnu na řetězec vhodný pro výpis.
        /// </summary>
        /// <returns>(string) Výpis učebny</returns>
        public override string ToString()
        {
            return "Učebna " + Nazev + " je kmenovou ";
        }

        #endregion
    }
}
