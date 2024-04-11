using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursac
{
    public class Route
    {
        public int Id { get; set; }
        public int Nom { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public DateTime[] Timestart { get; set; }
        public DateTime[] Timeend { get; set; }
        public string GosNom { get; set; }
        public int VoditelId { get; set; }
        public Route() { }
        public Route(int id, int nom, string start, string end, DateTime[] timestart, DateTime[] timeend, string gosNom, int voditelId)
        {
            Id = id;
            Nom = nom;
            Start = start;
            End = end;
            Timestart = timestart;
            Timeend = timeend;
            GosNom = gosNom;
            VoditelId = voditelId;
        }
        public override string ToString()
        {
            return $"Id-{Id}\nNom-{Nom}\nStart-{Start}\nEnd-{End}\nTime Start-{Timestart}\nTime";
        }
      
        public string GosNomer(List<Bus> buses)
        {
            foreach(var elem in buses)
            {
                return elem.GosNom;
            }
            return null;
        }
    }
}
