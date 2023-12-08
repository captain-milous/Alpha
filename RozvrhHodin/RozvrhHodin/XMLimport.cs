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
        private static string path = "data\\";
        /// <summary>
        /// Importuje seznam předmětů ze zadaného XML souboru.
        /// </summary>
        /// <returns>Seznam předmětů načtený ze souboru.</returns>
        public static List<Predmet> ImportPredmety()
        {
            path = path +"predmety\\import.xml"; 
            XmlSerializer serializer = new XmlSerializer(typeof(List<Predmet>));
            using (StreamReader streamReader = new StreamReader(path))
            {
                return (List<Predmet>)serializer.Deserialize(streamReader);
            }
        }

        /// <summary>
        /// Importuje seznam učitelů ze zadaného XML souboru.
        /// </summary>
        /// <returns>Seznam učitelů načtený ze souboru.</returns>
        public static List<Ucitel> ImportUcitele()
        {
            path = path + "ucitele\\import.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ucitel>));
            using (StreamReader streamReader = new StreamReader(path))
            {
                return (List<Ucitel>)serializer.Deserialize(streamReader);
            }
        }

        /// <summary>
        /// Importuje seznam učeben ze zadaného XML souboru.
        /// </summary>
        /// <returns>Seznam učeben načtený ze souboru.</returns>
        public static List<Ucebna> ImportUcebny()
        {
            path = path + "ucebny\\import.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ucebna>));
            using (StreamReader streamReader = new StreamReader(path))
            {
                return (List<Ucebna>)serializer.Deserialize(streamReader);
            }
        }
    }

}
