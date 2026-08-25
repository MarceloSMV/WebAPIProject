using AutoMapper;
using WebAPIProject.DTOs.Producto;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Services.Implements;
public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;
    private readonly IMapper _mapper;
    public ProductoService(IProductoRepository productoRepository, IMapper mapper)
    {
        _productoRepository = productoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductoDTO>> GetAllAsync()
    {
        var productos = await _productoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductoDTO>>(productos);
    }

    public async Task<ProductoDTO?> GetByIdAsync(int id)
    {
        var producto = await _productoRepository.GetByIdAsync(id);
        if(producto == null) return null;

        return _mapper.Map<ProductoDTO>(producto);
    }

    public async Task<IEnumerable<ProductoWithDetailsDTO>> GetAllWithDetailsAsync()
    {
        var productos = await _productoRepository.GetAllWithDetailsAsync();
        return _mapper.Map<IEnumerable<ProductoWithDetailsDTO>>(productos);
    }

    public async Task<ProductoWithDetailsDTO?> GetByIdWithDetailsAsync(int id)
    {
        var producto = await _productoRepository.GetByIdWithDetailsAsync(id);
        if (producto == null) return null;

        return _mapper.Map<ProductoWithDetailsDTO>(producto);
    }

    public async Task<ProductoWithVentasDTO?> GetByIdWithVentasAsync(int id)
    {
        var producto = await _productoRepository.GetByIdWithVentasAsync(id);
        if(producto == null) return null;

        return _mapper.Map<ProductoWithVentasDTO>(producto);
    }

    public async Task<ProductoDTO> AddAsync(ProductoCreateUpdateDTO dto)
    {
        var producto = _mapper.Map<Producto>(dto);

        await _productoRepository.AddAsync(producto);
        await _productoRepository.SaveChangesAsync();

        return _mapper.Map<ProductoDTO>(producto);
    }

    public async Task<bool> UpdateAsync(int id, ProductoCreateUpdateDTO dto)
    {
        var productoExistente = await _productoRepository.GetByIdAsync(id);
        if(productoExistente == null) return false;

        _mapper.Map(dto, productoExistente);
        _productoRepository.Update(productoExistente);
        await _productoRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var producto = await _productoRepository.GetByIdAsync(id);
        if(producto == null) return false;

        _productoRepository.Delete(producto);
        await _productoRepository.SaveChangesAsync();

        return true;        
    }

}