using WebAPIProject.DTOs.Venta;

namespace WebAPIProject.Services.Interfaces;
public interface IVentaService
{
    Task<IEnumerable<VentaDTO>> GetAllAsync();
    Task<VentaDTO?> GetByIdAsync(int id);
    Task<VentaWithDetailsDTO?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<VentaWithDetailsDTO>> GetAllWithDetailsAsync();
    Task<VentaDTO> AddAsync(VentaCreateUpdateDTO dto);
    Task<bool> UpdateAsync(int id, VentaCreateUpdateDTO dto);
    Task<bool> DeleteAsync(int id);
}