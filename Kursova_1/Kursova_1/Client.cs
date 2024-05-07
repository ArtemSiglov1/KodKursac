using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova_1
{
    [Serializable]
    internal class Client:Window
    {
        public int ID { get; set; }
        public string FullName {  get; set; }
        public string NumberOfPasport {  get; set; }
       public DateTime DateOfBirth { get; set;}
        public Client() { }
        public Client(int serviceId,string serviceName,int iD, string fullName, string numberOfPasport, DateTime dateOfBirth):base(serviceId,serviceName)
        {
            ID = iD;
            FullName = fullName;
            NumberOfPasport = numberOfPasport;
            DateOfBirth = dateOfBirth;
        }
        public override string ToString()
        {
            return $"{base.ToString()} {ID} {FullName} {NumberOfPasport} {DateOfBirth}";
        }
        public static Client Init(Window window)
        {
            int serviceId = window.ServiceId;
            string serviceName = window.ServiceName;
            Console.WriteLine("Введите идентификатор клиента");
            int iD = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ФИО");
            string fullname = Console.ReadLine();
            Console.WriteLine("Введите номер паспорта");
            string numberOfPasport = Console.ReadLine();
            Console.WriteLine("Введите дату рождения");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            return new Client(serviceId,serviceName,iD,fullname,numberOfPasport,dateOfBirth);
        }
    }
}
