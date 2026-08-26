using Microsoft.AspNetCore.Mvc;
using WebAPIProject.DTOs.Venta;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VentaController : ControllerBase
{
    private readonly IVentaService _ventaService;

    public VentaController(IVentaService ventaService)
    {
        _ventaService = ventaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VentaDTO>>> GetAll()
    {
        var ventas = await _ventaService.GetAllAsync();
        return Ok(ventas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VentaDTO>> GetById(int id)
    {
        var venta = await _ventaService.GetByIdAsync(id);
        if (venta == null) return NotFound(new { message = "Venta no encontrada" });

        return Ok(venta);
    }

    [HttpGet("details")]
    public async Task<ActionResult<IEnumerable<VentaWithDetailsDTO>>> GetAllWithDetails()
    {
        var ventas = await _ventaService.GetAllWithDetailsAsync();
        return Ok(ventas);
    }

    [HttpGet("{id}/details")]
    public async Task<ActionResult<VentaWithDetailsDTO>> GetByIdWithDetails(int id)
    {
        var venta = await _ventaService.GetByIdWithDetailsAsync(id);
        if (venta == null) return NotFound(new { message = "Venta no encontrada" });

        return Ok(venta);
    }

    [HttpPost]
    public async Task<ActionResult<VentaDTO>> Create([FromBody] VentaCreateUpdateDTO dto)
    {
        var nuevaVenta = await _ventaService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = nuevaVenta.Id }, nuevaVenta);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] VentaCreateUpdateDTO dto)
    {
        var actualizado = await _ventaService.UpdateAsync(id, dto);
        if (!actualizado) return NotFound(new { message = "Venta no encontrada para actualizar" });

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var eliminado = await _ventaService.DeleteAsync(id);
        if (!eliminado) return NotFound(new { message = "Venta no encontrada para eliminar" });

        return NoContent();
    }
}