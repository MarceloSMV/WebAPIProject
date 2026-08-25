using AutoMapper;
using WebAPIProject.DTOs.Proveedor;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Services.Implements;
public class ProveedorService : IProveedorService
{
    private readonly IProveedorRepository _proveedorRepository;
    private readonly IMapper _mapper;

    public ProveedorService(IProveedorRepository proveedorRepository, IMapper mapper)
    {
        _proveedorRepository = proveedorRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProveedorDTO>> GetAllAsync()
    {
        var proveedores = await _proveedorRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProveedorDTO>>(proveedores);
    }

    public async Task<ProveedorDTO?> GetByIdAsync(int id)
    {
        var proveedor = await _proveedorRepository.GetByIdAsync(id);
        if (proveedor == null) return null;

        return _mapper.Map<ProveedorDTO>(proveedor);
    }

    public async Task<ProveedorWithProductosDTO?> GetByIdWithProductosAsync(int id)
    {
        var proveedor = await _proveedorRepository.GetByIdWithProductosAsync(id);
        if(proveedor == null) return null;

        return _mapper.Map<ProveedorWithProductosDTO>(proveedor);
    }

    public async Task<ProveedorDTO> AddAsync(ProveedorCreateUpdateDTO dto)
    {
        var proveedor = _mapper.Map<Proveedor>(dto);

        await _proveedorRepository.AddAsync(proveedor);
        await _proveedorRepository.SaveChangesAsync();

        return _mapper.Map<ProveedorDTO>(proveedor);
    }

    public async Task<bool> UpdateAsync(int id, ProveedorCreateUpdateDTO dto)
    {
        var proveedorExistente = await _proveedorRepository.GetByIdAsync(id);
        if(proveedorExistente == null) return false;

        _mapper.Map(dto, proveedorExistente);
        _proveedorRepository.Update(proveedorExistente);
        await _proveedorRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var proveedorExistente = await _proveedorRepository.GetByIdAsync(id);
        if(proveedorExistente == null) return false;

        _proveedorRepository.Delete(proveedorExistente);
        await _proveedorRepository.SaveChangesAsync();

        return true;
    }

}