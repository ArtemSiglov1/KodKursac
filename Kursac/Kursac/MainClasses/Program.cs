using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kursac
{
    public class Program
    {
        static void Main(string[] args)
        {

            Pattern pattern = new Pattern();
            
            while (true)
            {
                Console.WriteLine("Главное меню:");
                Console.WriteLine("1. Добавить элемент");
                Console.WriteLine("2. Вывод информации");
                Console.WriteLine("3. Удалить элемент");
                Console.WriteLine("0. Выход из программы");
                
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            bool flag = true;
                            while (flag)
                            {
                                Console.WriteLine("Меню добавления элементов:");
                                Console.WriteLine("1. Добавить водителя");
                                Console.WriteLine("2. Добавить автобус");
                                Console.WriteLine("3. Добавить маршрут");
                                Console.WriteLine("0. Выход в главное меню");
                                int choice1 = int.Parse(Console.ReadLine());
                                switch (choice1)
                                {
                                    case 1: Console.Clear(); pattern.InitVoditel(); break;
                                    case 2: Console.Clear(); pattern.InitBus(); break;
                                    case 3: Console.Clear(); pattern.InitRoute(); break;
                                    case 0: Console.Clear(); flag =false; break;
                                    default:
                                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 3.");
                                        break;
                                }
                            }
                        }break;
                    case 2:
                        {
                            //6Console.Clear();
                            bool flag = true;
                            while (flag)
                            {
                                Console.WriteLine("Меню вывода информации:");
                                Console.WriteLine("1. Вывести список водителей на маршруте с графиком работы");
                                Console.WriteLine("2. Вывести список автобусов, обслуживающих данный маршрут");
                                Console.WriteLine("3. Вывести протяженность маршрутов и их минимальную и максимальную протяженность");
                                Console.WriteLine("4. Вывести маршрут водителя с максимальным стажем");
                                Console.WriteLine("5. Вывести общую протяженность маршрутов");
                                Console.WriteLine("6. Вывести список водителей, не вышедших на линию из-за неисправности автобуса");
                                Console.WriteLine("7. Вывести список водителей");
                                Console.WriteLine("8. Вывести список автобусов");
                                Console.WriteLine("9. Вывести список маршрутов");
                                Console.WriteLine("0. Выход в главное меню");
                                int choice2 = int.Parse(Console.ReadLine());
                                switch (choice2)
                                {

                                    case 1: Console.Clear(); pattern.GetRouteVoditel(); break;
                                    case 2: Console.Clear(); pattern.GetRouteBus(); break;
                                    case 3: Console.Clear(); pattern.CalculateRouteLength(); break;
                                    case 4: Console.Clear(); Console.WriteLine(pattern.GetRouteMaxExp());Console.ReadLine(); break;
                                    case 5: Console.Clear(); Console.WriteLine($"Общая протяженность маршрутов: {pattern.AllRouteLenght()} минут"); break;
                                    case 6: Console.Clear(); pattern.VoditelNoJobBusFailure(); break;
                                    case 7: Console.Clear(); pattern.OutPutVoditeli();break;
                                    case 8: Console.Clear(); pattern.OutPutBus(); break;
                                    case 9: Console.Clear(); pattern.OutPutRoute(); break;
                                    case 0: Console.Clear(); flag = false;break;
                                    default:
                                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 6.");
                                        break;

                                }
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            bool flag = true;
                            while (flag)
                            {
                                Console.WriteLine("Меню удаления элементов");
                                Console.WriteLine("1. Удалить водителя");
                                Console.WriteLine("2. Удалить автобус");
                                Console.WriteLine("3. Удалить маршрут");
                                Console.WriteLine("0. Выйти в главное меню");
                                int choice3 = int.Parse(Console.ReadLine());
                                switch (choice3)
                                {
                                    case 1: Console.Clear(); pattern.DeleteVoditel(); break;
                                    case 2: Console.Clear(); pattern.DeleteBus(); break;
                                    case 3: Console.Clear(); pattern.DeleteRoute(); break;
                                    case 0: Console.Clear(); flag = false;break;
                                    default:
                                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 4.");
                                        break;
                                }
                            }
                        }break;
                    case 0:
                                return;
                            default:
                                Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 3.");
                                break;
                            } 
               
            }

            Console.Read();
        }
    }
}

