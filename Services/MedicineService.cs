using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.Models;
using PharmacyWebAPI.Services.Interfaces;

namespace PharmacyWebAPI.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly PharmacyDbContext _context;

        public MedicineService(PharmacyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicineDTO>> GetAllAsync()
        {
            return await _context.Medicines
                .Select(m => new MedicineDTO
                {
                    MedName = m.MedName,
                    Price = m.Price,
                    Quantity = m.Quantity
                }).ToListAsync();
        }

        public async Task<MedicineDTO> GetByIdAsync(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null) return null;

            return new MedicineDTO
            {
                MedName = medicine.MedName,
                Price = medicine.Price,
                Quantity = medicine.Quantity
            };
        }

        public async Task<MedicineDTO> CreateAsync(MedicineDTO dto)
        {
            var medicine = new Medicine
            {
                MedName = dto.MedName,
                Price = dto.Price,
                Quantity = dto.Quantity,
                MFGDate = DateTime.UtcNow,
                EXPDate = DateTime.UtcNow.AddYears(1)
            };
            _context.Medicines.Add(medicine);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null) return false;

            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}