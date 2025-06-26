using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.Models;

namespace PharmacyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly PharmacyDbContext _context;

        public CustomerController(PharmacyDbContext context)
        {
            _context = context;
        }

        [HttpGet("getallCustomer")]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("getCustomer/{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var item = await _context.Customers.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost("addCustomer")]
        public async Task<ActionResult<Customer>> Post(Customer item)
        {
            _context.Customers.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.ID }, item);
        }

        [HttpPut("updateCustomer/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Customer updatedCustomer)
        {
            var existingCustomer = await _context.Customers.FindAsync(id);
            if (existingCustomer == null)
                return NotFound();

            // Update fields
            existingCustomer.FirstName = updatedCustomer.FirstName;
            existingCustomer.LastName = updatedCustomer.LastName;
            existingCustomer.Gender = updatedCustomer.Gender;
            existingCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            existingCustomer.Age = updatedCustomer.Age;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("deleteCustomer/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Customers.FindAsync(id);
            if (item == null) return NotFound();
            _context.Customers.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
