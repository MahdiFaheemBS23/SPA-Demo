using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class Person : BaseEntity
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
