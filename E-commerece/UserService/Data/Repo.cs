using UserService.Models;
using UserService.ViewModels;

namespace UserService.Data
{
    public class Repo : IRepo
    {
        private readonly UserDbContext _dbContext;

        public Repo()
        {
            _dbContext = new UserDbContext();
        }
        public void AddUser(UserVm uservm)
        {
            var User = uservm.ToUser();
            _dbContext.Users.Add(User);
            _dbContext.SaveChanges();
        }

        public User? GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList() ?? [];
        }

        public string SignIn(string email, string pass, AuthService authService)
        {
            var Person = _dbContext.Users.FirstOrDefault(p => p.Email == email);

            if (Person == null)
                return "Email not found";
            if (Person.Password == pass)
                return authService.GenerateToken(Person);
            else
                return "invalid cerdintals";
        }
    }
}
