using PharmacyAPI.Models;

namespace PharmacyWebAPI.Services.Interfaces
{

    public interface IMedicineService
    {
        Task<IEnumerable<MedicineDTO>> GetAllAsync();
        Task<MedicineDTO> GetByIdAsync(int id);
        Task<MedicineDTO> CreateAsync(MedicineDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}

