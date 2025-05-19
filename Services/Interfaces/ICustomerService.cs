using PharmacyAPI.DTOs;
using PharmacyAPI.Models;

namespace PharmacyWebAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
        Task<CustomerDTO> CreateAsync(CustomerDTO dto);
    }
}
