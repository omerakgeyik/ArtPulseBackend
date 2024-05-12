using ArtPulseAPI.Data;
using ArtPulseAPI.DTO;
using ArtPulseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtPulseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly DataContext _context;

        public SellersController(DataContext context)
        {
            _context = context;
        }

        //Adding Seller
        [HttpPost("addSeller")]
        public async Task<IActionResult> AddSeller(SellerDTO sellerDTO)
        {
            try
            {
                var seller = new Seller
                {
                    FirstName = sellerDTO.FirstName,
                    LastName = sellerDTO.LastName,
                    Email = sellerDTO.Email,
                    PhoneNumber = sellerDTO.PhoneNumber,
                    Address = sellerDTO.Address
                };

                _context.Sellers.Add(seller);
                await _context.SaveChangesAsync();

                return Ok("Seller added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Get all seller
        [HttpGet("getAllSellers")]
        public async Task<IActionResult> GetAllSellers()
        {
            try
            {
                var sellers = await _context.Sellers.ToListAsync();

                if (sellers.Count == 0)
                {
                    return NotFound("No sellers found.");
                }

                var sellerDTOs = sellers.Select(s => SellerToDTO(s)).ToList();

                return Ok(sellerDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Get a seller by id
        [HttpGet("getSellerById/{id}")]
        public async Task<IActionResult> GetSellerById(int id)
        {
            try
            {
                var seller = await _context.Sellers.FindAsync(id);

                if (seller == null)
                {
                    return NotFound("Seller not found.");
                }

                var sellerDTO = SellerToDTO(seller);

                return Ok(sellerDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Update Seller
        [HttpPut("updateSeller/{id}")]
        public async Task<IActionResult> UpdateSeller(int id, SellerDTO sellerDTO)
        {
            try
            {
                if (id != sellerDTO.Id)
                {
                    return BadRequest("Seller ID mismatch.");
                }

                var seller = await _context.Sellers.FindAsync(id);

                if (seller == null)
                {
                    return NotFound("Seller not found.");
                }

                seller.FirstName = sellerDTO.FirstName;
                seller.LastName = sellerDTO.LastName;
                seller.Email = sellerDTO.Email;
                seller.PhoneNumber = sellerDTO.PhoneNumber;
                seller.Address = sellerDTO.Address;

                await _context.SaveChangesAsync();

                return Ok("Seller updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Deleting Seller
        [HttpDelete("deleteSeller/{id}")]
        public async Task<IActionResult> DeleteSeller(int id)
        {
            try
            {
                var seller = await _context.Sellers.FindAsync(id);

                if (seller == null)
                {
                    return NotFound("Seller not found.");
                }

                _context.Sellers.Remove(seller);
                await _context.SaveChangesAsync();

                return Ok("Seller deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private SellerDTO SellerToDTO(Seller seller)
        {
            return new SellerDTO
            {
                Id = seller.Id,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                Email = seller.Email,
                PhoneNumber = seller.PhoneNumber,
                Address = seller.Address
            };
        }
    }

}
