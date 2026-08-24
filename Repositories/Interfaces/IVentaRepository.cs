using WebAPIProject.Models;

namespace WebAPIProject.Repositories.Interfaces;
public interface IVentaRepository : IGenericRepository<Venta>
{
    Task<Venta?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<Venta>> GetAllWithDetails();
}