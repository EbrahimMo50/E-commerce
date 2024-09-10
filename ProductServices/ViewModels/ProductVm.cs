using ProductServices.Models;

namespace ProductServices.ViewModels
{
    public class ProductVm
    {
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public int Count { get; set; }
        public string Category { get; set; } = null!;

        public Product ToProduct()
        {
            return new Product { Name = this.Name, Price = this.Price, Category = this.Category, Count = this.Count };
        }
    }
}
