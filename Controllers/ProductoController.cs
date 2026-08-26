using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIProject.DTOs.Producto;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;
    public ProductoController(IProductoService productoService )
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetAll()
    {
        var ventas = await _productoService.GetAllAsync();
        return Ok(ventas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoDTO>> GetById(int id)
    {
        var venta = await _productoService.GetByIdAsync(id);
        if (venta == null) return NotFound(new { message = "Venta no encontrada" });

        return Ok(venta);
    }

    [HttpGet("details")]
    public async Task<ActionResult<IEnumerable<ProductoWithDetailsDTO>>> GetAllWithDetails()
    {
        var productos = await _productoService.GetAllWithDetailsAsync();

        return Ok(productos);
    }

    [HttpGet("{id}/details")]
    public async Task<ActionResult<ProductoWithDetailsDTO>> GetByIdWithDetails(int id)
    {
        var producto = await _productoService.GetByIdWithDetailsAsync(id);
        if(producto == null) return NotFound(new {message = "Producto no encontrado"});

        return Ok(producto);
    }

    [HttpGet("{id}/ventas")]
    public async Task<ActionResult<ProductoWithVentasDTO>> GetByIdWithVentas(int id)
    {
        var producto = await _productoService.GetByIdWithVentasAsync(id);
        if(producto == null) return NotFound(new {message = "Producto no encontrado"});

        return Ok(producto);
    }

    [HttpPost]
    public async Task<ActionResult<ProductoDTO>> Create([FromBody] ProductoCreateUpdateDTO dto)
    {
        var nuevoProducto = await _productoService.AddAsync(dto);

        return CreatedAtAction(nameof(GetById), new{id = nuevoProducto.Id}, nuevoProducto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] ProductoCreateUpdateDTO dto)
    {
        var actualizado = await _productoService.UpdateAsync(id, dto);
        if(!actualizado) return NotFound(new {message = "Producto no encontrado"}); 

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var eliminado = await _productoService.DeleteAsync(id);
        if(!eliminado) return NotFound(new {message = "Producto no encontrado"});

        return NoContent();
    }
}

