using Microsoft.EntityFrameworkCore;
using WebAPIProject.Data;
using WebAPIProject.Mappings;
using WebAPIProject.Repositories.Implements;
using WebAPIProject.Repositories.Interfaces;
using WebAPIProject.Services.Implements;
using WebAPIProject.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<VentasDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
 
// Registro de AuoMapper
builder.Services.AddAutoMapper(config => 
{
    config.AddProfile<MappingProfile>();
});

// Registro de Repositorios
// Registra los Repositories que tienen solamente CRUD - ej. builder.Services.AddScoped<IGenericRepository<Venta>, IGenericRepository<Venta>>;
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
// Registra los Repos - con los metodos especiales
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedorRepository>();
builder.Services.AddScoped<IVentaRepository, VentaRepository>();

// Registro de Services
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<IVentaService, VentaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
