using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova_1
{
    internal class Program
    {
        static void Main()
        {
            Pattern pattern=new Pattern();
            while (true)
            {
                Console.WriteLine("1 Добавить клиента\n2 Вывести информацию о клиентах первого окна\n3 Вывести информацию о клиентах второго окна\n4 Вывести информацию о клиентах третьего окна\n5 Вывести информацию о клиентах четвертого окна\n6 Вывести информацию о клиентах пятого окна\n7 Вывести информацию о клиентах шестого окна\n8 Вывести информацию о клиентах седьмого окна\n9 Вывести информацию о клиентах восьмого окна\n10 Вывести информацию о клиентах девятого окна\n11 Очистить информацию о клиентах всех окон\n0 Выход из программы");
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:pattern.AddClient();break;
                    case 2:pattern.Show1Window();break;
                        case 3:pattern.Show2Window();break;
                        case 4:pattern.Show3Window();break;
                        case 5:pattern.Show4Window();break;
                        case 6:pattern.Show5Window();break;
                        case 7:pattern.Show6Window();break;
                        case 8:pattern.Show7Window();break;
                        case 9:pattern.Show8Window();break;
                        case 10:pattern.Show9Window();break;
                    case 11:pattern.CleanClients();break;
                    case 0:return;
                    default:
                        Console.WriteLine("Повторите попытку выбрав пункт из меню");break;
                }
                Console.ReadLine();
            }
        }
    }
}
