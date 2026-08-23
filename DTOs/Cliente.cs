namespace WebAPIProject.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    // Navegacion inversa - Cliente.Facturas
    public ICollection<Factura>? Facturas { get; set; } // Permite buscar que facturas tiene un cliente Cliente.Facturas
}
