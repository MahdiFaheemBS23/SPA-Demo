using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class PersonDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
