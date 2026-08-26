using Microsoft.AspNetCore.Mvc;
using WebAPIProject.DTOs.Proveedor;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProveedorController : ControllerBase
{
    private readonly IProveedorService _proveedorService;

    public ProveedorController(IProveedorService proveedorService)
    {
        _proveedorService = proveedorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProveedorDTO>>> GetAll()
    {
        var proveedores = await _proveedorService.GetAllAsync();
        return Ok(proveedores);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProveedorDTO>> GetById(int id)
    {
        var proveedor = await _proveedorService.GetByIdAsync(id);
        if (proveedor == null) return NotFound(new { message = "Proveedor no encontrado" });

        return Ok(proveedor);
    }

    [HttpGet("{id}/productos")]
    public async Task<ActionResult<ProveedorWithProductosDTO>> GetByIdWithProductos(int id)
    {
        var proveedor = await _proveedorService.GetByIdWithProductosAsync(id);
        if (proveedor == null) return NotFound(new { message = "Proveedor no encontrado" });

        return Ok(proveedor);
    }

    [HttpPost]
    public async Task<ActionResult<ProveedorDTO>> Create([FromBody] ProveedorCreateUpdateDTO dto)
    {
        var nuevoProveedor = await _proveedorService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = nuevoProveedor.Id }, nuevoProveedor);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] ProveedorCreateUpdateDTO dto)
    {
        var actualizado = await _proveedorService.UpdateAsync(id, dto);
        if (!actualizado) return NotFound(new { message = "Proveedor no encontrado para actualizar" });

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var eliminado = await _proveedorService.DeleteAsync(id);
        if (!eliminado) return NotFound(new { message = "Proveedor no encontrado para eliminar" });

        return NoContent();
    }
}