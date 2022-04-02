using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Server.Entities;

namespace Server.Database
{
    public class EntriesDbContext : DbContext
    {
        public EntriesDbContext([NotNull] DbContextOptions options)
            : base(options) { }

        public DbSet<Entry> Entries { get; set; }
    }
}
