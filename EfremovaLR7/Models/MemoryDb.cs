using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfremovaLR7.Models
{
    public class MemoryDb
    {
        public static List<Book> Books { get; set; } = new List<Book>
        {
            new Book { Id = 1, Title="White Fang", Author = "Jack London", Genre = "Роман",Year = 1973, PublisherId = 1},
            new Book { Id = 2, Title="White Bang", Author = "Jack London",  Genre = "Учебник",Year = 1973, PublisherId = 1},
            new Book { Id = 3, Title="White Gang", Author = "Jack London",Genre = "Фантастика", Year = 1973, PublisherId = 1},
            new Book { Id = 4, Title="White Tang", Author = "Jack London", Genre = "Роман",Year = 1973, PublisherId = 1},
            new Book { Id = 5, Title="White Mang", Author = "Jack London", Genre = "Учебник",Year = 1973, PublisherId = 1},
        };

    }
}