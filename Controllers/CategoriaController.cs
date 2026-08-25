using Microsoft.AspNetCore.Mvc;
using WebAPIProject.DTOs.Categoria;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;
    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetAll()
    {
        var categorias = await _categoriaService.GetAllAsync();
        return Ok(categorias);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoriaDTO>> GetById(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);
        if(categoria == null) return NotFound(new { message = "Categoria no encontrada "});
        
        return Ok(categoria);
    }

    [HttpGet("{id}/productos")]
    public async Task<ActionResult<CategoriaWithProductosDTO>> GetByIdWithProductos(int id)
    {
        var categoria = await _categoriaService.GetByIdWithProductosAsync(id);
        if(categoria == null) return NotFound(new {message = "Categoría no encontrada"});

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaDTO>> Create([FromBody] CategoriaCreateUpdateDTO dto)
    {
        var nuevaCategoria = await _categoriaService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = nuevaCategoria.Id}, nuevaCategoria);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] CategoriaCreateUpdateDTO dto)
    {
        var actualizado = await _categoriaService.UpdateAsync(id, dto);
        if(!actualizado) return NotFound(new { message = "Categoria no encontrada para actualzar"});

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var eliminado = await _categoriaService.DeleteAsync(id);
        if(!eliminado) return NotFound(new {message = "Categoria no encontrada para eliminar"});

        return NoContent();
    }
}