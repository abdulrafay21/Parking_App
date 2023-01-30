using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Parking_App.Models
{
    public class ParkingAppContext : DbContext
    {
        public DbSet<User> Users;

        private static string _connStr =
            @"Server=localhost,1401; Database=Master; User Id=SA;Password=root";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connStr);
        }
    }
}