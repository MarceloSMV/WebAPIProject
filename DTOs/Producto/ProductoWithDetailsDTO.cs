using WebAPIProject.DTOs.Categoria;
using WebAPIProject.DTOs.Proveedor;

namespace WebAPIProject.DTOs.Producto;
public class ProductoWithDetailsDTO
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int CategoriaId { get; set; }
    public CategoriaDTO? Categoria { get; set; }
    public int ProveedorId { get; set; }
    public ProveedorDTO? Proveedor { get; set; }
}