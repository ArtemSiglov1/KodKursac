using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kursac
{
        [Serializable]
        public class Route
        {
            public int Id { get; set; }
            public int Nom { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
            public DateTime TimeStart { get; set; }
            public DateTime Timeend { get; set; }
            public string GosNom { get; set; }
            public int VoditelId { get; set; }
            public Route() { }
            public Route(int id, int nom, string start, string end, DateTime timestart, DateTime timeend, string gosNom, int voditelId)
            {
                Id = id;
                Nom = nom;
                Start = start;
                End = end;
                TimeStart = timestart;
                Timeend = timeend;
                GosNom = gosNom;
                VoditelId = voditelId;
            }
            public override string ToString()
            {
                return $"Id-{Id}\nNom-{Nom}\nStart-{Start}\nEnd-{End}\nTime Start-{TimeStart}\nTimeEnd-{Timeend}\nGosnom-{GosNom}\nVoditel Id-{VoditelId}";
            }
        }
}

