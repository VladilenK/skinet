using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration["ConnectionString:DefaultConnection"];

// Add services to the container.

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(x =>
{
    x.UseSqlite(connString);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ConfigurationManager configuration = builder.Configuration;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    Console.WriteLine("===================================================");
    Console.WriteLine("Dev Config Used");
    Console.WriteLine("===================================================");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

