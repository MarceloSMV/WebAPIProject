using Microsoft.EntityFrameworkCore;
using WebAPIProject.Data;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;

namespace WebAPIProject.Repositories.Implements;

public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
{
    public ProductoRepository(VentasDbContext context) : base(context)
    {
    }

    public async Task<Producto?> GetByIdWithVentasAsync(int id)
    {
        return await _dbSet
            .Include(t => t.Categoria)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}