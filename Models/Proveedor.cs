using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProject.Models;

[Table("proveedores")]
public class Proveedor
{
    [Key]
    [Column("id_proveedor")]
    public int Id { get; set; }

    [Required]
    [Column("nombre")]
    public string Nombre { get; set; } = string.Empty;
    
    [Required]
    [Column("direccion")]
    public string Direccion { get; set; } = string.Empty;

    [Required]
    [Column("telefono")]
    [Phone]
    public string Telefono { get; set; } = string.Empty;
    // Navegacion Inversa: Proveedor.Productos 
    public ICollection<Producto>? Productos { get; set; }
}