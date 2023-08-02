
using Microsoft.EntityFrameworkCore;
using ShopApp.Persistanse.EF;
using ShopApp.Persistanse.EF.Categories;
using ShopApp.Persistanse.EF.Products;
using ShopApp.Services.Categories;
using ShopApp.Services.Categories.Contracts;
using ShopApp.Services.Contracts;
using ShopApp.Services.Products;
using ShopApp.Services.Products.Contracts;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();

builder.Services.AddScoped<CategoryRepository, EFCategoryRepository>();
builder.Services.AddScoped<CaregoryServices, CategoryAppServices>();

builder.Services.AddScoped<ProductRepository, EFProductRepository>();
builder.Services.AddScoped<ProductServices, ProductAppServices>();


builder.Services.AddDbContext<EFDataContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("SqlServer"));
});


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