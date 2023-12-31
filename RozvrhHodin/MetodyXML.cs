﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RozvrhHodin
{
    /// <summary>
    /// Obsahuje statické metody pro import a export dat ze/z XML souborů.
    /// </summary>
    public static class MetodyXML
    {
        private static string path = "data\\";

        /// <summary>
        /// Importuje seznam předmětů ze zadaného XML souboru.
        /// </summary>
        /// <returns>Seznam předmětů načtený ze souboru.</returns>
        public static List<Predmet> ImportPredmety()
        {
            string fullPath = Path.Combine(path, "predmety\\import.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Predmet>));
            using (StreamReader streamReader = new StreamReader(fullPath))
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
            string fullPath = Path.Combine(path, "ucitele\\import.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ucitel>));
            using (StreamReader streamReader = new StreamReader(fullPath))
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
            string fullPath = Path.Combine(path, "ucebny\\import.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ucebna>));
            using (StreamReader streamReader = new StreamReader(fullPath))
            {
                return (List<Ucebna>)serializer.Deserialize(streamReader);
            }
        }

        public static Rozvrh ImportRozvrh(string fileName)
        {
            if (!fileName.EndsWith(".xml"))
            {
                fileName += ".xml";
            }

            string fullPath = Path.Combine(path, "rozvrhy\\" + fileName);
            XmlSerializer serializer = new XmlSerializer(typeof(Rozvrh));
            using (StreamReader streamReader = new StreamReader(fullPath))
            {
                Rozvrh output = (Rozvrh)serializer.Deserialize(streamReader);
                // Z nějakého důvodu se zde tvoří dva rozvrhy v jednom, tak ten jeden mažu
                if (output.Tyden.Count > 5)
                {
                    int k = (output.Tyden.Count - 5);
                    for (int i = 0; i < k; i++)
                    {
                        output.Tyden.RemoveAt(0);
                    }
                }
                return output;
            }
        }

        /// <summary>
        /// Exportuje seznam předmětů do XML souboru.
        /// </summary>
        /// <param name="dataList">Seznam předmětů k exportu.</param>
        /// <param name="fileName">Název XML souboru.</param>
        public static void ExportPredmety(List<Predmet> dataList, string fileName)
        {
            if (!fileName.EndsWith(".xml"))
            {
                fileName += ".xml";
            }

            string fullPath = Path.Combine(path, "predmety\\", fileName);
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
        /// <param name="fileName">Název XML souboru.</param>
        public static void ExportUcitel(List<Ucitel> dataList, string fileName)
        {
            if (!fileName.EndsWith(".xml"))
            {
                fileName += ".xml";
            }

            string fullPath = Path.Combine(path, "ucitele\\", fileName);
            int count = 1;
            while (File.Exists(fullPath))
            {
                fileName = $"{Path.GetFileNameWithoutExtension(fileName)} ({count}).xml";
                fullPath = Path.Combine(path, "ucitele\\", fileName);
                count++;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ucitel>));
            using (StreamWriter streamWriter = new StreamWriter(fullPath))
            {
                serializer.Serialize(streamWriter, dataList);
            }
        }

        /// <summary>
        /// Exportuje seznam učeben do XML souboru.
        /// </summary>
        /// <param name="dataList">Seznam učeben k exportu.</param>
        /// <param name="fileName">Název XML souboru.</param>
        public static void ExportUcebna(List<Ucebna> dataList, string fileName)
        {
            if (!fileName.EndsWith(".xml"))
            {
                fileName += ".xml";
            }

            string fullPath = Path.Combine(path, "ucebny\\", fileName);
            int count = 1;
            while (File.Exists(fullPath))
            {
                fileName = $"{Path.GetFileNameWithoutExtension(fileName)} ({count}).xml";
                fullPath = Path.Combine(path, "ucebny\\", fileName);
                count++;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Ucebna>));
            using (StreamWriter streamWriter = new StreamWriter(fullPath))
            {
                serializer.Serialize(streamWriter, dataList);
            }
        }

        /// <summary>
        /// Exportuje rozvrh do XML souboru.
        /// </summary>
        /// <param name="dataList">Rozvrh k exportu.</param>
        /// <param name="fileName">Název XML souboru.</param>
        public static void ExportRozvrh(Rozvrh rozvrh, string fileName)
        {
            if (!fileName.EndsWith(".xml"))
            {
                fileName += ".xml";
            }

            string fullPath = Path.Combine(path, "rozvrhy\\", fileName);
            int count = 1;
            while (File.Exists(fullPath))
            {
                fileName = $"{Path.GetFileNameWithoutExtension(fileName)} ({count}).xml";
                fullPath = Path.Combine(path, "rozvrhy\\", fileName);
                count++;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(Rozvrh));
            using (StreamWriter streamWriter = new StreamWriter(fullPath))
            {
                serializer.Serialize(streamWriter, rozvrh);
            }
        }
    }

}
