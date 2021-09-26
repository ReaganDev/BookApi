using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApiModels
{
    public class Publisher
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<Book> Books { get; set; }
    }
}
