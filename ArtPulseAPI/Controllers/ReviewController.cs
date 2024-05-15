using ArtPulseAPI.Data;
using Microsoft.AspNetCore.Mvc;
using ArtPulseAPI.Models;
using ArtPulseAPI.DTO;
namespace ArtPulseAPI.Controllers
{
    public class ReviewController : Controller
    {
        readonly DataContext _dataContext;

        public ReviewController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //get review with id
        [HttpGet("getReview/{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            try
            {
                Review review = await _dataContext.Reviews.FindAsync(id);

                if (review == null)
                {
                    return NotFound("Review not found.");
                }

                return Ok(ReviewToReviewDTO(review));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        //get reviews of product
        [HttpGet("getReviewsOfProduct/{productId}")]
        public async Task<IActionResult> GetReviewsOfProduct(int productId)
        {
            try
            {
                ReviewDTO[] reviews = _dataContext.Reviews.Where(r=> r.ReviewedProductId == productId).Select(r => ReviewToReviewDTO(r)).ToArray();

                if (reviews == null || reviews.Length == 0)
                {
                    return NotFound("Review not found.");
                }

                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        //get reviews of customer
        [HttpGet("getReviewsOfCustomer/{customerId}")]
        public async Task<IActionResult> GetReviewsOfCustomer(int customerId)
        {
            try
            {
                ReviewDTO[] reviews = _dataContext.Reviews.Where(r => r.ReviewingCustomerId == customerId).Select(r => ReviewToReviewDTO(r)).ToArray();

                if (reviews == null || reviews.Length == 0)
                {
                    return NotFound("Review not found.");
                }

                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        //post review
        [HttpPost("addReview")]
        public async Task<IActionResult> AddReview(ReviewDTO reviewDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Product? reviewedProduct = await _dataContext.Products.FindAsync(reviewDTO.ReviewedProductId);
            Customer? reviewingCustomer = await _dataContext.Customers.FindAsync(reviewDTO.ReviewingCustomerId);
            if (reviewedProduct == null || reviewingCustomer == null)
            {
                return BadRequest("Invalid product id or customer id");
            }
            Review newReview = new Review()
            {
                Content = reviewDTO.Content,
                Header = reviewDTO.Header,
                Date = DateTime.UtcNow,
                Rating = reviewDTO.Rating,
                ReviewingCustomerId = reviewingCustomer.Id,
                ReviewedProductId = reviewDTO.ReviewedProductId,
            };

            _dataContext.Reviews.Add(newReview);
            await _dataContext.SaveChangesAsync();

            return Ok("Review added successfully.");
            try
            {
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        //update review
        [HttpPut("updateReview/{id}")]
        public async Task<IActionResult> UpdateReview(int id, ReviewDTO reviewDTO)
        {
            try
            {
                if (id != reviewDTO.Id)
                {
                    return BadRequest("Review ID mismatch.");
                }

                Review? review = await _dataContext.Reviews.FindAsync(id);

                if (review == null)
                {
                    return NotFound("Review not found.");
                }

                Product? reviewedProduct = await _dataContext.Products.FindAsync(reviewDTO.ReviewedProductId);
                Customer? reviewingCustomer = await _dataContext.Customers.FindAsync(reviewDTO.ReviewingCustomerId);
                if (reviewedProduct == null || reviewingCustomer == null)
                {
                    return BadRequest("Invalid product id or customer id");
                }
                review.ReviewedProductId = reviewDTO.ReviewedProductId;
                review.ReviewingCustomerId = reviewDTO.ReviewingCustomerId;
                review.Id = reviewDTO.Id;
                review.Header = reviewDTO.Header;
                review.Content = reviewDTO.Content;
                review.Date = reviewDTO.Date;
                review.Rating = reviewDTO.Rating;

                await _dataContext.SaveChangesAsync();

                return Ok("Review updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //delete review
        [HttpDelete("deleteReview/{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                Review? review = await _dataContext.Reviews.FindAsync(id);

                if (review == null)
                {
                    return NotFound("Review not found.");
                }

                _dataContext.Reviews.Remove(review);
                await _dataContext.SaveChangesAsync();

                return Ok("Review deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        ReviewDTO ReviewToReviewDTO(Review review)
        {
            return new ReviewDTO
            {
                Rating = review.Rating,
                Content = review.Content,
                Date = DateTime.Now,
                Header = review.Header,
                Id = review.Id,
                ReviewedProductId = review.ReviewedProductId,
                ReviewingCustomerId = review.ReviewingCustomerId,
            };
        }
    }
}
