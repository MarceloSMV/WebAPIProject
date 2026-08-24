using WebAPIProject.Models;

namespace WebAPIProject.Repositories.Interfaces;
public interface IFacturaRepository : IGenericRepository<Factura>
{
    Task<Factura> GetByIdWithVentasAsync(int id);
}