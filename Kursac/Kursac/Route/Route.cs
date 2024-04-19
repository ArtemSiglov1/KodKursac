using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kursac
{
    /// <summary>
/// класс описывающий маршрут
/// </summary>
        [Serializable]
        public class Route
        {
        /// <summary>
        /// идентификатор
        /// </summary>
            public int Id { get; set; }
        /// <summary>
        /// номер маршрута
        /// </summary>
            public int Nom { get; set; }
        /// <summary>
        /// пункт отправления
        /// </summary>
            public string Start { get; set; }
        /// <summary>
        /// пункт назначения
        /// </summary>
            public string End { get; set; }
        /// <summary>
        /// время начала движения
        /// </summary>
            public DateTime TimeStart { get; set; }
        /// <summary>
        /// время конца движения
        /// </summary>
            public DateTime Timeend { get; set; }
        /// <summary>
        /// гос номер автомобиля работающего на маршруте
        /// </summary>
            public string GosNom { get; set; }
        /// <summary>
        /// идентификатор водителя работающего на маршруте
        /// </summary>
            public int VoditelId { get; set; }
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
            public Route() { }
        /// <summary>
        /// конструктор с парметрами
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="nom">номер маршрута</param>
        /// <param name="start">пункт отправки</param>
        /// <param name="end">пункт назначения</param>
        /// <param name="timestart">время начала движения</param>
        /// <param name="timeend">время конца движения</param>
        /// <param name="gosNom">гос номер</param>
        /// <param name="voditelId">идентификатор водителя</param>
            public Route(int id, int nom, string start, string end, DateTime timestart, DateTime timeend, string gosNom, int voditelId)
            {
                Id = id;
                Nom = nom;
                Start = start;
                End = end;
                TimeStart = timestart;
                Timeend = timeend;
                GosNom = gosNom;
                VoditelId = voditelId;
            }
        /// <summary>
        /// метод вывода информации об объекте
        /// </summary>
        /// <returns>свойства класса</returns>
            public override string ToString()
            {
                return $"Id-{Id} Nom-{Nom} Start-{Start} End-{End} Time Start-{TimeStart} TimeEnd-{Timeend} Gosnom-{GosNom} Voditel Id-{VoditelId}";
            }
        }
}

