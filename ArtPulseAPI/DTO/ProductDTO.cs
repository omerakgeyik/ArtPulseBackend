using ArtPulseAPI.Models;
using ArtPulseAPI.Utilities;
using System.ComponentModel.DataAnnotations;

namespace ArtPulseAPI.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        [Range(0, 5)]
        public float Rating { get; set; }
        public string Category { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int SellerId { get; set; }
        public IFormFile Image { get; set; }
        [SwaggerIgnore]
        public string? ImageBase64 { get; set; }
    }
}
