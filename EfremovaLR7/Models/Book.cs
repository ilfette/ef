using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfremovaLR7.Models
{
    public enum eGenre { Не_определен, Детектив, Фантастика, Фентези, Роман, Учебник };
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; } 

        //внешний ключ
        public int PublisherId { get; set; }
        //навигационное свойство
        public Publisher Publisher { get; set; }


        //public Book()
        //{
        //    Title = "Не указано";
        //    Author = "Не указан";
        //    Publisher = "Не указано";
        //    Year = 0;
        //}

    }
}