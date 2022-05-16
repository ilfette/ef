using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfremovaLR7.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
