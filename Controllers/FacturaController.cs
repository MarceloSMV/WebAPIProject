using Microsoft.AspNetCore.Mvc;
using WebAPIProject.DTOs.Factura;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacturaController : ControllerBase
{
    private readonly IFacturaService _facturaService;
    public FacturaController(IFacturaService facturaService)
    {
        _facturaService = facturaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FacturaDTO>>> GetAll()
    {
        var facturas = await _facturaService.GetAllAsync();
        return Ok(facturas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FacturaDTO>> GetById(int id)
    {
        var factura = await _facturaService.GetByIdAsync(id);
        if (factura == null) return NotFound(new {message = "Factura no encontrada"});

        return Ok(factura);
    }

    [HttpGet("details")]
    public async Task<ActionResult<IEnumerable<FacturaWithDetailsDTO>>> GetAllWithDetails()
    {
        var facturas = await _facturaService.GetAllWithDetailsAsync();
        return Ok(facturas);
    }

    [HttpGet("{id}/details")]
    public async Task<ActionResult<FacturaWithDetailsDTO>> GetByIdWithDetails(int id)
    {
        var factura = await _facturaService.GetByIdWithDetailsAsync(id);
        if(factura == null) return NotFound(new {message = "Factura no encontrada"});

        return Ok(factura);
    }

    [HttpGet("{id}/ventas")]
    public async Task<ActionResult<FacturaWithVentasDTO>> GetByIdWithVentas(int id)
    {
        var factura = await _facturaService.GetByIdWithVentasAsync(id);
        if(factura == null) return NotFound(new {message = "Factura no encontrada"});

        return Ok(factura);
    }

    [HttpPost]
    public async Task<ActionResult<FacturaDTO>> Create([FromBody] FacturaCreateUpdateDTO dto)
    {
        var nuevaFactura = await _facturaService.AddAsync(dto);

        return CreatedAtAction(nameof(GetById), new{id = nuevaFactura.Id}, nuevaFactura);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] FacturaCreateUpdateDTO dto)
    {
        var actualizado = await _facturaService.UpdateAsync(id, dto);
        if(!actualizado) return NotFound(new {message = "Factura no encontrada"});

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var eliminado = await _facturaService.DeleteAsync(id);
        if(!eliminado) return NotFound(new {message = "Factura no encontrada"});

        return NoContent();
    }

}