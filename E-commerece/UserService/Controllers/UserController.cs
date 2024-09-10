using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.ViewModels;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IRepo repo) : ControllerBase
    {
        private readonly IRepo _repo = repo;

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_repo.GetUsers());
        }

        [HttpGet("GetUserById{id}")]
        public IActionResult GetUserById(int id) 
        {
            var user = _repo.GetUserById(id);
            if(user != null) 
                return Ok(user);
            return BadRequest();
        }

        [HttpPut("AddUser")]
        public IActionResult AddUser(UserVm user)
        {
            _repo.AddUser(user);
            return Ok();
        }
        [HttpGet("SignIn")]
        public IActionResult SignIn(string Email,string Pass, AuthService authService)
        {
            return Ok(_repo.SignIn(Email, Pass, authService));
        }
    }
}
