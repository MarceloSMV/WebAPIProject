using Microsoft.EntityFrameworkCore;
using WebAPIProject.Data;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;

namespace WebAPIProject.Repositories.Implements;

public class VentaRepository : GenericRepository<Venta>, IVentaRepository
{
    public VentaRepository(VentasDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Venta>> GetAllWithDetailsAsync()
    {
        return await _dbSet
            .Include(t => t.Factura)
            .Include(t => t.Producto)
            .ToListAsync();
    }

    public async Task<Venta?> GetByIdWithDetailsAsync(int id)
    {
        return await _dbSet
            .Include(t => t.Factura)
            .Include(t => t.Producto)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}