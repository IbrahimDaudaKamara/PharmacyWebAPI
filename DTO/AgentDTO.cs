using System.ComponentModel.DataAnnotations;

namespace PharmacyAPI.DTOs
{
    public class AgentDTO
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required, StringLength(50)]
        public string Address { get; set; }
    }
}
