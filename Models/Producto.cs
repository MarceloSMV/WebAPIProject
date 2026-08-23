using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProject.Models;

[Table("productos")]
public class Producto
{
    [Key]
    [Column("id_producto")]
    public int Id { get; set; }

    [Required]
    [Column("descripcion")]
    [MaxLength(300)]
    public string Descripcion { get; set; } = string.Empty;

    [Required]
    [Column("precio", TypeName = "decimal(12,2)")]
    public decimal Precio { get; set; }

    // FK Categoria - Producto.Categoria
    [Required]
    [Column("id_categoria")]
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }

    // FK Proveedor - Producto.Proveedor
    [Required]
    [Column("id_proveedor")]
    public int ProveedorId { get; set; }
    public Proveedor? Proveedor { get; set; }
    // NI Venta - Producto.Ventas
    public ICollection<Venta>? Ventas { get; set; }
    
}