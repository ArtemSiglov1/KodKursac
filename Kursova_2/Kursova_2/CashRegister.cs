using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova_2
{
    [Serializable]
    internal class CashRegister
    {
      public  List<Client> Clients { get; set; }
        public CashRegister(List<Client> clients)
        {
            Clients = clients;
        }
        public void Print() {
        foreach(var client in Clients)
            {
                Console.Write($"{client.ToString()}\t");
            }
        }
    }
}
