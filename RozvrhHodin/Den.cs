using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    /// <summary>
    /// Reprezentuje dny v pracovním týdnu
    /// </summary>
    public enum Dny
    {
        Pondeli = 1,
        Utery = 2,
        Streda = 3,
        Ctvrtek = 4,
        Patek = 5
    }

    /// <summary>
    /// Tato třída reprezentuje jeden den v týdnu s rozvrhem vyučovacích hodin.
    /// </summary>
    public class Den
    {
        private string nazev;
        private string zkratka;
        private List<Hodina> rozvrhDne;

        /// <summary>
        /// Získá nebo nastaví název dne v týdnu.
        /// </summary>
        public string Nazev { get { return nazev; } set { nazev = value; } }

        /// <summary>
        /// Získá nebo nastaví zkratku dne v týdnu.
        /// </summary>
        public string Zkratka { get { return zkratka; } set { zkratka = value; } }

        /// <summary>
        /// Získá seznam vyučovacích hodin v daném dni.
        /// </summary>
        public List<Hodina> RozvrhDne { get { return rozvrhDne; } private set { rozvrhDne = value; } }

        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Den s výchozími hodnotami.
        /// </summary>
        public Den()
        {
            Nazev = "Bez názvu";
            Zkratka = "N/A";
            RozvrhDne = new List<Hodina>();
        }

        /// <summary>
        /// Konstruktor pro vytvoření instance třídy Den na základě čísla dne v týdnu.
        /// </summary>
        /// <param name="den">(int) Číslo dne v týdnu (1 = Pondeli -> 5 = Patek)</param>
        public Den(int den)
        {
            RozvrhDne = new List<Hodina>();
            switch (den)
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
                    Nazev = "Bez názvu";
                    Zkratka = "N/A";
                    break;
            }
        }

        /// <summary>
        /// Převede den na řetězec vhodný pro výpis rozvrhu.
        /// </summary>
        /// <returns>(string) Výpis rozvrhu pro daný den</returns>
        public override string ToString()
        {
            string output = "| " + Zkratka;
            for (int i = 0; i < rozvrhDne.Count; i++)
            {
                output = output + " | " + RozvrhDne[i].ToString();
            }
            int zbytek = 10 - rozvrhDne.Count;
            for (int i = 0; i < zbytek; i++)
            {
                output = output + " |    ";
            }
            return output + " |";
        }

        /// <summary>
        /// Získá vyučovací hodinu v daném dni podle čísla hodiny.
        /// </summary>
        /// <param name="hodina">(int) Číslo hodiny (1-10)</param>
        /// <returns>(Hodina) Vyučovací hodina v daném dni</returns>
        /// <exception cref="Exception">Vyvolá výjimku, pokud číslo hodiny není v rozsahu 1-10</exception>
        /// <summary>
        /// Získá vyučovací hodinu podle jejího pořadí v denním rozvrhu.
        /// </summary>
        /// <param name="hodina">(int) Pořadové číslo hodiny v rozvrhu (1 - 10)</param>
        /// <returns>(Hodina) Vyučovací hodina</returns>
        /// <exception cref="Exception">Výjimka, pokud je pořadí hodiny mimo rozsah 1 - 10</exception>
        public Hodina GetHodina(int hodina)
        {
            if (hodina > 0 && hodina <= 10)
            {
                return RozvrhDne[hodina - 1];
            }
            else
            {
                throw new Exception("Hodina musí být v rozsahu 1 - 10");
            }
        }

        /// <summary>
        /// Nastaví vyučovací hodinu na daném pořadovém čísle v denním rozvrhu.
        /// </summary>
        /// <param name="hodina">(int) Pořadové číslo hodiny v rozvrhu (1 - 10)</param>
        /// <param name="novaHodina">(Hodina) Nová vyučovací hodina</param>
        /// <exception cref="Exception">Výjimka, pokud je pořadí hodiny mimo rozsah 1 - 10</exception>
        public void SetHodina(int hodina, Hodina novaHodina)
        {
            if (hodina > 0 && hodina <= 10)
            {
                RozvrhDne[hodina - 1] = novaHodina;
            }
            else
            {
                throw new Exception("Hodina musí být v rozsahu 1 - 10");
            }
        }

        /// <summary>
        /// Přidá vyučovací hodinu do denního rozvrhu.
        /// </summary>
        /// <param name="hodina">(Hodina) Přidávaná vyučovací hodina</param>
        /// <exception cref="Exception">Výjimka, pokud je denní rozvrh již plný (obsahuje 10 hodin)</exception>
        public void AddHodina(Hodina hodina)
        {
            if (RozvrhDne.Count <= 10)
            {
                RozvrhDne.Add(hodina);
            }
            else
            {
                throw new Exception("Počet hodin denně může být maximálně 10");
            }
        }
    }
}
