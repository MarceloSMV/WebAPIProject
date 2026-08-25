using AutoMapper;
using WebAPIProject.DTOs.Categoria;
using WebAPIProject.Models;
using WebAPIProject.Repositories.Interfaces;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Services.Implements;
public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IMapper _mapper;

    // Iyeccion de dependencias
    public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
    {
        _categoriaRepository = categoriaRepository;
        _mapper = mapper;
    }
    
    // Metodos GET
    public async Task<IEnumerable<CategoriaDTO>> GetAllAsync()
    {
        var categorias = await _categoriaRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
    }
    public async Task<CategoriaDTO?> GetByIdAsync(int id)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(id);
        if (categoria == null) return null;

        return _mapper.Map<CategoriaDTO>(categoria);
    }   
    public async Task<CategoriaWithProductosDTO?> GetByIdWithProductosAsync(int id)
    {
        var categoria = await _categoriaRepository.GetByIdWithProductosAsync(id);
        if (categoria == null) return null;
        
        return _mapper.Map<CategoriaWithProductosDTO>(categoria);
        
    }
    // Metodos POST - PUT - DELETE
    public async Task<CategoriaDTO> AddAsync(CategoriaCreateUpdateDTO dto)
    {
        var categoria = _mapper.Map<Categoria>(dto);

        await _categoriaRepository.AddAsync(categoria);
        await _categoriaRepository.SaveChangesAsync();

        return _mapper.Map<CategoriaDTO>(categoria);

    }
    public async Task<bool> UpdateAsync(int id, CategoriaCreateUpdateDTO dto)
    {
        var categoriaExistente = await _categoriaRepository.GetByIdAsync(id);
        if (categoriaExistente == null) return false;

        _mapper.Map(dto, categoriaExistente);
        _categoriaRepository.Update(categoriaExistente);
        await _categoriaRepository.SaveChangesAsync();

        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var categoriaExistente = await _categoriaRepository.GetByIdAsync(id);

        if (categoriaExistente == null) return false;

        _categoriaRepository.Delete(categoriaExistente);
        await _categoriaRepository.SaveChangesAsync();

        return true;
    }
}