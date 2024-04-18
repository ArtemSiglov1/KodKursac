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
        List<Voditeli> voditelis = new List<Voditeli>();
        List<Route> routes = new List<Route>();
        List<Bus> buses = new List<Bus>();
        string voditeliPath = @"C:\Users\Home\source\repos\Kursac\Kursac\Voditeli.txt";
        string routePath = @"C:\Users\Home\source\repos\Kursac\Kursac\Route.txt";
        string busPath = @"C:\Users\Home\source\repos\Kursac\Kursac\Bus.txt";
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
        public void InitVoditel()
        {
            try
            {
                LoadVoditeli(voditeliPath);
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
                SaveVoditeli(voditeliPath);
            }
            catch { InitVoditel(); }
        }
        public void InitRoute()
        {
            try
            {
                LoadBuses(busPath);
                LoadVoditeli(voditeliPath);
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
                SaveRoutes(routePath);
            }
            catch { InitRoute(); }
        }
        public void InitBus()
        {
            try
            {
                LoadBuses(busPath);
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
                SaveBuses(busPath);
            }
            catch { InitBus(); }
        }
        public void GetRouteVoditel()
        {
            LoadVoditeli(voditeliPath);
            LoadRoutes(routePath);
            foreach (var item in routes)
            {
                Console.WriteLine("Маршрут-" + item.Nom);
            }
            Console.WriteLine("Введите номер маршрута, чтобы узнать информацию о водителях:");
            int nom = int.Parse(Console.ReadLine());
            foreach (var route in voditelis)
            {
                if (route.Route == nom) { Console.WriteLine( route.ToString()); }
            }
           
        }
        public void GetRouteBus()
        {
            LoadBuses(busPath);
            LoadRoutes(routePath);
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
        public void CalculateRouteLength()
        {
            LoadRoutes(routePath);
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
        public Route GetRouteMaxExp()
        {
            LoadVoditeli(voditeliPath);
            LoadRoutes(routePath);
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
        public int AllRouteLenght()
        {
            LoadRoutes(routePath);
            int allLenght = 0;

            foreach (var route in routes)
            {
                TimeSpan duration = route.Timeend - route.TimeStart;
                allLenght += (int)duration.TotalMinutes;
            }
            return allLenght;
        }
        public void VoditelNoJobBusFailure()
        {
            LoadVoditeli(voditeliPath);
            LoadRoutes(routePath);
            LoadBuses(busPath);
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
        public void DeleteVoditel()
        {
            try
            {

                LoadVoditeli(voditeliPath);
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
                SaveVoditeli(voditeliPath);
            }
            catch { }
        }
        public void DeleteBus()
        {
            LoadBuses(busPath);
            foreach (var bus in buses)
            {
                Console.WriteLine(bus.Id);
            }
            int id = int.Parse(Console.ReadLine());
            foreach (var bus in buses)
            {
                if (id == bus.Id)
                {
                    buses.Remove(bus);
                }
            }
            SaveBuses(busPath);
        }
        public void DeleteRoute()
        {
            LoadRoutes(routePath);
            foreach (var route in routes)
            {
                Console.WriteLine(route.Id);
            }
            int id = int.Parse(Console.ReadLine());
            foreach (var route in routes)
            {
                if (id == route.Id)
                {
                    routes.Remove(route);
                }
            }
            SaveRoutes(routePath);
        }
        public void OutPutVoditeli()
        {
            LoadVoditeli(voditeliPath);
            foreach (var driver in voditelis)
            {
                Console.WriteLine( driver.ToString());
            }
            
        }
        public void OutPutBus()
        {
            LoadBuses(busPath);
            foreach (var bus in buses)
            {
                Console.WriteLine( bus.ToString());
            }
        }
        public void OutPutRoute()
        {
            LoadRoutes(routePath);
            foreach (var route in routes)
            {
                Console.WriteLine( route.ToString());
            }
        }
        // Методы сохранения и загрузки для класса Voditeli
        public void SaveVoditeli(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, voditelis);
            }
        }

        public void LoadVoditeli(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                voditelis = (List<Voditeli>)formatter.Deserialize(fs);
            }
        }

        // Методы сохранения и загрузки для класса Route
        public void SaveRoutes(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, routes);
            }
        }

        public void LoadRoutes(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                    routes = (List<Route>)formatter.Deserialize(fs);
            }
        }

        // Методы сохранения и загрузки для класса Bus
        public void SaveBuses(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, buses);
            }
        }

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
