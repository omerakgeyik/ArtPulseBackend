using Microsoft.AspNetCore.Mvc;
using ArtPulseAPI.DTO;
using ArtPulseAPI.Data;
using ArtPulseAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
namespace ArtPulseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        readonly DataContext _dataContext;

        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //Get all Products
        [HttpGet("allProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _dataContext.Products.ToListAsync();

                if (products.Count == 0)
                {
                    return NotFound("No products found.");
                }

                var productDTOs = products.Select(p => ProductToDTO(p)).ToList();

                return Ok(productDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Get product by id
        //[Authorize] for authhorize
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            try
            {
                var product = await _dataContext.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound("Product not found.");
                }

                var productDTO = ProductToDTO(product);

                return Ok(productDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Add product
        [HttpPost("addProduct")]
        public async Task<IActionResult> AddProduct([FromForm] ProductDTO productDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var seller = await _dataContext.Sellers.FindAsync(productDTO.SellerId);

                if (seller == null)
                {
                    return BadRequest("Seller not found.");
                }

                byte[] imageData = null;

                if (productDTO.Image != null && productDTO.Image.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await productDTO.Image.CopyToAsync(ms);
                        imageData = ms.ToArray();
                    }
                }

                var product = new Product
                {
                    Amount = productDTO.Amount,
                    Rating = productDTO.Rating,
                    Category = (Category)Enum.Parse(typeof(Category), productDTO.Category),
                    Cost = productDTO.Cost,
                    Name = productDTO.Name,
                    Details = productDTO.Details,
                    Seller = seller,
                    Image = imageData
                };

                _dataContext.Products.Add(product);
                await _dataContext.SaveChangesAsync();

                return Ok("Product added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Update product
        [HttpPut("updateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductDTO productDTO)
        {
            try
            {
                if (id != productDTO.Id)
                {
                    return BadRequest("Product ID mismatch.");
                }

                var product = await _dataContext.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound("Product not found.");
                }

                var seller = await _dataContext.Sellers.FindAsync(productDTO.SellerId);

                if (seller == null)
                {
                    return BadRequest("Seller not found.");
                }

                byte[] imageData = product.Image;

                if (productDTO.Image != null && productDTO.Image.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await productDTO.Image.CopyToAsync(ms);
                        imageData = ms.ToArray();
                    }
                }

                product.Amount = productDTO.Amount;
                product.Rating = productDTO.Rating;
                product.Category = (Category)Enum.Parse(typeof(Category), productDTO.Category);
                product.Cost = productDTO.Cost;
                product.Name = productDTO.Name;
                product.Details = productDTO.Details;
                product.Seller = seller;
                product.Image = imageData; 

                await _dataContext.SaveChangesAsync();

                return Ok("Product updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Delete product
        [HttpDelete("deleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _dataContext.Products.FindAsync(id);

                if (product == null)
                {
                    return NotFound("Product not found.");
                }

                _dataContext.Products.Remove(product);
                await _dataContext.SaveChangesAsync();

                return Ok("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Get Products by Ascending order
        [HttpGet("productsPriceAsc/{start}/{count}")]
        public async Task<IActionResult> GetProductsPriceAsc(int start, int count)
        {
            try
            {
                Range range = new Range(start, count);
                var products = await _dataContext.Products
                    .OrderBy(p => p.Cost)
                    .Skip(start)
                    .Take(count)
                    .ToListAsync();

                if (products.Count == 0)
                {
                    return NotFound("No products found.");
                }

                var productDTOs = products.Select(p => ProductToDTO(p)).ToList();

                return Ok(productDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Get Products by Descanding order
        [HttpGet("productsPriceDesc/{start}/{count}")]
        public async Task<IActionResult> GetProductsPriceDesc(int start, int count)
        {
            try
            {
                Range range = new Range(start, count);
                var products = await _dataContext.Products
                    .OrderByDescending(p => p.Cost)
                    .Skip(start)
                    .Take(count)
                    .ToListAsync();

                if (products.Count == 0)
                {
                    return NotFound("No products found.");
                }

                var productDTOs = products.Select(p => ProductToDTO(p)).ToList();

                return Ok(productDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Get top 10 products
        [HttpGet("bestProducts/{start}/{count}")]
        public async Task<IActionResult> GetBestProducts(int start, int count)
        {
            try
            {
                Range range = new Range(start, count);
                var bestProducts = await _dataContext.Products
                    .OrderByDescending(p => p.Rating)
                    .Skip(start)
                    .Take(count)
                    .Select(p => ProductToDTO(p))
                    .ToListAsync();

                if (bestProducts.Count == 0)
                {
                    return NotFound("No products found.");
                }

                return Ok(bestProducts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private ProductDTO ProductToDTO(Product product)
        {
            var productDTO = new ProductDTO
            {
                Id = product.Id,
                Amount = product.Amount,
                Rating = product.Rating / 10.0f,
                Category = Enum.GetName(typeof(Category), product.Category),
                Cost = product.Cost,
                Name = product.Name,
                Details = product.Details,
                SellerId = product.SellerId,
                ImageBase64 = product.Image != null ? Convert.ToBase64String(product.Image) : null
            };
            return productDTO;
        }
    }
}
