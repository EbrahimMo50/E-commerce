using Microsoft.EntityFrameworkCore;

namespace UserService.Data
{
    public static class InitDb
    {
        public static void Init()
        {
            var context = new UserDbContext();
            
            context.Database.Migrate();

            if (!context.Users.Any())
            {
                Console.WriteLine("seeding database");
                context.Users.Add(new Models.User() { Email = "Ebrahim@gmail.com", Name = "Ebrahim", Password = "1234", Roles = new List<string>() { "user" } });
                context.SaveChanges();
            }

        }
    }
}