using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RozvrhHodin
{
    public class XMLimport
    {
        /// <summary>
        /// Importuje seznam předmětů ze zadaného XML souboru.
        /// </summary>
        /// <param name="fileName">Cesta k XML souboru.</param>
        /// <returns>Seznam předmětů načtený ze souboru.</returns>
        public static List<Predmet> ImportPredmet(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Predmet>));
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                return (List<Predmet>)serializer.Deserialize(streamReader);
            }
        }

        /// <summary>
        /// Importuje seznam učitelů ze zadaného XML souboru.
        /// </summary>
        /// <param name="fileName">Cesta k XML souboru.</param>
        /// <returns>Seznam učitelů načtený ze souboru.</returns>
        public static List<Ucitel> ImportUcitel(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ucitel>));
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                return (List<Ucitel>)serializer.Deserialize(streamReader);
            }
        }

        /// <summary>
        /// Importuje seznam učeben ze zadaného XML souboru.
        /// </summary>
        /// <param name="fileName">Cesta k XML souboru.</param>
        /// <returns>Seznam učeben načtený ze souboru.</returns>
        public static List<Ucebna> ImportUcebna(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ucebna>));
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                return (List<Ucebna>)serializer.Deserialize(streamReader);
            }
        }
    }

}
