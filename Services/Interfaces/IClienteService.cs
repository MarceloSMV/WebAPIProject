using WebAPIProject.DTOs.Cliente;

namespace WebAPIProject.Services.Interfaces;
public interface IClienteService
{
    Task<IEnumerable<ClienteDTO>> GetAllAsync();
    Task<ClienteDTO?> GetByIdAsync(int id);
    Task<ClienteWithFacturasDTO?> GetByIdWithFacturasAsync(int id);
    Task<ClienteDTO> AddAsync(ClienteCreateUpdateDTO dto);
    Task<bool> UpdateAsync(int id, ClienteCreateUpdateDTO dto);
    Task<bool> DeleteAsync(int id);    
}



