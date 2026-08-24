using WebAPIProject.Models;

namespace WebAPIProject.Repositories.Interfaces;
public interface IProveedorRepository : IGenericRepository<Proveedor>
{
    Task<Proveedor> GetByIdWithProductosAsync(int id);
}