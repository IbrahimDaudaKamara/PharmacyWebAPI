using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.DTOs;
using PharmacyAPI.Models;
using PharmacyWebAPI.Services.Interfaces;

namespace PharmacyWebAPI.Services
{
    public class AgentService : IAgentService
    {
        private readonly PharmacyDbContext _context;

        public AgentService(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AgentDTO>> GetAllAsync()
        {
            return await _context.Agents
                .Select(a => new AgentDTO
                {
                    Name = a.Name,
                    PhoneNumber = a.PhoneNumber,
                    Address = a.Address
                }).ToListAsync();
        }
    }
}
    