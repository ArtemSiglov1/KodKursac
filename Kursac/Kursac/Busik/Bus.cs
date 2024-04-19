using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kursac
{
    /// <summary>
    /// класс описывающий автобус
    /// </summary>
    [Serializable]
    public class Bus
    { 
        /// <summary>
        /// идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// гос номер 
        /// </summary>
        public string GosNom { get; set; }
        /// <summary>
        /// тип
        /// </summary>
        public string Tip { get; set; }
        /// <summary>
        /// вместимость
        /// </summary>
        public int Volume { get; set; }
        /// <summary>
        /// исправен
        /// </summary>
        public bool Ispraven { get; set; }
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Bus() { }
        /// <summary>
        /// конструктор с параметрами
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="gosNom">гос номер</param>
        /// <param name="tip">тип</param>
        /// <param name="volume">вместимость</param>
        /// <param name="ispraven">исправен</param>
        public Bus(int id, string gosNom, string tip, int volume, bool ispraven)
        {
            Id = id;
            GosNom = gosNom;
            Tip = tip;
            Volume = volume;
            Ispraven = ispraven;
        }
        /// <summary>
        /// метод для вывода информации о объекте
        /// </summary>
        /// <returns>свойства класса</returns>
        public override string ToString()
        {
            return $"Id: {Id}, GosNom: {GosNom}, Tip: {Tip}, Volume: {Volume}, Ispraven: {Ispraven}";
        }
    }
}
