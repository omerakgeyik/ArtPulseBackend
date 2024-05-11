
using Microsoft.EntityFrameworkCore;

namespace ArtPulseAPI.Models
{
    [PrimaryKey(nameof(CustomerId), nameof(ProductId))]
    public class CustomerProduct_ShoppingCart
    {
        public int CustomerId;
        public Customer Customer;
        public int ProductId;
        public Product Product;
    }
}
