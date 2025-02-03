using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class Verse
{
    public int VerseId { get; set; }
    public string Content { get; set; }
    public int AuthorId { get; set; } // Foreign Key to Author
    public int CategoryId { get; set; } // Foreign Key to Category
    public DateTime DateAdded { get; set; }
    public bool IsApproved { get; set; }

    // Navigation Properties
    public Author Author { get; set; }
    public Category Category { get; set; }
}
