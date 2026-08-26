using Microsoft.AspNetCore.Mvc;
using WebAPIProject.DTOs.Cliente;
using WebAPIProject.Services.Interfaces;

namespace WebAPIProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;
    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetAll()
    {
        var clientes = await _clienteService.GetAllAsync();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ClienteDTO>> GetById(int id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);
        if(cliente == null) return NotFound(new {message = "Cliente no encontrado"});

        return Ok(cliente);
    }
    
    [HttpGet("{id}/facturas")]
    public async Task<ActionResult<ClienteWithFacturasDTO>> GetByIdWithFacturas(int id)
    {
        var cliente = await _clienteService.GetByIdWithFacturasAsync(id);
        if(cliente == null) return NotFound(new { message = "Cliente no encontrado"});

        return Ok(cliente);
    }

    [HttpPost]
    public async Task<ActionResult<ClienteDTO>> Create([FromBody] ClienteCreateUpdateDTO dto)
    {
        var nuevoCliente = await _clienteService.AddAsync(dto);

        return CreatedAtAction(nameof(GetById), new {id = nuevoCliente.Id}, nuevoCliente);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] ClienteCreateUpdateDTO dto)
    {
        var actualizado = await _clienteService.UpdateAsync(id, dto);
        if(!actualizado) return NotFound(new {message = "Cliente no encontrado"});

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var eliminado = await _clienteService.DeleteAsync(id);
        if(!eliminado) return NotFound(new {message = "Cliente no encontrado"});

        return NoContent();
    }




    
}