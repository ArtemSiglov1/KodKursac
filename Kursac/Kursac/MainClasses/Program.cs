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
                string log = "Artem";
                string pas = "215";
                
               
                    Console.WriteLine("Введите логин");
                    string logInp = Console.ReadLine();
                    if (log == logInp)
                    {
                        Console.WriteLine("Введите пароль");
                        string pasInp = Console.ReadLine();
                        if (pas == pasInp)
                        {
                        try
                        {
                            Console.Clear();
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Главное меню:");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("1. Добавить элемент");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("2. Вывод информации");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("3. Удалить элемент");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("0. Выход из программы");
                                switch (Console.ReadKey(true).KeyChar)
                                {

                                    case '1':
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

                                                switch (Console.ReadKey(true).KeyChar)
                                                {

                                                    case '1': Console.Clear(); pattern.InitVoditel(); break;
                                                    case '2': Console.Clear(); pattern.InitBus(); break;
                                                    case '3': Console.Clear(); pattern.InitRoute(); break;
                                                    case '0': Console.Clear(); flag = false; break;
                                                    default:
                                                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 3.");
                                                        break;
                                                }
                                            }
                                        }
                                        break;
                                    case '2':
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

                                                switch (Console.ReadKey(true).KeyChar)
                                                {

                                                    case '1': Console.Clear(); pattern.GetRouteVoditel(); Console.ReadLine(); break;
                                                    case '2': Console.Clear(); pattern.GetRouteBus(); Console.ReadLine(); break;
                                                    case '3': Console.Clear(); pattern.CalculateRouteLength(); Console.ReadLine(); break;
                                                    case '4': Console.Clear(); Console.WriteLine(pattern.GetRouteMaxExp()); Console.ReadLine(); break;
                                                    case '5': Console.Clear(); Console.WriteLine($"Общая протяженность маршрутов: {pattern.AllRouteLenght()} минут"); Console.ReadLine(); break;
                                                    case '6': Console.Clear(); pattern.VoditelNoJobBusFailure(); Console.ReadLine(); break;
                                                    case '7': Console.Clear(); pattern.OutPutVoditeli(); Console.ReadLine(); break;
                                                    case '8': Console.Clear(); pattern.OutPutBus(); Console.ReadLine(); break;
                                                    case '9': Console.Clear(); pattern.OutPutRoute(); Console.ReadLine(); break;
                                                    case '0': Console.Clear(); flag = false; break;
                                                    default:
                                                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 9."); Console.ReadLine(); Console.Clear();
                                                        break;

                                                }
                                            }
                                        }
                                        break;
                                    case '3':
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

                                                switch (Console.ReadKey(true).KeyChar)
                                                {

                                                    case '1': pattern.DeleteVoditel(); break;
                                                    case '2': pattern.DeleteBus(); break;
                                                    case '3': pattern.DeleteRoute(); break;
                                                    case '0': flag = false; break;
                                                    default:
                                                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 4."); Console.ReadLine(); Console.Clear();
                                                        break;
                                                }
                                            }
                                        }
                                        break;
                                    case '0':
                                        return;
                                    default:
                                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите пункт меню от 0 до 3."); Console.ReadLine(); Console.Clear();
                                        break;
                                }

                            }
                        }
                        catch(Exception ex) { Console.WriteLine(ex.Message); Console.WriteLine("Enter чтобы продолжить"); Console.ReadLine(); Console.Clear(); }

                        }
                        else
                        {
                            throw new Exception("Не правильный пароль");
                        }
                    }
                    else
                    {
                        throw new Exception("Не правильный логин");
                    }
                }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);Main();
            }

        }
    }
}

