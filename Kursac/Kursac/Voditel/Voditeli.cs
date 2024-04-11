using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursac
{
    public class Voditeli
    {
        public int Id { get; set; }
        public FullName FullName { get; set; }
        public double Experience { get; set; }
        public int ExperienceLevel { get; set; }
        public double Salary { get; set; }
        public int Route { get; set; }
        public DayOfWeek[] Schedule { get; set; }
        public int DayJob {  get; set; }
        public Voditeli() { }
        public Voditeli(int id, FullName fullName, double experience, int experienceLevel, int route, DayOfWeek[] schedule,int dayJob)
        {
            Id = id;
            FullName = ValidateFullName(fullName);
            Experience = experience;
            ExperienceLevel = experienceLevel;
            Salary = Salary1();
            Route = route;
            Schedule = schedule;
            DayJob = dayJob;
        }
        private string Day()
        {             
                 return $"{Schedule[0]}-{Schedule[0] + (DayJob - 1)}";
        }
        private FullName ValidateFullName(FullName fullName)
        {
            try
            {
                if (string.IsNullOrEmpty(fullName.FirstName) ||
                    string.IsNullOrEmpty(fullName.LastName))
                {
                    throw new Exception();
                }
            }
            catch { Console.WriteLine(new ArgumentException("Имя и фамилия не могут быть пустыми")); fullName = Pattern.InitFullName(); }
            try
            {
                foreach (char c in fullName.FirstName + fullName.LastName + fullName.MiddleName)
                {
                    if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z')
                    {
                        throw new Exception();
                    }
                }
            }
            catch { Console.WriteLine(new ArgumentException("буквы только русской расскладки")); fullName = Pattern.InitFullName(); }
            return fullName;
        }
        int Salary1()
        {
            if (Experience < 5 || ExperienceLevel == 3)
            {
                return 3600;
            }
            else if (Experience > 5 && Experience < 10 || ExperienceLevel == 2)
            {
                return 4200;
            }
            else if (Experience > 10 || ExperienceLevel == 1)
            {
                return 5400;
            }
            else { return 1500; }
        }

        public override string ToString()
        {
            return $"Id-{Id}\nFIO:\n{FullName.ToString()}\nСтаж-{Experience}\nКласс-{ExperienceLevel}\nДоход-{Salary}\nМаршрут-{Route}\nГрафик-{Day()}";
        }
    }
}
