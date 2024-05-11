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
            SeedCustomer(modelBuilder, 100);
            Seller[] seededSellers = SeedSellers(modelBuilder, 100);
            SeedProduct(modelBuilder, 100, seededSellers);
        }

        void SeedCustomer(ModelBuilder modelBuilder, int count)
        {
            for (int i = 1; i <= count; i++)
            {
                modelBuilder.Entity<Customer>().HasData(new Customer
                {
                    Address = "address" + i,
                    Email = "email" + i,
                    FirstName = "fname" + i,
                    LastName = "lname" + i,
                    Id = i,
                    PhoneNumber = "pnumber+i",
                    ShoppingCart = null,
                });
            }
        }
        Seller[] SeedSellers(ModelBuilder modelBuilder, int count)
        {
            Seller[] sellers = new Seller[count];
            for(int i = 0; i < count; i++)
            {
                sellers[i] = new Seller
                {
                    Id = i+1,
                    ProductsBeingSold = null,
                    Address = "address" + (i+1),
                    Email = "email" + (i + 1),
                    FirstName = "fname" + (i + 1),
                    LastName = "lname" + (i + 1),
                    PhoneNumber = "pnumber" + (i + 1),
                };
            }
            for (int i = 1; i <= count; i++)
            {
                modelBuilder.Entity<Seller>().HasData(sellers[i - 1]);
            }
            return sellers;
        }
        void SeedProduct(ModelBuilder modelBuilder, int count, Seller[] sellers)
        {
            if(sellers.Length == 0) { return; }

            for (int i = 1; i <= count; i++)
            {
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    Id = i,
                    Amount = Random.Shared.Next(),
                    Category = Category.Category2,
                    Cost = i * 1000,
                    Details = "details"+i,
                    Name= "name"+i,
                    SellerId = sellers[i % sellers.Length].Id,
                    Rating = 4,
                    ShoppingCartsContainingProduct = null,
                    OffersWithThisProduct = null,
                });
            }
        }
    }
}
