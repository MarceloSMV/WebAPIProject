using Microsoft.EntityFrameworkCore;
using WebAPIProject.Models;

namespace WebAPIProject.Data;
public class VentasDbContext : DbContext
{
    public VentasDbContext(DbContextOptions<VentasDbContext> options) 
    : base (options) 
    {
    }
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Cliente> Cliente { get; set; }    
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<Producto> Producto { get; set; }
    public DbSet<Proveedor> Proveedor { get; set; }
    public DbSet<Venta> Venta { get; set; }
}