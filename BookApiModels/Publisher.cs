using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApiModels
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Book> Books { get; set; }
    }
}
