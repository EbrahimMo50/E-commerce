using System.ComponentModel.DataAnnotations;

namespace ProductServices.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public int Count { get; set; }
        public string Category { get; set; } = null!;
    }
}