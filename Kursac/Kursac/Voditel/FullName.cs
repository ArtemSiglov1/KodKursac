using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursac
{
    [Serializable]
    public class FullName
    {
        /// <summary>
        /// конструктор с параметрами 
        /// </summary>
        /// <param name="firstName">фамилия</param>
        /// <param name="lastName">имя</param>
        /// <param name="middleName">отчество</param>
        public FullName(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        /// <summary>
        /// фамилия
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// имя
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Может быть отчеством
        /// </summary>
        public string MiddleName { get; set; } = null;
        public override string ToString()
        {
            return $"First Name-{FirstName} Last Name-{LastName} Midle Name-{MiddleName}";
        }
    }
}
