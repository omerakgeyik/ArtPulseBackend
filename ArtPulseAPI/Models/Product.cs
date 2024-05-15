using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPulseAPI.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Amount { get; set; }
        [Range(0,5)]
        public float Rating { get; set; }
        public Category Category { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public ICollection<CustomerProduct_ShoppingCart>? ShoppingCartsContainingProduct { get; set; }
        public ICollection<OfferProduct>? OffersWithThisProduct { get; set; } 
    }

    public enum Category : ushort
    {
        Category1 = 0,
        Category2 = 1,
        Category3 = 2,
        Category4 = 3,
        Category5 = 4,
    }
}
