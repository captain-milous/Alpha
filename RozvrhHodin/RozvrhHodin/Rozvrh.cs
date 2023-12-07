using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    public class Rozvrh
    {
        
        private string nazev;
        private string trida;
        private List<Den> tyden;
        private double hodnoceni;

        public string Nazev { get { return nazev; } set { nazev = value; } }
        public string Trida { get { return trida; } set { trida = value; } }
        public List<Den> Tyden { get { return tyden; } private set { tyden = value; } }
        public double Hodnoceni { get {  return hodnoceni; } set {  hodnoceni = value; } }

        public Rozvrh()
        {
            Nazev = "Bez názvu";
            Trida = string.Empty;
            Tyden = VytvorTyden();
            Hodnoceni = 100;
        }
        public Rozvrh(string nazev, string trida)
        {
            Nazev = nazev;
            Trida = trida;
            Tyden = VytvorTyden();
            Hodnoceni = 100;
        }

        private List<Den> VytvorTyden()
        {
            List<Den> output = new List<Den>();
            for(int i = 1; i <= 5; i++)
            {
                output.Add(new Den(i));
            }
            return output;
        }

        public override string ToString()
        {
            string output = "| Rozvrh " + Nazev + " pro třídu " + Trida + ":\n";
            string line = "+----+-----+-----+-----+-----+-----+-----+-----+-----+-----+-----+\n";
            output = line + output + line + ;
            for (int i = 0;i < Tyden.Count; i++)
            {
                output = output + Tyden[i].ToString() + "\n" + line;
            }
            return output + "| Hodnocení: " + Hodnoceni +" bodů\n"+line;
        }

    }
}
