using AutoMapper;
using Microsoft.AspNetCore.Routing.Template;
using WebAPIProject.DTOs.Cliente;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Services.Implements;
public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;

    public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }

    // GET
    public async Task<IEnumerable<ClienteDTO>> GetAllAsync()
    {
        var clientes = await _clienteRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
    }

    public async Task<ClienteDTO?> GetByIdAsync(int id)
    {
        var cliente = await _clienteRepository.GetByIdAsync(id);
        if (cliente == null) return null;

        return _mapper.Map<ClienteDTO>(cliente);
    }    
    
    public async Task<ClienteWithFacturasDTO?> GetByIdWithFacturasAsync(int id)
    {
        var cliente = await _clienteRepository.GetByIdWithFacturasAsync(id);
        if (cliente == null) return null;

        return _mapper.Map<ClienteWithFacturasDTO>(cliente);
    }

    public async Task<ClienteDTO> AddAsync(ClienteCreateUpdateDTO dto)
    {
        var cliente = _mapper.Map<Cliente>(dto);

        await _clienteRepository.AddAsync(cliente);
        await _clienteRepository.SaveChangesAsync();

        return _mapper.Map<ClienteDTO>(cliente);
    }

    public async Task<bool> UpdateAsync(int id, ClienteCreateUpdateDTO dto)
    {
        var clienteExistente = await _clienteRepository.GetByIdAsync(id);
        if(clienteExistente == null) return false;

        _mapper.Map(dto, clienteExistente);
        _clienteRepository.Update(clienteExistente);
        await _clienteRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var clienteExistente = await _clienteRepository.GetByIdAsync(id);
        if(clienteExistente == null) return false;

        _clienteRepository.Delete(clienteExistente);
        await _clienteRepository.SaveChangesAsync();

        return true;       
    }

}