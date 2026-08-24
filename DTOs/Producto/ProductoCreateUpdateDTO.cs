namespace WebAPIProject.DTOs.Producto;
public class ProductoCreateUpdateDTO
{
    public string Descripcion { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int CategoriaId { get; set; }
    public int ProveedorId { get; set; }
    
}