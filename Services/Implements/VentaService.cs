using AutoMapper;
using WebAPIProject.DTOs.Venta;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Services.Implements;
public class VentaService : IVentaService
{
    private readonly IVentaRepository _ventaRepository;
    private readonly IMapper _mapper;

    public VentaService(IVentaRepository ventaRepository, IMapper mapper)
    {
        _ventaRepository = ventaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VentaDTO>> GetAllAsync()
    {
        var ventas = await _ventaRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<VentaDTO>>(ventas);
    }

    public async Task<VentaDTO?> GetByIdAsync(int id)
    {
        var venta = await _ventaRepository.GetByIdAsync(id);
        if (venta == null) return null;

        return _mapper.Map<VentaDTO>(venta);
    }

    public async Task<IEnumerable<VentaWithDetailsDTO>> GetAllWithDetailsAsync()
    {
        var ventas = await _ventaRepository.GetAllWithDetailsAsync();
        return _mapper.Map<IEnumerable<VentaWithDetailsDTO>>(ventas);
    }

    public async Task<VentaWithDetailsDTO?> GetByIdWithDetailsAsync(int id)
    {
        var venta = await _ventaRepository.GetByIdWithDetailsAsync(id);
        if (venta == null) return null;

        return _mapper.Map<VentaWithDetailsDTO>(venta);
    }

    public async Task<VentaDTO> AddAsync(VentaCreateUpdateDTO dto)
    {
        var venta = _mapper.Map<Venta>(dto);

        await _ventaRepository.AddAsync(venta);
        await _ventaRepository.SaveChangesAsync();

        return _mapper.Map<VentaDTO>(venta);
    }

    public async Task<bool> UpdateAsync(int id, VentaCreateUpdateDTO dto)
    {
        var ventaExistente = await _ventaRepository.GetByIdAsync(id);
        if(ventaExistente == null) return false;

        _mapper.Map(dto, ventaExistente);
        _ventaRepository.Update(ventaExistente);
        await _ventaRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var ventaExistente = await _ventaRepository.GetByIdAsync(id);
        if(ventaExistente == null) return false;

        _ventaRepository.Delete(ventaExistente);
        await _ventaRepository.SaveChangesAsync();

        return true;
    }
}