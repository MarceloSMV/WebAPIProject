using WebAPIProject.DTOs.Cliente;

namespace WebAPIProject.DTOs.Factura;
public class FacturaWithDetailsDTO
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public ClienteDTO? Cliente { get; set; }
}