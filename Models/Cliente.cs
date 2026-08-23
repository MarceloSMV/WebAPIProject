using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProject.Models;

[Table("clientes")]
public class Cliente
{
    [Key]
    [Column("id_cliente")]
    public int Id { get; set; }

    [Required]
    [Column("nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [Column("direccion")]
    public string Direccion { get; set; } = string.Empty;

    [Required]
    [Column("telefono")]
    [MaxLength(20)]
    [Phone]
    public string Telefono { get; set; } = string.Empty;

    // Navegacion inversa - Cliente.Facturas
    public ICollection<Factura>? Facturas { get; set; } // Permite buscar que facturas tiene un cliente Cliente.Facturas
}
