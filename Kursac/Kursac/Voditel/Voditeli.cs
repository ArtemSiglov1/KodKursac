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
    /// <summary>
    /// класс описывающий водителя
    /// </summary>
    [Serializable]
    public class Voditeli
    {
        /// <summary>
        /// идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// полное имя
        /// </summary>
        public FullName FullName { get; set; }
        /// <summary>
        /// стаж
        /// </summary>
        public double Experience { get; set; }
        /// <summary>
        /// класс
        /// </summary>
        public int ExperienceLevel { get; set; }
        /// <summary>
        /// доход
        /// </summary>
        public double Salary { get; set; }
        /// <summary>
        /// маршрут
        /// </summary>
        public int Route { get; set; }
        /// <summary>
        /// график
        /// </summary>
        public DayOfWeek[] Schedule { get; set; }
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Voditeli() { }
        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="fullName">полное имя</param>
        /// <param name="experience">стаж</param>
        /// <param name="experienceLevel">класс</param>
        /// <param name="route">маршрут</param>
        /// <param name="schedule">график</param>
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
        /// <summary>
        /// метод для рассчета дохода
        /// </summary>
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
        /// <summary>
        /// метод для вывода информации об объекте
        /// </summary>
        /// <returns>свойства класса</returns>
        public override string ToString()
        {
            return $"Id-{Id} FIO: {FullName} Стаж-{Experience} Класс-{ExperienceLevel} Доход-{Salary} Маршрут-{Route} График-{string.Join(", ", Schedule)}";
        }
    }
}
