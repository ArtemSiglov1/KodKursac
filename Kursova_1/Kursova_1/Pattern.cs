using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kursova_1
{
    internal class Pattern
    {
        List<Window> windows=new List<Window>() 
        { new Window(1,"вклады/Металлические счета"),new Window(2,"кредиты"),
        new Window(3,"банковские/кредитные карты"),new Window(4,"ипотека"),new Window(5, "индивидуальные сейфы"),
        new Window(6, "платежи"),new Window(7, "прием и выдача наличных/пенсия"),
        new Window(8, "денежные переводы"),new Window(9, "валютно-обменные операции")};
        List<List<Client>> clients = new List<List<Client>>() 
        { new List<Client>(), new List<Client>(), new List<Client>(), new List<Client>(), 
       new List<Client>(), new List<Client>(), new List<Client>(), new List<Client>(), new List<Client>(), new List<Client>(), };
        public void AddClient()
        {
            Load();
            foreach (var window in windows)
            {
                Console.WriteLine(window.ToString());
            }
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            { 
                case 1: clients[0].Add(Client.Init(windows[0])); Save(); break;
                case 2: clients[1].Add(Client.Init(windows[1])); Save(); break;
                case 3: clients[2].Add(Client.Init(windows[2])); Save(); break;
                case 4: clients[3].Add(Client.Init(windows[3])); Save(); break;
                case 5: clients[4].Add(Client.Init(windows[4])); Save(); break;
                case 6: clients[5].Add(Client.Init(windows[5])); Save(); break;
                case 7: clients[6].Add(Client.Init(windows[6])); Save(); break;
                case 8: clients[7].Add(Client.Init(windows[7])); Save(); break;
                case 9: clients[8].Add(Client.Init(windows[8])); Save(); break;
            }
           
        }
        public void Sh()
        {
            Load();
            foreach(var item in clients)
            {
                foreach(var elem in item)
                {
                    Console.WriteLine(elem.ToString());
                }
            }
        }
        public void Show1Window()
        {
            Load();
            foreach (var client in clients[0])
            {
                Console.WriteLine(client.ToString());
            }
        }
        public void Show2Window()
        {
            Load();
            foreach (var client in clients[1])
            {
                Console.WriteLine(client.ToString());
            }
        }
        public void Show3Window()
        {
            Load();
            foreach (var client in clients[2])
            {
                Console.WriteLine(client.ToString());
            }
        }
        public void Show4Window()
        {
            Load();
            foreach (var client in clients[3])
            {
                Console.WriteLine(client.ToString());
            }
        }
        public void Show5Window()
        {
            Load();
            foreach (var client in clients[4])
            {
                Console.WriteLine(client.ToString());
            }
        }
        public void Show6Window()
        {
            Load();
            foreach (var client in clients[5])
            {
                Console.WriteLine(client.ToString());
            }
        }
        public void Show7Window()
        {
            Load();
            foreach (var client in clients[6])
            {
                Console.WriteLine(client.ToString());
            }
        }
        public void Show8Window()
        {
            Load();
            foreach (var client in clients[7])
            {
                Console.WriteLine(client.ToString());
            }
        }
        public void Show9Window()
        {
            Load();
            foreach (var client in clients[8])
            {
                Console.WriteLine(client.ToString());
            }
        }
        public void CleanClients()
        {
            Load();
            foreach (var client in clients)
            {
                client.Clear();
            }
            Save();
        }
        string path = @"E:\source\repos\Kursova_1\Kursova_1\bin\Debug\Client.bin";
        public void Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                clients=(List<List<Client>>)formatter.Deserialize(fs);
            }
        }
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                formatter.Serialize(fs, clients);
            }
        }
    }
}
