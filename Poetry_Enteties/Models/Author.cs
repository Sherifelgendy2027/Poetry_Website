using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry_Entities.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime? BirthDate { get; set; } // Nullable Date
        public DateTime? DeathDate { get; set; } // Nullable Date
     
    }
}
