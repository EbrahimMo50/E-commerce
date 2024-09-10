using Microsoft.EntityFrameworkCore;

namespace ProductServices.Data
{
    public static class InitDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if (isProd)
            {
                try
                {   
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Could not run migrations: {ex.Message}");
                }
            }
            if (!context.Products.Any())
            {
                
                context.Products.Add(new Models.Product() { Name = "meat can", Category = "canned", Count = 10 , Price = 15});
                context.SaveChanges();
            }
        }
    }
}
