using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models;

public class Request
{
    public int RequestId { get; set; }
    public string Email { get; set; } // No Foreign Key
    public int VerseId { get; set; } // Foreign Key to Verse
    public string Status { get; set; } // Enum-like: Pending, Approved, Rejected
    public DateTime SubmittedAt { get; set; }

    // Navigation Property
    public Verse Verse { get; set; }
}
