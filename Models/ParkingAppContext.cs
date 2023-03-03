using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Parking_App.Models
{
    public class ParkingAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        //private static string _connStr =
        //    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=myPark;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
       public ParkingAppContext()
        {
            Database.Migrate();
        }


        private static string _connStr = @"Server=localhost; Database=Parking_App; User Id=sa; Password=1410_Rafay; TrustServerCertificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                //optionsBuilder.UseSqlServer(@"Server = backend; Database = master; User = sa; Password = Docker123!; TrustServerCertificate=true; encrypt=false;");
            optionsBuilder.UseSqlServer(_connStr);
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