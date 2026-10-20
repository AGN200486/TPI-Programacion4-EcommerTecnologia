using Application.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Web.Middlewares; // Namespace del middleware global de excepciones

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Cadena de conexion a SQLite
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                        ?? "Data Source=products.db";

// Registro del DbContext (Infrastructure)
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite(connectionString));

// Registro del Repositorio (Inyeccion de dependencias)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Repositorio genérico 
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Registro de Servicios (Application)
builder.Services.AddScoped<CategoryService>();

// Registro del middleware para el manejo de excepciones
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

var app = builder.Build();

// Intercepta cualquier error globalmente antes de procesar las peticiones
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();