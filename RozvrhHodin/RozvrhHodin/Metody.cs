using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    public static class MojeMetody
    {
        /// <summary>
        /// Vygenerovano
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<T> PromichejList<T>(List<T> input)
        {
            List<T> randomOrderList = new List<T>(input);
            Random random = new Random();

            int n = randomOrderList.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = randomOrderList[k];
                randomOrderList[k] = randomOrderList[n];
                randomOrderList[n] = value;
            }

            return randomOrderList;
        }
    }
    
}
