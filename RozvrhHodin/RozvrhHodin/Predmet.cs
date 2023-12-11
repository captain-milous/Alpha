using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    public class Predmet
    {
        #region Vlastnosti
        protected string nazev;
        protected string zkratka;
        protected TypVyuky typ;
        protected int hodinTydne;

        public string Nazev 
        { 
            get { return nazev; } 
            set 
            { 
                if ( !string.IsNullOrWhiteSpace(value) )
                {
                    nazev = value;
                }
                else
                {
                    throw new Exception("Název nesmí být prázdný");
                }         
            } 
        }
        public string Zkratka 
        { 
            get { return zkratka; }
            set { zkratka = value; }
        }
        public TypVyuky Typ { get; set; }
        public int HodinTydne 
        { 
            get {  return hodinTydne; } 
            set 
            { 
                if(value >= 0 && value <= 5) 
                {
                    hodinTydne = value;
                }
                else
                {
                    throw new Exception("Počet hodin musí být v rozmezí 0-5");
                }
            } 
        }
        #endregion
        #region Konstruktory
        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Predmet s výchozími hodnotami.
        /// </summary>
        public Predmet()
        {
            Nazev = "Volna";
            Zkratka = " ";
            Typ = TypVyuky.Teorie;
            HodinTydne = 0;
        }
        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Predmet s konkrétními hodnotami.
        /// </summary>
        /// <param name="naz">(string) Název předmětu</param>
        /// <param name="zkr">(string) Zkratka předmětu</param>
        /// <param name="typ">(Enum TypVyuky) Typ výuky předmětu</param>
        /// <param name="hod">(Int) Počet vyučovacích hodin týdně (musí být v rozmezí 0-5h)</param>
        public Predmet(string naz, string zkr, TypVyuky typ, int hod)
        {
            Nazev = naz;
            Zkratka = zkr;
            Typ = typ;
            HodinTydne = hod;
        }
        #endregion
        #region ToString()
        /// <summary>
        /// Převede předmět na řetězec vhodný pro výpis.
        /// </summary>
        /// <returns>(string) Výpis předmětu</returns>
        public override string ToString()
        {
            return Zkratka + " (" + Nazev + ") je " + Typ.ToString() + " a učí se " + HodinTydne + " hodin týdně.";
        }
        #endregion

    }
}
