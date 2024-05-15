using ArtPulseAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ArtPulseAPI.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        internal DbSet<Customer> Customers { get; set; }
        internal DbSet<Offer> Offers { get; set; }
        internal DbSet<Product> Products { get; set; }
        internal DbSet<Seller> Sellers { get; set; }
        internal DbSet<Review> Reviews { get; set; }



        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seeder.Seed(modelBuilder);
        }
    }
}
