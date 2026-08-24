using WebAPIProject.Models;

namespace WebAPIProject.Repositories.Interfaces;
public interface IClienteRepository : IGenericRepository<Cliente> 
{
    Task<Cliente?> GetByIdWithFacturasAsync(int id); // Puede devolver un nulo
}