using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Parking_App.Models
{
    public class ParkingAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private static string _connStr =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=myPark;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connStr);
        }
    }
}