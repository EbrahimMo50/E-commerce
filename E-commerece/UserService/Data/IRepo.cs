using UserService.Models;
using UserService.ViewModels;

namespace UserService.Data
{
    public interface IRepo
    {
        User? GetUserById(int id);
        List<User> GetUsers();
        void AddUser(UserVm uservm);
        string SignIn(string email, string pass, AuthService authService);
    }
}
