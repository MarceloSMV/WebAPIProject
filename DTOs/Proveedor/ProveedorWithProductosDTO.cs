using WebAPIProject.DTOs.Producto;

namespace WebAPIProject.DTOs.Proveedor;
public class ProveedorWithProductosDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public List<ProductoDTO> Productos { get; set; } = new();
}