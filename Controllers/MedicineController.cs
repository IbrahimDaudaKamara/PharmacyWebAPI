using Microsoft.AspNetCore.Mvc;
using PharmacyAPI.Data;
using PharmacyAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace PharmacyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly PharmacyDbContext _context;

        public MedicineController(PharmacyDbContext context)
        {
            _context = context;
        }

        [HttpGet("getallMedicine")]
        public async Task<ActionResult<IEnumerable<Medicine>>> Get()
        {
            return await _context.Medicines.ToListAsync();
        }

        [HttpGet("getMedicine/{id}")]
        public async Task<ActionResult<Medicine>> Get(int id)
        {
            var item = await _context.Medicines.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost("addMedicine")]
        public async Task<ActionResult<Medicine>> Post(Medicine item)
        {
            _context.Medicines.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.id }, item);
        }


        [HttpPut("UpdateMedicine/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Medicine updatedMedicine)
        {
            var existingMedicine = await _context.Medicines.FindAsync(id);
            if (existingMedicine == null) return NotFound();

            // Update properties manually or use AutoMapper
            existingMedicine.MedName = updatedMedicine.MedName;
            existingMedicine.Price = updatedMedicine.Price;
            existingMedicine.Quantity = updatedMedicine.Quantity;

            await _context.SaveChangesAsync();
            return NoContent();
        }



        [HttpDelete("deleteMedicine/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Medicines.FindAsync(id);
            if (item == null) return NotFound();
            _context.Medicines.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
