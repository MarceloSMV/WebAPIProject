using WebAPIProject.DTOs.Cliente;
using WebAPIProject.DTOs.Venta;

namespace WebAPIProject.DTOs.Factura;
public class FacturaWithVentasDTO
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public List<VentaDTO> Ventas { get; set; } = new();
}