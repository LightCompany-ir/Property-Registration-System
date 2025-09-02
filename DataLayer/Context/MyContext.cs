using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUser>().HasData(
                new AdminUser()
                {
                    AdminUserId = 1,
                    FullName = "میلاد اسدی",
                    UserName = "lightco",
                    Password = "123456789",
                    Phone = "09116430304",
                    RegisterDate = new DateTime(2025, 09, 01),
                    UserImage = "Default.png",
                    IsActive = true
                }
                );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AdminUser> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
