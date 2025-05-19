using PharmacyAPI.DTOs;
using PharmacyAPI.Models;

namespace PharmacyWebAPI.Services.Interfaces
{
    public interface IAgentService
    {
        Task<IEnumerable<AgentDTO>> GetAllAsync();
    }
}
