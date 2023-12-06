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
        public static List<Predmet> ImportPredmet(string fileName)
        {
            // Create an instance of XmlSerializer
            XmlSerializer serializer = new XmlSerializer(typeof(List<Predmet>));

            // Create a StreamReader to read the XML file
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                // Deserialize the XML and cast it to a List<Person>
                return (List<Predmet>)serializer.Deserialize(streamReader);
            }
        }
    }
}
