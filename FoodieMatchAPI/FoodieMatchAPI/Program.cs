using FoodieMatchAPI.Repository.Implements;
using FoodieMatchAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUsuarioQuery, UsuarioQuery>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IRestauranteQuery, RestauranteQuery>();
builder.Services.AddTransient<IRestauranteRepository, RestauranteRepository>();
builder.Services.AddTransient<IProductoQuery, ProductoQuery>();
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();
builder.Services.AddTransient<ICategoriaQuery, CategoriaQuery>();
builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddTransient<CategoriaQuery>();
builder.Services.AddTransient<CategoriaRepository>();
builder.Services.AddTransient<ProductoQuery>();
builder.Services.AddTransient<ProductoRepository>();
builder.Services.AddTransient<RestauranteQuery>();
builder.Services.AddTransient<RestauranteRepository>();
builder.Services.AddTransient<UsuarioQuery>();
builder.Services.AddTransient<UsuarioRepository>();

builder.Services.AddScoped<IDbConnection>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("sql");
    return new SqlConnection(connectionString);
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
