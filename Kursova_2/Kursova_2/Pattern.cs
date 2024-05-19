using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Kursova_2
{
    internal class Pattern
    {
        List<CashRegister> cashRegisters = new List<CashRegister>() { new CashRegister(new List<Client>()), new CashRegister(new List<Client>()), new CashRegister(new List<Client>()) };
        List<ATM> ATMs = new List<ATM>() { new ATM(new List<Client>()), new ATM(new List<Client>()), new ATM(new List<Client>()), new ATM(new List<Client>()), new ATM(new List<Client>()), new ATM(new List<Client>()), new ATM(new List<Client>()), new ATM(new List<Client>()) };

        public async Task ClientSystem()
        {
            
            int i = 100;
            Random random = new Random();
            foreach (var item in cashRegisters)
            {

                if (i > item.Clients.Count)
                {
                    i = item.Clients.Count;
                }
            }
            foreach (var item2 in cashRegisters)
            {
                if (i == item2.Clients.Count)
                {
                    await Task.Delay(3000);
                    item2.Clients.Add(new Client(random.Next(1, 10000)));
                    Show();
                }
            }

        }
        public async Task ClientSystem1()
        {
            
            int i = 100;
            Random random = new Random();
            foreach (var item in ATMs)
            {

                if (i > item.Clients.Count)
                {
                    i = item.Clients.Count;
                }
            }
            
            foreach (var item2 in ATMs)
            {
                if (i == item2.Clients.Count)
                {
                    await Task.Delay(3000);
                    item2.Clients.Add(new Client(random.Next(1, 10000)));
                    Show1();
                }
            }
          
        }
        public async Task ClientSystemDel1() { 
            await Task.Delay(24000);
            foreach (var item2 in ATMs)
            {
                if (item2.Clients.Count != 0)
                {
                    item2.Clients.Remove(item2.Clients[0]);
                }
            }
        }
        public async Task ClientSystemDel()
        {
            await Task.Delay(9000);
            foreach (var item2 in cashRegisters)
            {
                if (item2.Clients.Count != 0)
                {
                    item2.Clients.Remove(item2.Clients[0]);
                }
            }
        }
        public void Show()
        {
                Console.Clear();
                for(int i=0;i<cashRegisters.Count;i++)
                {
                    Console.Write($"Cash Register {i}\t");
                    cashRegisters[i].Print();
                    Console.WriteLine("");
                }
        }
        public void Show1()
        {
            Console.Clear();
            for (int i = 0; i < 8; i++)
            {
                    Console.Write($"ATM{i}\t"); 
                    ATMs[i].Print();
                    Console.Write("\n");
            }
        }
        string path = $@"E:\source\repos\Kursova_2\Kursova_2\bin\Debug\CashReg.bin";
        string path1 = $@"E:\source\repos\Kursova_2\Kursova_2\bin\Debug\ATM.bin";
        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                formatter.Serialize(fs, cashRegisters);
            }
            using (FileStream fs = new FileStream(path1, FileMode.Open))
            {
                formatter.Serialize(fs, ATMs);
            }
        }
        public void Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                cashRegisters = (List<CashRegister>)formatter.Deserialize(fs);
            }
            using (FileStream fs = new FileStream(path1, FileMode.Open))
            {
                ATMs = (List<ATM>)formatter.Deserialize(fs);
            }
        }
    }
}