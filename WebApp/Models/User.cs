using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        
        public string? PhysicalAddress { get; set; }
    }
}
