namespace WebAPIProject.DTOs.Venta;
public class VentaCreateUpdateDTO
{
    public int FacturaId { get; set; }
    public int ProductoId { get; set; }
    public decimal Cantidad { get; set; }
}