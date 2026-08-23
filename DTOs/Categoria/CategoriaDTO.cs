using System.ComponentModel.DataAnnotations.Schema;
using WebAPIProject.Models;

public class CategoriaDTO
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    // NI Producto - Categoria.Productos
    public ICollection<Producto>? Productos { get; set; }
    
}