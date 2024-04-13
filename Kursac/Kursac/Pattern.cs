using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursac
{
    public class Pattern
    {
        List<Voditeli> voditelis = new List<Voditeli>();
        List<Route> routes = new List<Route>();
        List<Bus> buses = new List<Bus>();
        public static FullName InitFullName()
        {
            Console.WriteLine();
            string firstName = Console.ReadLine();
            Console.WriteLine();
            string lastName = Console.ReadLine();
            Console.WriteLine();
            string middleName = Console.ReadLine();
            return new FullName(firstName, lastName, middleName);

        }
        public  Voditeli InitVoditel()
        {
            try
            {
                Console.WriteLine("id:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Full Name:");
                FullName fullName = InitFullName();
                Console.WriteLine("Experience:");
                double exp = double.Parse(Console.ReadLine());
                Console.WriteLine("Experience Level:");
                int expLevel = int.Parse(Console.ReadLine());
                Console.WriteLine("Route:");
                int route = int.Parse(Console.ReadLine());
                Console.WriteLine("Schedule:");
                int daystart = int.Parse(Console.ReadLine());
                Console.WriteLine("Сколько дней работает водитель?");
                int dayJob = int.Parse(Console.ReadLine());
                DayOfWeek[] schedule = new DayOfWeek[dayJob];
                
                for (int i = 0; i < schedule.Length; i++) {
                    schedule[i]= DateTime.FromOADate(daystart+i).DayOfWeek;
                }
                
                return new Voditeli(id, fullName, exp, expLevel, route, schedule,dayJob);
            }
            catch { return InitVoditel(); }
        }
        public Route InitRoute()
        {
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
            Console.WriteLine("Какой автобус закрепить за маршрутом");
            foreach (var elem in buses)
            {
                Console.WriteLine( elem.GosNom);
            }
            Console.WriteLine("input index");
            int index = int.Parse(Console.ReadLine());
            string gosNom = buses[index-1].GosNom;
            Console.WriteLine("pinned voditel");
            foreach (var elem in voditelis)
            {
                Console.WriteLine(elem.Id);
            }
            Console.WriteLine("input index");
            index = int.Parse(Console.ReadLine());
            int voditelId =voditelis[index-1].Id ;
            return new Route(id, nom, start, end, timeStart, timeEnd, gosNom, voditelId);
        }
        public Bus InitBus()
        {
            Console.WriteLine("Id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nom:");
            string gosnom = Console.ReadLine();
            Console.WriteLine("Start:");
            string tip = Console.ReadLine();
            Console.WriteLine("End:");
            int volume = int.Parse(Console.ReadLine());
            Console.WriteLine("Time Start:");
            bool ispraven=bool.Parse(Console.ReadLine());
            return new Bus(id,gosnom,tip,volume,ispraven);
        }
        public string RouteVoditel()
        {
            foreach (var item in routes)
            {
                Console.WriteLine("Маршрут-"+item.Nom);
            }
            Console.WriteLine("Водители какого маршрута вас интересуют?");
            int nom = int.Parse(Console.ReadLine());
            foreach (var route in voditelis)
            {
                if (route.Route == nom) { return route.ToString(); } 
            }
                return null;
        }
        public string RouteBus()
        {
            foreach (var item in routes)
            {
                Console.WriteLine("Маршрут-" + item.Nom);
            }
            Console.WriteLine("Водители какого маршрута вас интересуют?");
            int nom = int.Parse(Console.ReadLine());
            foreach (var route in routes)
            {
                if (route.Nom == nom) 
                { 
                    foreach (var item in buses)
                    {
                        if (route.GosNom == item.GosNom)
                        {
                            Console.WriteLine(item.GosNom);
                        }
                    }
                }
            }
            return null;
        }
        public TimeSpan Lenght()
        {
            TimeSpan time;
            foreach (var item in routes)
            {
              time= item.Timeend - item.Timeend;
            }
             time=TimeSpan.MaxValue;
             time=TimeSpan.MinValue;
            return 
        }
        
    }
}
