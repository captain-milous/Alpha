using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RozvrhHodin
{
    public class XMLexport
    {
        private static string path = "data\\";
        /// <summary>
        /// Exportuje seznam předmětů do XML souboru.
        /// </summary>
        /// <param name="dataList">Seznam předmětů k exportu.</param>
        /// <param name="fileName">název XML souboru.</param>
        public static void ExportPredmety(List<Predmet> dataList, string fileName)
        {
            if (!fileName.EndsWith(".xml"))
            {
                fileName += ".xml";
            }

            string fullPath = Path.Combine(path, "predmety\\", fileName);
            Console.WriteLine(fullPath);
            int count = 1;
            while (File.Exists(fullPath))
            {
                fileName = $"{Path.GetFileNameWithoutExtension(fileName)} ({count}).xml";
                fullPath = Path.Combine(path, "predmety\\", fileName);
                count++;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Predmet>));
            using (StreamWriter streamWriter = new StreamWriter(fullPath))
            {
                serializer.Serialize(streamWriter, dataList);
            }
        }

        /// <summary>
        /// Exportuje seznam učitelů do XML souboru.
        /// </summary>
        /// <param name="dataList">Seznam učitelů k exportu.</param>
        /// <param name="fileName">Cesta k výslednému XML souboru.</param>
        public static void ExportUcitel(List<Ucitel> dataList, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ucitel>));
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                serializer.Serialize(streamWriter, dataList);
            }
            path = "data\\";
        }

        /// <summary>
        /// Exportuje seznam učeben do XML souboru.
        /// </summary>
        /// <param name="dataList">Seznam učeben k exportu.</param>
        /// <param name="fileName">Cesta k výslednému XML souboru.</param>
        public static void ExportUcebna(List<Ucebna> dataList, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ucebna>));
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                serializer.Serialize(streamWriter, dataList);
            }
            path = "data\\";
        }
    }

}
