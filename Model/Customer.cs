using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyAPI.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public DateTime Date { get; set; }

        public int Age { get; set; }
    }
}
