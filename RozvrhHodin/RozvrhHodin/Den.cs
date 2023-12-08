using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    public enum Dny
    {
        Pondeli = 1,
        Utery = 2,
        Streda = 3,
        Ctvrtek = 4,
        Patek = 5
    }
    public class Den
    {
        private string nazev;
        private string zkratka;
        private List<Hodina> rozvrhDne;

        public string Nazev { get { return nazev; } set { nazev = value; } }
        public string Zkratka { get {  return zkratka; } set {  zkratka = value; } }
        public List<Hodina> RozvrhDne { get { return rozvrhDne; } private set {  rozvrhDne = value; } }

        public Den() 
        {
            Nazev = "Bez názvu";
            Zkratka = "N/A";
            RozvrhDne = new List<Hodina>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="den">(int) Číslo dne v týdnu (1 = Pondeli -> 5 = Patek)</param>
        public Den(int den)
        {
            RozvrhDne = new List<Hodina>();
            switch(den) 
            {
                case 1:
                    Nazev = "Pondělí";
                    Zkratka = "Po";
                    break;
                case 2:
                    Nazev = "Úterý";
                    Zkratka = "Ut";
                    break;
                case 3:
                    Nazev = "Středa";
                    Zkratka = "St";
                    break;
                case 4:
                    Nazev = "Čtvrtek";
                    Zkratka = "Ct";
                    break;
                case 5:
                    Nazev = "Pátek";
                    Zkratka = "Pa";
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            string output = "| " + Zkratka;
            for(int i = 0; i < rozvrhDne.Count; i++)
            {
                output = output + " | " + RozvrhDne[i].Predmet.Zkratka;
            }
            int zbytek = 10 - rozvrhDne.Count;
            for (int i = 0; i < zbytek; i++)
            {
                output = output + " |    ";
            }
            return output + " |";
        }





    }
}
