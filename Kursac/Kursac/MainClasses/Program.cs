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
        static void Main()
        {
            try
            {
                Pattern pattern = new Pattern();

                while (true)
                {
                    
                    Console.WriteLine("Главное меню:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("1. Добавить элемент");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("2. Вывод информации");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("3. Удалить элемент");
                    Console.ForegroundColor = ConsoleColor.White;
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
                                    Console.Clear();
                                    Console.WriteLine("Меню добавления элементов:");
                                    Console.WriteLine("1. Добавить водителя");
                                    Console.WriteLine("2. Добавить автобус");
                                    Console.WriteLine("3. Добавить маршрут");
                                    Console.WriteLine("0. Выход в главное меню");
                                    int choice1 = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    switch (choice1)
                                    {
                                        case 1: pattern.InitVoditel(); break;
                                        case 2: pattern.InitBus(); break;
                                        case 3: pattern.InitRoute(); break;
                                        case 0: flag = false; break;
                                        default:
                                            Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 3.");
                                            break;
                                    }
                                }
                            }
                            break;
                        case 2:
                            {

                                bool flag = true;
                                while (flag)
                                {
                                    Console.Clear();
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
                                    Console.Clear();
                                    switch (choice2)
                                    {

                                        case 1: pattern.GetRouteVoditel(); Console.ReadLine(); break;
                                        case 2: pattern.GetRouteBus(); Console.ReadLine(); break;
                                        case 3: pattern.CalculateRouteLength(); Console.ReadLine(); break;
                                        case 4: Console.WriteLine(pattern.GetRouteMaxExp()); Console.ReadLine(); break;
                                        case 5: Console.WriteLine($"Общая протяженность маршрутов: {pattern.AllRouteLenght()} минут"); Console.ReadLine(); break;
                                        case 6: pattern.VoditelNoJobBusFailure(); Console.ReadLine(); break;
                                        case 7: pattern.OutPutVoditeli(); Console.ReadLine(); break;
                                        case 8: pattern.OutPutBus(); Console.ReadLine(); break;
                                        case 9: pattern.OutPutRoute(); Console.ReadLine(); break;
                                        case 0: flag = false; break;
                                        default:
                                            Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 6."); Console.ReadLine(); Console.Clear();
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
                                    Console.Clear();
                                    Console.WriteLine("Меню удаления элементов");
                                    Console.WriteLine("1. Удалить водителя");
                                    Console.WriteLine("2. Удалить автобус");
                                    Console.WriteLine("3. Удалить маршрут");
                                    Console.WriteLine("0. Выйти в главное меню");
                                    int choice3 = int.Parse(Console.ReadLine());
                                    Console.Clear();
                                    switch (choice3)
                                    {
                                        case 1: pattern.DeleteVoditel(); break;
                                        case 2: pattern.DeleteBus(); break;
                                        case 3: pattern.DeleteRoute(); break;
                                        case 0: flag = false; break;
                                        default:
                                            Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 4."); Console.ReadLine(); Console.Clear();
                                            break;
                                    }
                                }
                            }
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 3."); Console.ReadLine(); Console.Clear();
                            break;
                    }

                }
            }
            catch { Console.Clear(); Main(); }
            
        }
    }
}

