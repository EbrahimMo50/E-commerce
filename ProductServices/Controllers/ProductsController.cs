using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductServices.Data;
using ProductServices.ViewModels;

namespace ProductServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepo _repo;

        public ProductsController(IRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_repo.GetAllProducts());
        }

        [HttpGet("GetbyId{id}")]
        public IActionResult GetProduct(int id) 
        {
           var product = _repo.GetProductById(id);
            if(product != null) 
                return Ok(product);
            else
                return BadRequest();
        }
        [HttpPost("AddProduct")]
        public IActionResult AddProduct(ProductVm product)
        {
            _repo.AddProduct(product);
            return Ok();
        }
    }
}
