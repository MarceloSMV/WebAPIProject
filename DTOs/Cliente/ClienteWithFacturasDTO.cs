using WebAPIProject.DTOs.Factura;

namespace WebAPIProject.DTOs.Cliente;
public class ClienteWithFacturasDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public List<FacturaDTO> Facturas { get; set; } = new();
}
