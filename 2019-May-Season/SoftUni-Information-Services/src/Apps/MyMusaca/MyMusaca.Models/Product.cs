using System.ComponentModel.DataAnnotations;

namespace MyMusaca.Models
{
    public class Product
    {
        [Key]
        public string Id { get; set; }

        [Required, StringLength(10, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(typeof(decimal),"0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
    }
}