using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kursac
{ 
    [Serializable]
    public class Voditeli
    {
        public int Id { get; set; }
        public FullName FullName { get; set; }
        public double Experience { get; set; }
        public int ExperienceLevel { get; set; }
        public double Salary { get; set; }
        public int Route { get; set; }
        public DayOfWeek[] Schedule { get; set; }
        public Voditeli() { }
        public Voditeli(int id, FullName fullName, double experience, int experienceLevel, int route, DayOfWeek[] schedule)
        {
            Id = id;
            FullName = fullName;
            Experience = experience;
            ExperienceLevel = experienceLevel;
            Route = route;
            Schedule = schedule;
            CalculateSalary(); // Вызываем метод для расчета зарплаты при создании объекта
        }
        private void CalculateSalary()
        {
            if (Experience < 5 || ExperienceLevel == 3)
            {
                Salary = 3600;
            }
            else if (Experience > 5 && Experience < 10 || ExperienceLevel == 2)
            {
                Salary = 4200;
            }
            else if (Experience > 10 || ExperienceLevel == 1)
            {
                Salary = 5400;
            }
            else
            {
                Salary = 1500;
            }
        }
        public override string ToString()
        {
            return $"Id-{Id}\nFIO:\n{FullName}\nСтаж-{Experience}\nКласс-{ExperienceLevel}\nДоход-{Salary}\nМаршрут-{Route}\nГрафик-{string.Join(", ", Schedule)}";
        }
    }
}
