using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyAPI.Models
{
    public class MedicineDTO
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string MedName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}