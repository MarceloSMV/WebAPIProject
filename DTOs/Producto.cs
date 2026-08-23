namespace WebAPIProject.Models;
public class Producto
{
    public int Id { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    // FK Categoria - Producto.Categoria
    public int CategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    // FK Proveedor - Producto.Proveedor
    public int ProveedorId { get; set; }
    public Proveedor? Proveedor { get; set; }
    // NI Venta - Producto.Ventas
    public ICollection<Venta>? Ventas { get; set; }
    
}