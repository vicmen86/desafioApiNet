using ApiNet;
using ApiNet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<ProductsContext>("Data Source=LAPTOP-PHJ7JT87;Initial Catalog=TestDB;user id=sa;password=12345678;TrustServerCertificate=True");
builder.Services.AddScoped<ITipoProductoService, TipoProductoService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IStockService, StockService>();

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
