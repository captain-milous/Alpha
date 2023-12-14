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
    }

}
