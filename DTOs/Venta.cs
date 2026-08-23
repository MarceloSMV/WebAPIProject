using System.Runtime.ConstrainedExecution;

namespace WebAPIProject.Models;
public class Venta
{
    public int Id { get; set; }
    // FK Factura - Venta.Factura
    public int FacturaId { get; set; }
    public Factura? Factura { get; set; }
    // FK Producto - Venta.Producto 
    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }
    public double Cantidad { get; set; }
    
}