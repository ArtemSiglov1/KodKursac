using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova_2
{
    [Serializable]
    internal class Client
    {
        public int Id { get; set; }
        public Client() { }
        public Client(int id)
        {
            Id = id;
        }
        public override string ToString()
        {
            return $"{Id}";
        }
    }
    
}
