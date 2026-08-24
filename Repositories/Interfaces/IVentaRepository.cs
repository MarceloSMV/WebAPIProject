using WebAPIProject.Models;

namespace WebAPIProject.Repositories.Interfaces;
public interface IVentaRepository : IGenericRepository<Venta>
{
    Task<Venta> GetByIdWithFacturasAsync(int id);
}