using UserService.Models;

namespace UserService.ViewModels
{
    public class UserVm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }

        public User ToUser()
        {
            return new User() { Name = this.Name, Email = this.Email, Password = this.Password , Roles = this.Roles};
        }
    }
}
