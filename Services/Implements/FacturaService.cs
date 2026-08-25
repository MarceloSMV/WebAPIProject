using AutoMapper;
using WebAPIProject.DTOs.Factura;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Services.Implements;
public class FacturaService : IFacturaService
{
    private readonly IFacturaRepository _facturaRepository;
    private readonly IMapper _mapper;
    public FacturaService(IFacturaRepository facturaRepository, IMapper mapper)
    {
        _facturaRepository = facturaRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<FacturaDTO>> GetAllAsync()
    {
        var facturas = await _facturaRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<FacturaDTO>>(facturas);
    }
    public async Task<FacturaDTO?> GetByIdAsync(int id)
    {
        var factura = await _facturaRepository.GetByIdAsync(id);
        if (factura == null) return null;

        return _mapper.Map<FacturaDTO>(factura);
    }
    public async Task<IEnumerable<FacturaWithDetailsDTO>> GetAllWithDetailsAsync()
    {
        var facturas = await _facturaRepository.GetAllWithDetailsAsync();
        return _mapper.Map<IEnumerable<FacturaWithDetailsDTO>>(facturas);
    }
    public async Task<FacturaWithDetailsDTO?> GetByIdWithDetailsAsync(int id)
    {
        var factura = await _facturaRepository.GetByIdWithDetailsAsync(id);
        if (factura == null) return null;

        return _mapper.Map<FacturaWithDetailsDTO>(factura);
    }

    public async Task<FacturaWithVentasDTO?> GetByIdWithVentasAsync(int id)
    {
        var factura = await _facturaRepository.GetByIdWithVentasAsync(id);
        return _mapper.Map<FacturaWithVentasDTO>(factura);
    }
    public async Task<FacturaDTO> AddAsync(FacturaCreateUpdateDTO dto)
    {
        var factura = _mapper.Map<Factura>(dto);
        
        factura.Fecha = DateTime.UtcNow;

        await _facturaRepository.AddAsync(factura);
        await _facturaRepository.SaveChangesAsync();

        return _mapper.Map<FacturaDTO>(factura);
    }
    public async Task<bool> UpdateAsync(int id, FacturaCreateUpdateDTO dto)
    {
        var facturaExistente = await _facturaRepository.GetByIdAsync(id);

        if (facturaExistente == null) return false;

        _mapper.Map(dto, facturaExistente);
        _facturaRepository.Update(facturaExistente);
        await _facturaRepository.SaveChangesAsync();
        
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var facturaExistente = await _facturaRepository.GetByIdAsync(id);

        if(facturaExistente == null) return false;

        _facturaRepository.Delete(facturaExistente);
        await _facturaRepository.SaveChangesAsync();

        return true;
    }
}