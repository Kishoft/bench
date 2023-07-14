using System.ComponentModel.DataAnnotations;

namespace netcoretest.Models
{
    public class UserDTO
    {
        [Required]
        public string firstName { get; set; } = null!;

        [Required]
        public string lastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

    }
}
