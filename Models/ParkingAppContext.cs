using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Parking_App.Models
{
    public class ParkingAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ParkingSpot> Parkings { get; set; }

        // private static string _connStr =
        //     @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=myPark;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public ParkingAppContext()
        {
            //Database.Migrate();

        }


        private static string _connStr = @"Server=localhost; Database=Parking_App; User Id=sa; Password=1410_Rafay; TrustServerCertificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server = backend; Database = master; User = sa; Password = Docker123!; TrustServerCertificate=true; encrypt=false;");

            optionsBuilder.UseSqlServer(_connStr);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ParkingSpot>().HasData(
                new ParkingSpot
                {
                    ID = 10,
                    name = "park1",
                    city = "lahore",
                    isBooked = false,
                    price = 500,
                    timer = DateTime.Now
                },

                new ParkingSpot
                {
                    ID = 11,
                    name = "park2",
                    city = "lahore",
                    price = 600,
                    isBooked = false,
                    timer = DateTime.Now
                },
                new ParkingSpot
                {
                    ID = 12,
                    name = "park1",
                    city = "karachi",
                    price = 1000,
                    isBooked = false,
                    timer = DateTime.Now
                },
               new ParkingSpot
               {
                   ID = 13,
                   name = "park5",
                   city = "qasur",
                   price = 200,
                   isBooked = false,
                   timer = DateTime.Now
               },
                new ParkingSpot
                {
                    ID = 14,
                    name = "park7",
                    city = "qasur",
                    isBooked = false,
                    price = 900,
                    timer = DateTime.Now
                },
                new ParkingSpot
                {
                    ID = 19,
                    name = "park5",
                    city = "lahore",
                    price = 900,
                    isBooked = false,
                    timer = DateTime.Now
                });


        }

        public override int SaveChanges()
        {
            var tracker = ChangeTracker;

            foreach (var entry in tracker.Entries())
            {
                if (entry.Entity is Entity)
                {
                    var referenceEntity = entry.Entity as Entity;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            referenceEntity.CreatedDate = DateTime.Now;
                            referenceEntity.IsActive = true;
                            break;
                        case EntityState.Modified:
                            referenceEntity.ModifiedDate = DateTime.Now;
                            break;
                        case EntityState.Deleted:
                            referenceEntity.IsActive = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}