using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProject.Models;

[Table("facturas")]
public class Factura
{
    [Key]
    [Column("id_factura")]
    public int Id { get; set; }

    [Required]
    [Column("fecha")]
    public DateTime Fecha { get; set; }

    // FK - Cliente
    [Column("id_cliente")]
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }

    // NI Venta - Factura.Ventas
    public ICollection<Venta>? Ventas { get; set; }
}