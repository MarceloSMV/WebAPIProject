using WebAPIProject.DTOs.Producto;

namespace WebAPIProject.Services.Interfaces;
public interface IProductoService
{
    Task<IEnumerable<ProductoDTO>> GetAllAsync();
    Task<ProductoDTO?> GetByIdAsync(int id);
    Task<ProductoWithVentasDTO?> GetByIdWithVentasAsync(int id);
    Task<ProductoWithDetailsDTO?> GetByIdWithDetailsAsync(int id);
    Task<IEnumerable<ProductoWithDetailsDTO>> GetAllWithDetailsAsync();
    Task<ProductoDTO> AddAsync(ProductoCreateUpdateDTO dto);
    Task<bool> UpdateAsync(int id, ProductoCreateUpdateDTO dto);
    Task<bool> DeleteAsync(int id);
}