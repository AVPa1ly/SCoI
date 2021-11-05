using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Models
{
    public class ListViewModel<T> : List<T> where T : class
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        private ListViewModel(IEnumerable<T> items, int total, int current) : base(items)
        {
            TotalPages = total;
            CurrentPage = current;
        }

        /// <summary>
        /// Получить модель представления списка объектов
        /// </summary>
        /// <param name="list">Исходный список объектов</param>
        /// <param name="current">Номер текущей страницы</param>
        /// <param name="itemsPerPage">Кол-во объектов на странице</param>
        /// <returns>Объект класса ListViewModel</returns>
        public static ListViewModel<T> GetModel(IEnumerable<T> list, int current, int itemsPerPage)
        {
            var items = list.Skip((current - 1) * itemsPerPage).Take(itemsPerPage).ToList();
            var total = (int)Math.Ceiling((double)list.Count() / itemsPerPage);
            return new ListViewModel<T>(items, total, current);
        }
    }
}
