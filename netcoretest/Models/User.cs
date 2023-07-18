using System.ComponentModel.DataAnnotations;

namespace netcoretest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool isActive { get; set; } = true;
    }
}
