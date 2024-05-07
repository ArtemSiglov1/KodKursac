using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kursac
{
    public class Pattern
    {
        /// <summary>
        /// лист объектов класса водители
        /// </summary>
        List<Voditeli> voditelis = new List<Voditeli>();
        /// <summary>
        /// лист объектов класса маршрут
        /// </summary>
        List<Route> routes = new List<Route>();
        /// <summary>
        /// лист объектов класса автобус
        /// </summary>
        List<Bus> buses = new List<Bus>();
        static string currentDirectory = Directory.GetCurrentDirectory();
        /// <summary>
        /// путь к файлу в котором записана инфа о водителях
        /// </summary>
        DirectoryInfo DirectoryInfoVoditeli = new DirectoryInfo($"{currentDirectory}\\Voditeli.bin");
        /// <summary>
        /// путь к файлу в котором записана инфа о маршрутах
        /// </summary>
        DirectoryInfo DirectoryInfoRoute = new DirectoryInfo($"{currentDirectory}\\Route.bin");
        /// <summary>
        /// путь к файлу в котором записана инфа об Автобусах
        /// </summary>
        DirectoryInfo DirectoryInfoBus = new DirectoryInfo($"{currentDirectory}\\Bus.bin");
        /// <summary>
        /// метод для создания экземпляра класса полного имени
        /// </summary>
        /// <returns></returns>
        public static FullName InitFullName()
        {
            Console.WriteLine("Фамилия:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Имя:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Отчество:");
            string middleName = Console.ReadLine();
            return new FullName(firstName, lastName, middleName);

        }
        /// <summary>
        /// метод для создания экземпляра класса водители
        /// </summary>
        public void InitVoditel()
        {
            try
            {
                LoadVoditeli(DirectoryInfoVoditeli.FullName);
                Console.WriteLine("Id:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Полное имя:");
                FullName fullName = InitFullName();
                Console.WriteLine("Стаж:");
                double exp = double.Parse(Console.ReadLine());
                Console.WriteLine("Класс:");
                int expLevel = int.Parse(Console.ReadLine());
                Console.WriteLine("Маршрут:");
                int route = int.Parse(Console.ReadLine());
                Console.WriteLine("График:");
                int daystart = int.Parse(Console.ReadLine());
                Console.WriteLine("Сколько дней работает водитель?");
                int dayJob = int.Parse(Console.ReadLine());
                DayOfWeek[] schedule = new DayOfWeek[dayJob];

                for (int i = 0; i < schedule.Length; i++)
                {
                    schedule[i] = DateTime.FromOADate(daystart + i).DayOfWeek;
                }

                voditelis.Add(new Voditeli(id, fullName, exp, expLevel, route, schedule));
                SaveVoditeli(DirectoryInfoVoditeli.FullName);
            }
            catch { InitVoditel(); }
        }
        /// <summary>
        /// метод для создания экземпляра класса маршрут
        /// </summary>
        public void InitRoute()
        {
            try
            {
                LoadBuses(DirectoryInfoBus.FullName);
                LoadVoditeli(DirectoryInfoVoditeli.FullName);
                Console.WriteLine("Id:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Nom:");
                int nom = int.Parse(Console.ReadLine());
                Console.WriteLine("Start:");
                string start = Console.ReadLine();
                Console.WriteLine("End:");
                string end = Console.ReadLine();
                Console.WriteLine("Time Start:");
                DateTime timeStart = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Time End:");
                DateTime timeEnd = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Выберите автобус для маршрута:");
                foreach (var bus in buses)
                {
                    Console.WriteLine(bus.GosNom);
                }

                Console.WriteLine("Введите индекс:");
                int busIndex = int.Parse(Console.ReadLine());
                string gosNom = buses[busIndex - 1].GosNom;
                Console.WriteLine("Выберите водителя для маршрута:");
                foreach (var driver in voditelis)
                {
                    Console.WriteLine(driver.Id);
                }

                Console.WriteLine("Введите индекс:");
                int driverIndex = int.Parse(Console.ReadLine());
                int voditelId = voditelis[driverIndex - 1].Id;
                routes.Add(new Route(id, nom, start, end, timeStart, timeEnd, gosNom, voditelId));
                SaveRoutes(DirectoryInfoRoute.FullName);
            }
            catch { InitRoute(); }
        }
        /// <summary>
        /// метод для создания экземпляра класса автобус
        /// </summary>
        public void InitBus()
        {
            try
            {
                LoadBuses(DirectoryInfoBus.FullName);
                Console.WriteLine("Id:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("гос.Номер:");
                string gosnom = Console.ReadLine();
                Console.WriteLine("Тип:");
                string tip = Console.ReadLine();
                Console.WriteLine("Вместимость:");
                int volume = int.Parse(Console.ReadLine());
                Console.WriteLine("Исправен:");
                bool ispraven = bool.Parse(Console.ReadLine());
                buses.Add(new Bus(id, gosnom, tip, volume, ispraven));
                SaveBuses(DirectoryInfoBus.FullName);
            }
            catch { InitBus(); }
        }
        /// <summary>
        /// метод для вывода информации о водителе работающем на определенном маршруте
        /// </summary>
        public void GetRouteVoditel()
        {
            LoadVoditeli(DirectoryInfoVoditeli.FullName);
            LoadRoutes(DirectoryInfoRoute.FullName);
            foreach (var item in routes)
            {
                Console.WriteLine("Маршрут-" + item.Nom);
            }
            Console.WriteLine("Введите номер маршрута, чтобы узнать информацию о водителях:");
            int nom = int.Parse(Console.ReadLine());
            foreach (var driver in voditelis)
            {
                if (driver.Route == nom) { Console.WriteLine( driver.ToString()); }
            }
           
        }
        /// <summary>
        /// метод для вывода информации о автобусе работающем на определенном маршруте
        /// </summary>
        public void GetRouteBus()
        {
            LoadBuses(DirectoryInfoBus.FullName);
            LoadRoutes(DirectoryInfoRoute.FullName);
            foreach (var item in routes)
            {
                Console.WriteLine($"Маршрут-{item.Nom}");
            }
            Console.WriteLine("Введите номер маршрута, чтобы узнать автобусы:");
            int nom = int.Parse(Console.ReadLine());
            foreach (var route in routes)
            {
                if (route.Nom == nom)
                {
                    Console.WriteLine($"Автобусы на маршруте {route.Nom}:");
                    foreach (var item in buses)
                    {
                        if (route.GosNom == item.GosNom)
                        {
                            Console.WriteLine(item.GosNom);
                        }
                    }
                }
            }
           
        }
        /// <summary>
        /// расчет максимальной и минимальной протяженности маршрута в минутах
        /// </summary>
        public void CalculateRouteLength()
        {
            LoadRoutes(DirectoryInfoRoute.FullName);
            int max = 0;
            int min = int.MaxValue;
            foreach (var item in routes)
            {
                TimeSpan time = item.Timeend - item.TimeStart;
                int routeLenght = (int)time.TotalMinutes;
                if (routeLenght > max) { max = routeLenght; }
                if (routeLenght < min) { min = routeLenght; }
                Console.WriteLine($"Route {item.Nom}: {routeLenght} minutes");
            }
            Console.WriteLine($"Minimum route length: {min} minutes");
            Console.WriteLine($"Maximum route length: {max} minutes");


        }
        /// <summary>
        /// метод для вывода информации о маршруте на котором работает водитель с максимальным стажем
        /// </summary>
        /// <returns></returns>
        public Route GetRouteMaxExp()
        {
            LoadVoditeli(DirectoryInfoVoditeli.FullName);
            LoadRoutes(DirectoryInfoRoute.FullName);
            Voditeli voditeli = null;
            double maxExp = 0;
            foreach (var driver in voditelis)
            {
                if (driver.Experience > maxExp) { maxExp = driver.Experience; }
                if (driver.Experience == maxExp) { voditeli = driver; }
            }
            foreach (var route in routes)
            {
                if (route.VoditelId == voditeli.Id)
                {
                    return route;
                }
            }
            return null;
        }
        /// <summary>
        /// рассчет общей протяженности маршрута в минутах
        /// </summary>
        /// <returns></returns>
        public int AllRouteLenght()
        {
            LoadRoutes(DirectoryInfoRoute.FullName);
            int allLenght = 0;

            foreach (var route in routes)
            {
                TimeSpan duration = route.Timeend - route.TimeStart;
                allLenght += (int)duration.TotalMinutes;
            }
            return allLenght;
        }
        /// <summary>
        /// выводит информацию о водителях не вышедших на работу из-за неисправности автобуса
        /// </summary>
        public void VoditelNoJobBusFailure()
        {
            LoadVoditeli(DirectoryInfoVoditeli.FullName);
            LoadRoutes(DirectoryInfoRoute.FullName);
            LoadBuses(DirectoryInfoBus.FullName);
            foreach (var bus in buses)
            {
                if (bus.Ispraven == false)
                {
                    foreach (var route in routes)
                    {
                        if (route.GosNom == bus.GosNom)
                        {
                            foreach (var driver in voditelis)
                            {
                                if (driver.Id == route.VoditelId)
                                {
                                    Console.WriteLine(driver);
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// удаляет заданного водителя
        /// </summary>
        public void DeleteVoditel()
        {
            try
            {

                LoadVoditeli(DirectoryInfoVoditeli.FullName);
                Voditeli voditeli = null;
                foreach (var driver in voditelis)
                {
                    Console.WriteLine(driver.Id);
                }
                int id = int.Parse(Console.ReadLine());
                foreach (var driver in voditelis)
                {
                    if (id == driver.Id)
                    {
                        voditeli=driver;
                    }
                }
                voditelis.Remove(voditeli);
                SaveVoditeli(DirectoryInfoVoditeli.FullName);
            }
            catch { }
        }
        /// <summary>
        /// удаляет заданый автобус
        /// </summary>
        public void DeleteBus()
        {
            LoadBuses(DirectoryInfoBus.FullName);
            Bus bus1 = null;
            foreach (var bus in buses)
            {
                Console.WriteLine(bus.Id);
            }
            int id = int.Parse(Console.ReadLine());
            foreach (var bus in buses)
            {
                if (id == bus.Id)
                {
                    bus1=bus;
                }
            }
            buses.Remove(bus1);
            SaveBuses(DirectoryInfoBus.FullName);
        }
        /// <summary>
        /// удаляет заданный маршрут
        /// </summary>
        public void DeleteRoute()
        {
            LoadRoutes(DirectoryInfoRoute.FullName);
            Route route1 = null;
            foreach (var route in routes)
            {
                Console.WriteLine(route.Id);
            }
            int id = int.Parse(Console.ReadLine());
            foreach (var route in routes)
            {
                if (id == route.Id)
                {
                    route1=route;
                }
            }
            routes.Remove(route1);
            SaveRoutes(DirectoryInfoRoute.FullName);
        }
        /// <summary>
        /// вывод информации о всех водителях
        /// </summary>
        public void OutPutVoditeli()
        {
            LoadVoditeli(DirectoryInfoVoditeli.FullName);
            foreach (var driver in voditelis)
            {
                Console.WriteLine( driver.ToString());
            }
            
        }
        /// <summary>
        /// вывод информации о всех автобусах
        /// </summary>
        public void OutPutBus()
        {
            LoadBuses(DirectoryInfoBus.FullName);
            foreach (var bus in buses)
            {
                Console.WriteLine( bus.ToString());
            }
        }
        /// <summary>
        /// вывод информации о всех маршрутах
        /// </summary>
        public void OutPutRoute()
        {
            LoadRoutes(DirectoryInfoRoute.FullName);
            foreach (var route in routes)
            {
                Console.WriteLine( route.ToString());
            }
        }
        /// <summary>
        /// метод для сохранения листа водителей
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        public void SaveVoditeli(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, voditelis);
            }
        }
        /// <summary>
        /// метод для загрузки из файла в лист водители
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        public void LoadVoditeli(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                voditelis = (List<Voditeli>)formatter.Deserialize(fs);
            }
        }

        /// <summary>
        /// метод для сохранения листа маршрута
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        public void SaveRoutes(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, routes);
            }
        }
        /// <summary>
        /// метод для загрузки из файла в лист маршрут
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        public void LoadRoutes(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                    routes = (List<Route>)formatter.Deserialize(fs);
            }
        }
        /// <summary>
        /// метод для сохранения листа автобусы
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        public void SaveBuses(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, buses);
            }
        }
        /// <summary>
        /// метод для загрузки из файла в лист автобусы
        /// </summary>
        /// <param name="fileName">путь к файлу</param>
        public void LoadBuses(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                buses = (List<Bus>)formatter.Deserialize(fs);
            }
        }
    }
}
