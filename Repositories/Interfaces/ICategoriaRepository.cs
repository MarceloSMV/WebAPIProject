using WebAPIProject.Models;

namespace WebAPIProject.Repositories.Interfaces;

public interface ICategoriaRepository : IGenericRepository<Categoria>
{
    Task<Categoria?> GetByIdWithProductosAsync(int id);
    
}