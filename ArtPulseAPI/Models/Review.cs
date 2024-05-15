using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtPulseAPI.Models
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        [Range(0,5)]
        public int Rating { get; set; }
        public int ReviewingCustomerId { get; set; }
        public Customer ReviewingCustomer { get; set; }
        public int ReviewedProductId { get; set; }
        public Product ReviewedProduct { get; set; }
    }
}
