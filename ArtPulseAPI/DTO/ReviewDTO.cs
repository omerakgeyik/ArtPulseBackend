using ArtPulseAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ArtPulseAPI.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int ReviewingCustomerId { get; set; }
        public int ReviewedProductId { get; set; }
    }
}
