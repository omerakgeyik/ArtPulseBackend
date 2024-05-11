using ArtPulseAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System;

namespace ArtPulseAPI.Data
{
    public class DataContext : DbContext
    {
        internal DbSet<Customer> Customers { get; set; }
        internal DbSet<Offer> Offers { get; set; }
        internal DbSet<Product> Products { get; set; }
        internal DbSet<Seller> Sellers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seeder.Seed(modelBuilder);
        }
    }
}
