using Microsoft.EntityFrameworkCore;
using WebAPIProject.Data;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;

namespace WebAPIProject.Repositories.Implements;

public class FacturaRepository : GenericRepository<Factura>, IFacturaRepository
{
    public FacturaRepository(VentasDbContext context) : base(context)
    {
    }

    public async Task<Factura?> GetByIdWithVentasAsync(int id)
    {
        return await _dbSet
            .Include(t => t.Ventas)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}