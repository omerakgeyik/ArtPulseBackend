using ArtPulseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtPulseAPI.Data
{
    public static class Seeder
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedCustomer(modelBuilder, 100);
            Seller[] seededSellers = SeedSellers(modelBuilder, 100);
            SeedProduct(modelBuilder, 100, seededSellers);
        }

        static void SeedCustomer(ModelBuilder modelBuilder, int count)
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
        static Seller[] SeedSellers(ModelBuilder modelBuilder, int count)
        {
            Seller[] sellers = new Seller[count];
            for (int i = 0; i < count; i++)
            {
                sellers[i] = new Seller
                {
                    Id = i + 1,
                    Address = "address" + (i + 1),
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
        static void SeedProduct(ModelBuilder modelBuilder, int count, Seller[] sellers)
        {
            if (sellers.Length == 0) { return; }

            for (int i = 1; i <= count; i++)
            {
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    Id = i,
                    Amount = Random.Shared.Next(),
                    Category = Category.Category2,
                    Cost = i * 1000,
                    Details = "details" + i,
                    Name = "name" + i,
                    SellerId = sellers[i % sellers.Length].Id,
                    Rating = 4,
                    ShoppingCartsContainingProduct = null,
                    OffersWithThisProduct = null,
                    Image = new byte[0],
                });
            }
        }
    }
}
