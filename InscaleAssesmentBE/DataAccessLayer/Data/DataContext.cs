namespace DataAccessLayer.Data
{
    using DataAccessLayer.Models;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasData(
                new Resource
                {
                    Id = 1,
                    Name = "Resource X",
                    Quantity = 100
                },
                new Resource
                {
                    Id = 2,
                    Name = "Resource Y",
                    Quantity = 200
                },
                new Resource
                {
                    Id = 3,
                    Name = "Resource Z",
                    Quantity = 70
                }
            );
        }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
