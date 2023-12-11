using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    /// <summary>
    /// Tato třída reprezentuje jednu vyučovací hodinu
    /// </summary>
    public class Hodina
    {
        #region Vlastnosti
        private bool volna = true;
        private Predmet predmet;
        private Ucebna ucebna;
        private Ucitel ucitel;

        /// <summary>
        /// 
        /// </summary>
        public bool Volna { get { return volna; } set {  volna = value; } }
        /// <summary>
        /// Reprezentuje předmět, který může být přiřazen do hodiny. 
        /// Pokud je hodina volná, předmět je null. Pokud není volná,lze přiřadit pouze předměty odpovídajícího typu učebny.
        /// </summary>
        public Predmet Predmet 
        { 
            get 
            {
                if (!Volna)
                {
                    return predmet;
                }
                else
                {
                    return null;
                }                
            } 
            set 
            {
                if (!Volna)
                {
                    predmet = value;
                } 
                else
                {
                    predmet = null;
                }
                 
            } 
        }
        /// <summary>
        /// Reprezentuje učebnu ve které se hodina odehrává.
        /// Pokud je hodina volná, učebna je null. Pokud není volná,lze přiřadit pouze učebny odpovídajícího typu vyučovaného předmětu.
        /// </summary>
        public Ucebna Ucebna 
        {
            get
            {
                if (!Volna)
                {
                    return ucebna;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (!Volna)
                {
                    ucebna = value;
                }
                else
                {
                    ucebna = null;
                }

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Ucitel Ucitel {
            get
            {
                if (!Volna)
                {
                    return ucitel;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (!Volna)
                {
                    ucitel = value;
                }
                else
                {
                    ucitel = null;
                }

            }
        }
        #endregion
        #region Konstruktory
        /// <summary>
        /// 
        /// </summary>
        public Hodina()
        {
            Volna = true;
            Predmet = new Predmet();
            Ucebna = new Ucebna();
            Ucitel = new Ucitel();  
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predmet"></param>
        public Hodina(Predmet predmet)
        {
            Volna = false;
            Predmet = predmet;
            Ucebna = null;
            Ucitel = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predmet"></param>
        /// <param name="ucebna"></param>
        /// <param name="ucitel"></param>
        public Hodina(Predmet predmet, Ucebna ucebna, Ucitel ucitel)
        {
            Volna = false;
            Predmet = predmet;
            Ucebna = ucebna;
            Ucitel = ucitel;
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override string ToString()
        {
            if(Volna)
            {
                return "   ";
            }
            else
            {
                string zkr = GetZkratkaPredmetu();
                if(zkr.Length < 3)
                {
                    switch(zkr.Length)
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
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetNazevPredmetu()
        {
            return Predmet.Nazev;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public TypVyuky GetTypPredmetu()
        {
            return Predmet.Typ;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetPocetHodinPredmetu() 
        {
            return Predmet.HodinTydne;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TypVyuky GetTypUcebny()
        {
            return Ucebna.Typ;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetPatroUcebny()
        {
            return Ucebna.Patro;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetNazevUcebny()
        {
            return Ucebna.Nazev;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetKmenTridaUcebny()
        {
            return Ucebna.KmenovaTrida;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Predmet> GetVyucPredmetyUcebny()
        {
            return Ucebna.VyucovanePredmety;
        }

        public string GetJmenoUcitele()
        {
            return Ucitel.CeleJmeno;
        }
        public string GetZkratkaUcitele()
        {
            return Ucitel.Zkratka;
        }
        public string GetTridaUcitele()
        {
            return Ucitel.TridniUcitel;
        }
        public List<Predmet> GetVyucPredmetyUcitele()
        {
            return Ucitel.VyucovanePredmety;
        }

    }
}
