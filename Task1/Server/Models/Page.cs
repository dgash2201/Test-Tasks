using System.Collections.Generic;

namespace Server.Models
{
    public class Page<T>
    {
        public IEnumerable<T> Elements { get; set; }

        public int Number { get; set; }

        public int Size { get; set; }

        public int TotalPages { get; set; }
    }
}
