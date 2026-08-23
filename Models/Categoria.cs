using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProject.Models;
[Table("categorias")]
public class Categoria
{
    [Key]
    [Column("id_categoria")]
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    [Column("descripcion")]
    public string Descripcion { get; set; } = string.Empty;
    
    // NI Producto - Categoria.Productos
    public ICollection<Producto>? Productos { get; set; }
    
}