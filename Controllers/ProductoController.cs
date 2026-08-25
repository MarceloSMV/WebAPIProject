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

    [HttpGet("detalles")]
    public async Task<ActionResult<IEnumerable<>>>



}

