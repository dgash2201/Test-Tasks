using System.Collections.Generic;
using Server.Database.Entities;

namespace Client1.Models
{
    public class EntriesViewModel
    {
        public IEnumerable<Entry> Entries { get; set; }
    }
}
