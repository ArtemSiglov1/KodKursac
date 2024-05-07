using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova_1
{
    [Serializable]
    internal class Window
    {
        public int ServiceId { get; set; }
       public string ServiceName { get; set; }
        public Window() { }
        public Window( int serviceId, string serviceName)
        {
            ServiceId = serviceId;
            ServiceName = serviceName;
        }
        public override string ToString()
        {
            return $"{ServiceId} {ServiceName} ";
        }
       
        ///TO DO:метод для вывода свободного времени определенной даты 
        ///TODO:

    }
}
