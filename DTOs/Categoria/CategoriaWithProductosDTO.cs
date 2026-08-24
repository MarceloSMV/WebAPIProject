using WebAPIProject.DTOs.Producto;

namespace WebAPIProject.DTOs.Categoria;
public class CategoriaWithProductosDTO
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public List<ProductoDTO> Productos { get; set; } = new();
        
}



