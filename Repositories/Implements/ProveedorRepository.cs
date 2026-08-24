using Microsoft.EntityFrameworkCore;
using WebAPIProject.Data;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;

namespace WebAPIProject.Repositories.Implements;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
{
    public ProveedorRepository(VentasDbContext context) : base(context)
    {
    }

    public async Task<Proveedor?> GetByIdWithProductosAsync(int id)
    {
        return await _dbSet
            .Include(t => t.Productos)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}