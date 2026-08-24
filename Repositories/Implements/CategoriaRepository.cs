using Microsoft.EntityFrameworkCore;
using WebAPIProject.Data;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;

namespace WebAPIProject.Repositories.Implements;

public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(VentasDbContext context) : base(context)
    {
    }

    public async Task<Categoria?> GetByIdWithProductosAsync(int id)
    {
        return await _dbSet
            .Include(t => t.Productos)
            .FirstOrDefaultAsync(t => t.Id == id);   
    }
}