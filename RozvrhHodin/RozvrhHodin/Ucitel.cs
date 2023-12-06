using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    public class Ucitel
    {
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

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
