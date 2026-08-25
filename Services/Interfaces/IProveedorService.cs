using WebAPIProject.DTOs.Proveedor;

namespace WebAPIProject.Services.Interfaces;
public interface IProveedorService
{
    Task<IEnumerable<ProveedorDTO>> GetAllAsync();
    Task<ProveedorDTO?> GetByIdAsync(int id);
    Task<ProveedorWithProductosDTO?> GetByIdWithProductosAsync(int id);
    Task<ProveedorDTO> AddAsync(ProveedorCreateUpdateDTO dto);
    Task<bool> UpdateAsync(int id, ProveedorCreateUpdateDTO dto);
    Task<bool> DeleteAsync(int id);
}