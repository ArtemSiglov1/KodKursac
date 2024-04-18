using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kursac
{
    [Serializable]
    public class Bus
    {
        public int Id { get; set; }
        public string GosNom { get; set; }
        public string Tip { get; set; }
        public int Volume { get; set; }
        public bool Ispraven { get; set; }
        public Bus() { }
        public Bus(int id, string gosNom, string tip, int volume, bool ispraven)
        {
            Id = id;
            GosNom = gosNom;
            Tip = tip;
            Volume = volume;
            Ispraven = ispraven;
        }
        public override string ToString()
        {
            return $"Id: {Id}, GosNom: {GosNom}, Tip: {Tip}, Volume: {Volume}, Ispraven: {Ispraven}";
        }
    }
}
