using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poetry_Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Type { get; set; } // e.g., Poetry, Haiku
        public string Language { get; set; } // e.g., English, Arabic

     
    }
}
