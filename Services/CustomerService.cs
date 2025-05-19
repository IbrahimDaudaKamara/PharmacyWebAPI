using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.DTOs;
using PharmacyAPI.Models;
using PharmacyWebAPI.Services.Interfaces;

namespace PharmacyWebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly PharmacyDbContext _context;

        public CustomerService(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsync()
        {
            return await _context.Customers
                .Select(c => new CustomerDTO
                {
                    FullName = c.FirstName + " " + c.LastName,
                    PhoneNumber = c.PhoneNumber,
                    Age = c.Age
                }).ToListAsync();
        }

        public async Task<CustomerDTO> CreateAsync(CustomerDTO dto)
        {
            var names = dto.FullName.Split(' ');
            var customer = new Customer
            {
                FirstName = names.First(),
                LastName = names.Length > 1 ? names.Last() : "",
                PhoneNumber = dto.PhoneNumber,
                Age = dto.Age,
                Gender = "Unknown",
                Date = DateTime.Now
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}