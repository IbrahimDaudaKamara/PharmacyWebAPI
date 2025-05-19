using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyAPI.DTOs
{
    public class CustomerDTO
    {
        [Required, StringLength(50)]
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}
