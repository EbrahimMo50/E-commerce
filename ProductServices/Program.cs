using Microsoft.EntityFrameworkCore;
using ProductServices.Data;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagge/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//the context will change when depolying the app to configure the new connection string

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
builder.Services.AddDbContext<AppDbContext>(opt =>opt.UseSqlServer(config.GetConnectionString("ProductConnection")));

builder.Services.AddScoped<IRepo, Repo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.MapControllers();

InitDb.PrepPopulation(app, app.Environment.IsProduction());

app.Run();