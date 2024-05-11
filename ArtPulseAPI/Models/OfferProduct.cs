using Microsoft.EntityFrameworkCore;

namespace ArtPulseAPI.Models
{
    [PrimaryKey(nameof(OfferId), nameof(ProductId))]
    public class OfferProduct
    {
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
