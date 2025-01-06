using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            
            Initial Catalog=OmraniMohamedAmineAirportDB;Integrated Security=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        //applique les configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());

            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");
            
        }

        //Preconvention pour tt les class
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
           configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
        
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staff { get; set; }
    }
}
