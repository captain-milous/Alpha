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
        public static void ExportPredmet(List<Predmet> dataList, string fileName)
        {
            // Create an instance of XmlSerializer
            XmlSerializer serializer = new XmlSerializer(typeof(List<Predmet>));

            // Create a StreamWriter to write the XML file
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                // Serialize the list to XML and write it to the file
                serializer.Serialize(streamWriter, dataList);
            }

            Console.WriteLine($"Data exported to {fileName}.");
        }
    }
    
}
