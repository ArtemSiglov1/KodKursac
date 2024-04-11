using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kursac
{
    public class Bus
    {
        public Bus() { }
        public Bus(int id, string gosNom, string tip, int volume, bool ispraven)
        {
            Id = id;
            GosNom = IsValidGosNom(gosNom);
            Tip = tip;
            Volume = volume;
            Ispraven = ispraven;
        }

        public int Id { get; set; }
        public string GosNom { get; set; }
        public string Tip { get; set; }
        public int Volume { get; set; }
        public bool Ispraven { get; set; }
        private string IsValidGosNom(string gosNom)
        {
            try
            {
                if (gosNom == null || !Regex.IsMatch(gosNom, @"^[А-С]{1}\d{3}[А-Я]{2}$"))
                {
                    throw new Exception();
                }
            }
            catch { Console.WriteLine(new ArgumentException("Гос.Номер должен состоять из 1 буквы 3 цифр и 2 букв")); }
            return gosNom;
        }
    }
}
