using Microsoft.EntityFrameworkCore;

namespace OrderService.Data
{
    public static class InitDb
    {
        public static void init()
        {
            var context = new OrderDbContext();
            context.Database.Migrate();
            //no data seeding for now
        }
    }
}
