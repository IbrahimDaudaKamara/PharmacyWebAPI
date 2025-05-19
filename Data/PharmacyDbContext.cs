using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Models;

namespace PharmacyAPI.Data
{
    public class PharmacyDbContext : DbContext
    {
        public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
            : base(options)
        {
        }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
