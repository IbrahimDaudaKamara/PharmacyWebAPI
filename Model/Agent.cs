using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyAPI.Models
{
    public class Agent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Age { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(10)]
        public string Password { get; set; }
    }
}