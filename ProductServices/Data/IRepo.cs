using ProductServices.ViewModels;
using ProductServices.Models;

namespace ProductServices.Data
{
    public interface IRepo
    {
        List<Product> GetAllProducts();
        Product? GetProductById(int id);
        void AddProduct(ProductVm product);
    }
}
