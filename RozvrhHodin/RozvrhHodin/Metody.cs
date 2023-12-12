using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    public static class Metody
    {
        /// <summary>
        /// Tato metoda byla vygenerována umělou inteligencí
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string DecimalToHexadecimal(int num)
        {
            string output = Convert.ToString(num, 16).ToUpper();
            while(output.Length <= 6) 
            { 
                output = "0" + output;
            }
            return output;
        }
    }
    
}
