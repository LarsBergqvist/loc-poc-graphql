using Microsoft.EntityFrameworkCore;
using LocPoc.Contracts;
using System;

namespace LocPoc.Repository.Sqlite
{
    public class SqliteContext : DbContext
    {
        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=locpoc.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>().HasData(new Location
                { Id = Guid.NewGuid().ToString(), Name = "Eiffel Tower", Description = "Viva La France", Latitude = 48.858372, Longitude = 2.294481 });
            modelBuilder.Entity<Location>().HasData(new Location
                { Id = Guid.NewGuid().ToString(), Name = "Stockholms Stadshus", Description = "Hello Stockholm", Latitude = 59.327422, Longitude = 18.054265 });
        }
    }
}
