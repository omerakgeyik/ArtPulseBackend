using ArtPulseAPI.Data;
using ArtPulseAPI.DTO;
using ArtPulseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtPulseAPI.Controllers
{
    public class CustomerController : ControllerBase
    {
        readonly DataContext _dataContext;

        public CustomerController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("addCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerDTO customerDTO)
        {
            try
            {
                var customer = new Customer
                {
                    FirstName = customerDTO.FirstName,
                    LastName = customerDTO.LastName,
                    Email = customerDTO.Email,
                    PhoneNumber = customerDTO.PhoneNumber,
                    Address = customerDTO.Address,
                };

                _dataContext.Customers.Add(customer);
                await _dataContext.SaveChangesAsync();

                return Ok("Customer added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        //Get all customers
        [HttpGet("getAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customers = await _dataContext.Customers.ToListAsync();

                if (customers.Count == 0)
                {
                    return NotFound("No customers found.");
                }

                var customerDTOs = customers.Select(c => CustomerToCustomerDTO(c)).ToList();

                return Ok(customerDTOs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Get a customer by id
        [HttpGet("getCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _dataContext.Customers.FindAsync(id);

                if (customer == null)
                {
                    return NotFound("Customer not found.");
                }

                var customerDTO = CustomerToCustomerDTO(customer);

                return Ok(customerDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Update Customer
        [HttpPut("updateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            try
            {
                if (id != customerDTO.Id)
                {
                    return BadRequest("Customer ID mismatch.");
                }

                var customer = await _dataContext.Customers.FindAsync(id);

                if (customer == null)
                {
                    return NotFound("Customer not found.");
                }

                customer.FirstName = customerDTO.FirstName;
                customer.LastName = customerDTO.LastName;
                customer.Email = customerDTO.Email;
                customer.PhoneNumber = customerDTO.PhoneNumber;
                customer.Address = customerDTO.Address;

                await _dataContext.SaveChangesAsync();

                return Ok("Customer updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        //Deleting Customer
        [HttpDelete("deleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer = await _dataContext.Customers.FindAsync(id);

                if (customer == null)
                {
                    return NotFound("Customer not found.");
                }

                _dataContext.Customers.Remove(customer);
                await _dataContext.SaveChangesAsync();

                return Ok("Customer deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        private CustomerDTO CustomerToCustomerDTO(Customer customer)
        {
            return new CustomerDTO
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address
            };
        }
        //Get customer by id
        //get customer by email
        //get customer by phone number
        //set customer
        //ad customer
    }
}
