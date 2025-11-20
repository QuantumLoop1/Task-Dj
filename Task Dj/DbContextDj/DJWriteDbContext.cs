using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task_Dj.DbContextDj
{
    public class DJWriteDbContext : DbContext
    {
        public DJWriteDbContext(DbContextOptions<DJWriteDbContext> options)
            : base(options) { }
        public DbSet<DJ> DJ { get; set; }
        public DbSet<Track> Track { get; set; }
    }
}
