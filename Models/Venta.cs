using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProject.Models;

[Table("ventas")]
public class Venta
{
    [Key]
    [Column("id_venta")]
    public int Id { get; set; }

    // FK Factura - Venta.Factura
    [Column("id_factura")]
    public int FacturaId { get; set; }
    public Factura? Factura { get; set; }

    // FK Producto - Venta.Producto 
    [Column("id_producto")]
    public int ProductoId { get; set; }
    public Producto? Producto { get; set; }
    
    [Column("cantidad", TypeName = "decimal(10,2)")]
    public decimal Cantidad { get; set; }
}