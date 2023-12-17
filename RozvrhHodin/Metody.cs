using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    /// <summary>
    /// Obsahuje statické metody pro různé operace.
    /// </summary>
    public static class Metody
    {
        /// <summary>
        /// Tato metoda promíchá pořadí prvků v zadaném seznamu náhodným způsobem.
        /// </summary>
        /// <typeparam name="T">Typ prvků v seznamu</typeparam>
        /// <param name="input">Vstupní seznam prvků</param>
        /// <returns>Seznam prvků s náhodným pořadím</returns>
        /// <remarks>
        /// Tato metoda byla vygenerována umělou inteligencí.
        /// </remarks>
        public static List<T> PromichejList<T>(List<T> input)
        {
            List<T> rdmOrderList = new List<T>(input);
            Random rdm = new Random();

            int n = rdmOrderList.Count;
            while (n > 1)
            {
                n--;
                int k = rdm.Next(n + 1);
                T value = rdmOrderList[k];
                rdmOrderList[k] = rdmOrderList[n];
                rdmOrderList[n] = value;
            }

            return rdmOrderList;
        }

        /// <summary>
        /// Převede desítkové číslo na hexadecimální formát a vrátí výsledek jako řetězec.
        /// </summary>
        /// <param name="num">Desítkové číslo k převodu</param>
        /// <returns>Hexadecimální reprezentace výsledku</returns>
        public static string DecimalToHexadecimal(int num)
        {
            string output = Convert.ToString(num, 16).ToUpper();
            while (output.Length <= 6)
            {
                output = "0" + output;
            }
            return output;
        }

        public static Rozvrh OhodnotRozvrh(Rozvrh rozvrh)
        {
            // 1 - Každému políčku v rozvrhu určete bonus/malus za to, když tam hodina je/není.
            // Například pátek 9. hodina je pro někoho +100 bodů, pro někoho -100 bodů.
            // Hodně se to liší, pokud chodíte do zaměstnání, nebo jste student.
            // Také ranní hodiny jsou někdy oblíbené a někdy ne, apod.
            // Nakonec každé políčko bude mít nějaký bonus/penále.
            int points = 0;
            foreach (Den den in rozvrh.Tyden)
            {
                List<Hodina> rozvrhDne = den.RozvrhDne;
                for (int i = 0; i < 10; i++)
                {
                    if (rozvrhDne[i].Volna == true)
                    {
                        switch (i)
                        {
                            case 0:
                                points += 100;
                                break;
                            case 1:
                                points -= 100;
                                break;
                            case 2:
                                points -= 100;
                                break;
                            case 3:
                                points -= 100;
                                break;
                            case 4:
                                // nepřidáváme/neubíráme
                                break;
                            case 5:
                                // nepřidáváme/neubíráme
                                break;
                            case 6:
                                points += 50;
                                break;
                            case 7:
                                points += 75;
                                break;
                            case 8:
                                points += 100;
                                break;
                            case 9:
                                points += 150;
                                break;
                            default:
                                throw new Exception("Tohle by nikdy nemělo nastat");
                                break;
                        }
                    }
                    else
                    {
                        switch (i)
                        {
                            case 0:
                                points += 100;
                                break;
                            case 1:
                                points += 100;
                                break;
                            case 2:
                                points += 100;
                                break;
                            case 3:
                                points += 100;
                                break;
                            case 4:
                                points += 100;
                                break;
                            case 5:
                                points += 100;
                                break;
                            case 6:
                                // nepřidáváme/neubíráme
                                break;
                            case 7:
                                points -= 500;
                                break;
                            case 8:
                                points -= 100;
                                break;
                            case 9:
                                points -= 200;
                                break;
                            default:
                                throw new Exception("Tohle by nikdy nemělo nastat");
                                break;
                        }
                    }
                }
            }
            rozvrh.Ohodnotit(points);
            // 2 - Pokud v je stejný předmět vícekrát v jeden den a není to vícehodinovka, tak to je špatně.
            // Cvičení a teorie ale v jeden den být mohou. Také úplně štastně a rozumné, když cvičení předchází teorii.
            points = 0;

            rozvrh.Ohodnotit(points);
            // 3 - Pokud musím mezi hodinami přecházet do jiného patra je to špatně, pokud do jiné učebny,
            // je to taky špatně ale pokud je to na stejném patře, tak to není tak hrozné.
            points = 0;
            foreach (Den den in rozvrh.Tyden)
            {
                List<Hodina> rozvrhDne = den.RozvrhDne;

            }
            rozvrh.Ohodnotit(points);
            // 4 - Obědy se vydávají mezi 5. a 8. hodinou, takže každý den jedna z hodin číslo 5., 6., 7. nebo 8. musí být volná na oběd.
            points = 0;
            foreach (Den den in rozvrh.Tyden)
            {
                List<Hodina> rozvrhDne = den.RozvrhDne;
                bool obsahujeObed = false;
                for(int i = 4; i < 8; i++) 
                {
                    if (rozvrhDne[i].Volna)
                    {
                        obsahujeObed = true;
                    }
                }
                if(!obsahujeObed)
                {
                    points = -10000;
                }
            }
            rozvrh.Ohodnotit(points);
            // 5 - Denně by se mělo učit ideálně tak 5-6 hodin, víc je špatně, 8 je strop, 9 je problém a 10 snad ani není ani legální.
            points = 0;
            foreach (Den den in rozvrh.Tyden)
            {
                List<Hodina> rozvrhDne = den.RozvrhDne;
                int vyucHodiny = 0;
                for(int i = 0; i < 10; i++)
                {
                    if (!rozvrhDne[i].Volna)
                    {
                        vyucHodiny++;
                    }
                }
                switch(vyucHodiny)
                {
                    case 5:
                        points += 1000;
                        break;
                    case 6:
                        points += 1000;
                        break;
                    case 8:
                        points -= 100;
                        break;
                    case 9:
                        points -= 1000;
                        break;
                    case 10:
                        points -= 10000;
                        break;
                }
            }
            rozvrh.Ohodnotit(points);
            // 6 - Když je cvičení dvouhodinové, tříhodinové tak ty hodiny musí být u sebe v jednom dni.
            points = 0;

            rozvrh.Ohodnotit(points);
            // 7 - Matematika a profilové předměty by se neměli učit ani první hodinu, ani po obědové pauze, za to musí být body dolu.
            points = 0;

            rozvrh.Ohodnotit(points);
            // 8 - pravidlo #1 Bonus za to že vyučuje třídu jejich třídní učitel
            points = 0;

            rozvrh.Ohodnotit(points);
            // 9 - pravidlo #2 Bonus za to že se učí ve své kmenové třídě
            points = 0;

            rozvrh.Ohodnotit(points);
            // 10 - Wellbeing pravilo - Musi reflektovat Váš wellbeing,
            // napr. pokud nemate/mate radi urcite ucebny/ucitele/predmety. Napr. nemam rad ucitele A, B a C, tak rozvrh ktery obsahuje dny,
            // kde uci jen tihle tri dostane penale. Nebo naopak, pokud mam rad ucitele X a rozvrh vysel tak,
            // ze ho potkam kazdy den alespon 1x je to lepsi, nez kdyz ho napr. 3 dny v kuse nepotkam.


            return rozvrh;
        }
    }

}
