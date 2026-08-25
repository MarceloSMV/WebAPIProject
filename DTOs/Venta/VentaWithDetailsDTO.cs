using WebAPIProject.DTOs.Factura;
using WebAPIProject.DTOs.Producto;

namespace WebAPIProject.DTOs.Venta;
public class VentaWithDetailsDTO
{
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public FacturaDTO? Factura { get; set; }
    public int ProductoId { get; set; }
    public ProductoDTO? Producto { get; set; }
    public decimal Cantidad { get; set; }
}