using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozvrhHodin
{
    public class Rozvrh
    {
        private string trida;
        private List<Den> tyden;
        private double hodnoceni;

        public string Trida { get; set; }
        public List<Den> Tyden { get; set;}
        public double Hodnoceni { get {  return hodnoceni; } set {  hodnoceni = value; } }

    }
}
