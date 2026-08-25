using WebAPIProject.DTOs.Factura;

namespace WebAPIProject.Services.Interfaces;
public interface IFacturaService
{
    Task<IEnumerable<FacturaDTO>> GetAllAsync();
    Task<FacturaDTO?> GetByIdAsync(int id);
    Task<FacturaWithVentasDTO?> GetByIdWithVentasAsync(int id);
    Task<FacturaWithDetailsDTO?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<FacturaWithDetailsDTO>> GetAllWithDetailsAsync();
    Task<FacturaDTO> AddAsync(FacturaCreateUpdateDTO dto);
    Task<bool> UpdateAsync(int id, FacturaCreateUpdateDTO dto);
    Task<bool> DeleteAsync(int id);    
}