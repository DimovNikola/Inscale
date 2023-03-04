using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceDto>().HasData(
                new ResourceDto
                {
                    Id = 1,
                    Name = "Resource X",
                    Quantity = 100
                },
                new ResourceDto
                {
                    Id = 2,
                    Name = "Resource Y",
                    Quantity = 200
                },
                new ResourceDto
                {
                    Id = 3,
                    Name = "Resource Z",
                    Quantity = 70
                }
            );
        }

        public DbSet<ResourceDto> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
