using Microsoft.EntityFrameworkCore;
using InventoryManagement;
using InventoryManagement.Domain;
using InventoryManagement.Reposits;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRepository<ProductCategory>, Repository<ProductCategory>>();
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
