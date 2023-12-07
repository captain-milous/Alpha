using System;
using System.Collections.Generic;
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

        public bool Volna { get { return volna; } set {  volna = value; } }
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
                } else
                {
                    predmet = null;
                }
                 
            } 
        }
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
        public Hodina()
        {
            Volna = true;
            Predmet = new Predmet();
            Ucebna = new Ucebna();
            Ucitel = new Ucitel();  
        }

        public Hodina(Predmet predmet, Ucebna ucebna, Ucitel ucitel)
        {
            Volna = false;
            Predmet = predmet;
            Ucebna = ucebna;
            Ucitel = ucitel;
        }
    }
}
