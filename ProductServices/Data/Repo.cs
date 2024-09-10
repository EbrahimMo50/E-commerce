using ProductServices.Models;
using ProductServices.ViewModels;

namespace ProductServices.Data
{
    public class Repo : IRepo
    {
        private readonly AppDbContext _context;
        public Repo(AppDbContext context) 
        { 
            _context = context;
        }
        public void AddProduct(ProductVm product)
        {
            var Product = product.ToProduct();
            _context.Products.Add(Product);
            _context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList() ?? new List<Product>();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
