using Microsoft.EntityFrameworkCore;
using Plumbing.Ecommerce.Application;
using Plumbing.Ecommerce.DataProvider;
using Plumbing.Ecommerce.DataProvider.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services.AddDbContext<OrderContext>(
    options => options.UseSqlServer(configuration.GetConnectionString("OrderDb"))
    );
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
