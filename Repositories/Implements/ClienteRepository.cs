using Microsoft.EntityFrameworkCore;
using WebAPIProject.Data;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;

namespace WebAPIProject.Repositories.Implements;

public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
{
    public ClienteRepository(VentasDbContext context) : base(context)
    {
    }

    public async Task<Cliente?> GetByIdWithFacturasAsync(int id)
    {
        return await _dbSet
            .Include(t => t.Facturas)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}