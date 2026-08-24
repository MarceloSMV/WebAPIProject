using WebAPIProject.Models;

namespace WebAPIProject.Repositories.Interfaces;
public interface IProductoRepository : IGenericRepository<Producto>
{
    Task<Producto?> GetByIdWithVentasAsync(int id);
}