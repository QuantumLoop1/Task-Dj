using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Task_Dj.DbContextDj
{
    public class DJReadDbContext : DbContext
    {
        public DJReadDbContext(DbContextOptions<DJReadDbContext> options)
            : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<DJ> DJ { get; set; }
        public DbSet<Track> Track { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DJ>().HasKey(a =>  a.Id);

            modelBuilder.Entity<DJ>()
                .HasMany(a => a.Tracks)
                .WithOne(p => p.DJ);
                
        }
    }
}
