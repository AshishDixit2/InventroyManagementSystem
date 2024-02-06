using InventoryManagement.Filters;
using InventoryManagement.Middlewares;
using InventoryManagement.Context;
using InventoryManagement.Domain;
using InventoryManagement.Implementations;
using InventoryManagement.Interfaces;
using InventoryManagement.Reposits;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InventoryDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();

//registering filters
builder.Services.AddMvc(options =>
{
    options.Filters.Add<InventoryCheckFilter>();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//registering dependencies
builder.Services.AddScoped<IProductCategory, CategoryService>();
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<ICustomer, CustomerService>();
builder.Services.AddScoped<IOrder, OrderService>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
builder.Services.AddScoped<IRepository<Customer>, Repository<Customer>>();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>>();
builder.Services.AddScoped<IRepository<ProductCategory>, Repository<ProductCategory>>();
builder.Services.AddScoped<IRepository<OrderProduct>, Repository<OrderProduct>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//applying migrations
void ApplyMigration()
{
    using (var scope = app?.Services.CreateScope())
    {
        var _db = scope?.ServiceProvider.GetRequiredService<InventoryDbContext>();

        if (_db?.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}

ApplyMigration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEntityNotFoundMiddleware(); //custom middleware to display error

app.MapControllers();

app.Run();


































/*using Microsoft.EntityFrameworkCore;
using InventoryManagement;
using InventoryManagement.Domain;
using InventoryManagement.Interfaces;
using InventoryManagement.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepository<ProductCategory>, Repository<ProductCategory>>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();
// Add services to the container.
builder.Services.AddDbContext<InventoryDbContext>(option =>
{
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


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
app.UseMiddleware();
app.MapControllers();

app.Run();
*/