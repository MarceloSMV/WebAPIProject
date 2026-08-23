namespace WebAPIProject.Models;
public class Factura
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    // FK - Cliente
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    // NI Venta - Factura.Ventas
    public ICollection<Venta>? Ventas { get; set; }
}