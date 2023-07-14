using System.ComponentModel.DataAnnotations;

namespace netcoretest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public bool isActive { get; set; } = true;
    }
}
