using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Data;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IRepo repo) : ControllerBase
    {
        private readonly IRepo _repo = repo;

        [HttpGet]
        [Authorize(Roles = "user")]
        public IActionResult GetAllOrders()
        {
            return Ok(_repo.GetAllOrders());
        }
        [HttpPut("PlaceOrder")]
        public async Task<IActionResult> PlaceOrder(int userid, int orderid, int ammount)
        {
            if (await _repo.PlaceOrder(userid, orderid, ammount))
                return Ok();
            else
                return BadRequest("could not connect with other services");
        }

    }
}
