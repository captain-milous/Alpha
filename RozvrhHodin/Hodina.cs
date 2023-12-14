using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    /// <summary>
    /// Tato třída reprezentuje jednu vyučovací hodinu.
    /// </summary>
    public class Hodina
    {
        #region Vlastnosti
        private bool volna = true;
        private Predmet predmet;
        private Ucebna ucebna;
        private Ucitel ucitel;

        /// <summary>
        /// Získá nebo nastaví informaci o tom, zda je hodina volná.
        /// </summary>
        public bool Volna { get; set; }

        /// <summary>
        /// Získá nebo nastaví předmět přiřazený k hodině. Pokud je hodina volná, předmět je null.
        /// </summary>
        public Predmet Predmet { get; set; }

        /// <summary>
        /// Získá nebo nastaví učebnu, ve které se hodina koná. Pokud je hodina volná, učebna je null.
        /// </summary>
        public Ucebna Ucebna { get; set; }

        /// <summary>
        /// Získá nebo nastaví učitele, který vyučuje tuto hodinu. Pokud je hodina volná, učitel je null.
        /// </summary>
        public Ucitel Ucitel { get; set; }

        #endregion

        #region Konstruktory

        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Hodina s výchozími hodnotami.
        /// </summary>
        public Hodina()
        {
            Volna = true;
            Predmet = new Predmet();
            Ucebna = new Ucebna();
            Ucitel = new Ucitel();
        }

        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Hodina s konkrétním předmětem.
        /// </summary>
        /// <param name="predmet">(Predmet) Předmět, který je přiřazen k hodině</param>
        public Hodina(Predmet predmet)
        {
            Volna = false;
            Predmet = predmet;
            Ucebna = null;
            Ucitel = null;
        }

        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Hodina s konkrétním předmětem, učebnou a učitelem.
        /// </summary>
        /// <param name="predmet">(Predmet) Předmět, který je přiřazen k hodině</param>
        /// <param name="ucebna">(Ucebna) Učebna, ve které se hodina koná</param>
        /// <param name="ucitel">(Ucitel) Učitel, který vyučuje tuto hodinu</param>
        public Hodina(Predmet predmet, Ucebna ucebna, Ucitel ucitel)
        {
            Volna = false;
            Predmet = predmet;
            Ucebna = ucebna;
            Ucitel = ucitel;
        }

        #endregion

        /// <summary>
        /// Převede hodinu na řetězec vhodný pro výpis v rozvrhu.
        /// </summary>
        /// <returns>(string) Výpis hodiny</returns>
        public override string ToString()
        {
            if (Volna)
            {
                return "   ";
            }
            else
            {
                string zkr = GetZkratkaPredmetu();
                if (zkr.Length < 3)
                {
                    switch (zkr.Length)
                    {
                        case 0:
                            zkr = "   ";
                            break;
                        case 1:
                            zkr = " " + zkr + " ";
                            break;
                        case 2:
                            zkr = " " + zkr;
                            break;
                        default:
                            throw new Exception("Tento případ by neměl nastat");
                    }
                }
                else
                {
                    zkr = new string(zkr.Take(3).ToArray());
                }
                return zkr;
            }
        }

        /// <summary>
        /// Získá název předmětu spojený s touto hodinou.
        /// </summary>
        /// <returns>(string) Název předmětu</returns>
        public string GetNazevPredmetu()
        {
            return Predmet.Nazev;
        }

        /// <summary>
        /// Získá zkratku předmětu spojenou s touto hodinou.
        /// </summary>
        /// <returns>(string) Zkratka předmětu</returns>
        public string GetZkratkaPredmetu()
        {
            if (Predmet == null)
            {
                return string.Empty;
            }
            else
            {
                return Predmet.Zkratka;
            }
        }

        /// <summary>
        /// Získá typ výuky předmětu spojeného s touto hodinou.
        /// </summary>
        /// <returns>(TypVyuky) Typ výuky předmětu</returns>
        public TypVyuky GetTypPredmetu()
        {
            return Predmet.Typ;
        }

        /// <summary>
        /// Získá počet vyučovacích hodin předmětu spojeného s touto hodinou.
        /// </summary>
        /// <returns>(int) Počet vyučovacích hodin předmětu týdně</returns>
        public int GetPocetHodinPredmetu()
        {
            return Predmet.HodinTydne;
        }

        /// <summary>
        /// Získá typ učebny, ve které se hodina koná.
        /// </summary>
        /// <returns>(TypVyuky) Typ učebny</returns>
        public TypVyuky GetTypUcebny()
        {
            return Ucebna.Typ;
        }

        /// <summary>
        /// Získá číslo patra učebny, ve které se hodina koná.
        /// </summary>
        /// <returns>(int) Číslo patra učebny</returns>
        public int GetPatroUcebny()
        {
            return Ucebna.Patro;
        }

        /// <summary>
        /// Získá název učebny, ve které se hodina koná.
        /// </summary>
        /// <returns>(string) Název učebny</returns>
        public string GetNazevUcebny()
        {
            return Ucebna.Nazev;
        }

        /// <summary>
        /// Získá název kmenové třídy učebny, ve které se hodina koná.
        /// </summary>
        /// <returns>(string) Název kmenové třídy učebny</returns>
        public string GetKmenTridaUcebny()
        {
            return Ucebna.KmenovaTrida;
        }

        /// <summary>
        /// Získá seznam předmětů, které jsou vyučovány v učebně, ve které se hodina koná.
        /// </summary>
        /// <returns>(List<Predmet>) Seznam předmětů vyučovaných v učebně</returns>
        public List<Predmet> GetVyucPredmetyUcebny()
        {
            return Ucebna.VyucovanePredmety;
        }

        /// <summary>
        /// Získá jméno učitele, který vyučuje tuto hodinu.
        /// </summary>
        /// <returns>(string) Jméno učitele</returns>
        public string GetJmenoUcitele()
        {
            return Ucitel.CeleJmeno;
        }

        /// <summary>
        /// Získá zkratku učitele, který vyučuje tuto hodinu.
        /// </summary>
        /// <returns>(string) Zkratka učitele</returns>
        public string GetZkratkaUcitele()
        {
            return Ucitel.Zkratka;
        }

        /// <summary>
        /// Získá informaci, zda je učitel třídním učitelem ve třídě, která má tuto hodinu.
        /// </summary>
        /// <returns>(string) Informace o třídním učiteli</returns>
        public string GetTridaUcitele()
        {
            return Ucitel.TridniUcitel;
        }

        /// <summary>
        /// Získá seznam předmětů, které učitel vyučuje.
        /// </summary>
        /// <returns>(List<Predmet>) Seznam předmětů vyučovaných učitelem</returns>
        public List<Predmet> GetVyucPredmetyUcitele()
        {
            return Ucitel.VyucovanePredmety;
        }
    }

}
