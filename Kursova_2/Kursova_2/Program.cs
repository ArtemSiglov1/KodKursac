using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace Kursova_2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Pattern pattern = new Pattern();


            while (true)
            {

                pattern.Load();
                Console.WriteLine($"1-CashReg work\n2-ATM work\n0-Exit");
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        for (int i = 0; i < 10; i++) { await Task.WhenAll(pattern.ClientSystem(), pattern.ClientSystemDel()); }
                        break;
                    case 2:
                        for (int i = 0; i < 10; i++)
                        {
                            await Task.WhenAll(pattern.ClientSystem1(),  pattern.ClientSystemDel1());
                        }
                        break;
                    case 0:return;
                    default: Console.WriteLine("Again");break;
                }
            }
           // Console.ReadLine();
        }
    }
}
