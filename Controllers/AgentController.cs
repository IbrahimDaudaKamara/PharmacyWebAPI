using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Data;
using PharmacyAPI.Models;

namespace PharmacyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly PharmacyDbContext _context;

        public AgentController(PharmacyDbContext context)
        {
            _context = context;
        }

        [HttpGet("getallAgent")]
        public async Task<ActionResult<IEnumerable<Agent>>> Get()
        {
            return await _context.Agents.ToListAsync();
        }

        [HttpGet("getAgent/{id}")]
        public async Task<ActionResult<Agent>> Get(int id)
        {
            var item = await _context.Agents.FindAsync(id);
            if (item == null) return NotFound();
            return item;
        }

        [HttpPost("addAgent")]
        public async Task<ActionResult<Agent>> Post(Agent item)
        {
            _context.Agents.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.ID }, item);
        }

        [HttpPut("updateAgent/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Agent updatedAgent)
        {
            var existingAgent = await _context.Agents.FindAsync(id);
            if (existingAgent == null)
                return NotFound();

            // Update fields
            existingAgent.Name = updatedAgent.Name;
            existingAgent.Age = updatedAgent.Age;
            existingAgent.PhoneNumber = updatedAgent.Gender;
            existingAgent.Address = updatedAgent.PhoneNumber;
            existingAgent.Gender = updatedAgent.Gender;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("deleteAgent/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Agents.FindAsync(id);
            if (item == null) return NotFound();
            _context.Agents.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
