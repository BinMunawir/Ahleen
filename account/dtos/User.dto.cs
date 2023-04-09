
using System.ComponentModel.DataAnnotations;

namespace Account.DTOs
{
    public record UserDTO
    {

        public string Guid { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}