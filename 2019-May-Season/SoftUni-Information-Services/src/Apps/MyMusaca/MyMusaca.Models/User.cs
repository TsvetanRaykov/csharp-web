using System.ComponentModel.DataAnnotations;

namespace MyMusaca.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        [Required, StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required, StringLength(20, MinimumLength = 5)]
        public string Email { get; set; }
    }
}
