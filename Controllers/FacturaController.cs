using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity.UI.Services;
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

    [HttpGet]
    public async Task<ActionResult<FacturaDTO>> GetById(int id)
    {
        var factura = await _facturaService.GetByIdAsync(id);
        if (factura == null) return NotFound(new {message = "Factura no encontrada"});

        return Ok(factura);
    }

    public async Task<ActionResult<IEnumerable<FacturaWithDetailsDTO>>> GetAllWithDetails()
    {
        var facturas = await _facturaService.GetAllWithDetailsAsync();
        Ok(facturas);
    }




}