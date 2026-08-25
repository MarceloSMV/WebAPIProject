using WebAPIProject.DTOs.Categoria;

namespace WebAPIProject.Services.Interfaces;
public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDTO>> GetAllAsync();
    Task<CategoriaDTO?> GetByIdAsync(int id);
    Task<CategoriaWithProductosDTO?> GetByIdWithProductosAsync(int id);
    Task<CategoriaDTO> AddAsync(CategoriaCreateUpdateDTO dto);
    Task<bool> UpdateAsync(int id, CategoriaCreateUpdateDTO dto);
    Task<bool> DeleteAsync(int id);
}