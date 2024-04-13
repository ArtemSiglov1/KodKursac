using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Kursac
    {
        public class Program
        {
            static  void Main(string[] args)
            {
            List<Voditeli> voditelis = new List<Voditeli>();
            List<Route> routes = new List<Route>();
            List<Bus> buses = new List<Bus>();
            Pattern pattern=new Pattern();
            Voditeli voditeli=pattern.InitVoditel();

           // Voditeli voditeli = new Voditeli(23, new FullName("", "Артем", null), 8, 2, 1, new DateTime[5] { });
            Console.WriteLine(voditeli.ToString());
            
            //Route route=pattern.InitRoute();
            //Console.WriteLine(route.ToString());
            Console.Read();
            }
        }
   }

