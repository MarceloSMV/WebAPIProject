using WebAPIProject.DTOs.Categoria;
using WebAPIProject.DTOs.Proveedor;
using WebAPIProject.DTOs.Venta;

namespace WebAPIProject.DTOs.Producto;
public class ProductoWithVentasDTO
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int CategoriaId { get; set; }
    public int ProveedorId { get; set; }
    // NI Venta - Producto.Ventas
    public List<VentaDTO> Ventas { get; set; } =  new();
    
}