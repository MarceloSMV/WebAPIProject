namespace WebAPIProject.DTOs.Venta;
public class VentaDTO
{
    public int Id { get; set; }
    public int FacturaId { get; set; }
    public int ProductoId { get; set; }
    public decimal Cantidad { get; set; }
}