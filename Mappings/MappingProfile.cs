using AutoMapper;
using WebAPIProject.DTOs.Categoria;
using WebAPIProject.DTOs.Cliente;
using WebAPIProject.DTOs.Factura;
using WebAPIProject.DTOs.Producto;
using WebAPIProject.DTOs.Proveedor;
using WebAPIProject.DTOs.Venta;
using WebAPIProject.Models;

namespace WebAPIProject.Mappings;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // ==========================================
        // 1. CATEGORÍA
        // ==========================================
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        CreateMap<CategoriaCreateUpdateDTO, Categoria>();
        // Al tener CreateMap<Producto, ProductoDTO> más abajo, AutoMapper 
        // llenará automáticamente la lista de Productos de este DTO.
        CreateMap<Categoria, CategoriaWithProductosDTO>();

        // ==========================================
        // 2. CLIENTE
        // ==========================================
        CreateMap<Cliente, ClienteDTO>().ReverseMap();
        CreateMap<ClienteCreateUpdateDTO, Cliente>();
        CreateMap<Cliente, ClienteWithFacturasDTO>();

        // ==========================================
        // 3. PROVEEDOR
        // ==========================================
        CreateMap<Proveedor, ProveedorDTO>().ReverseMap();
        CreateMap<ProveedorCreateUpdateDTO, Proveedor>();
        CreateMap<Proveedor, ProveedorWithProductosDTO>();

        // ==========================================
        // 4. PRODUCTO
        // ==========================================
        CreateMap<Producto, ProductoDTO>().ReverseMap();
        CreateMap<ProductoCreateUpdateDTO, Producto>();
        // AutoMapper mapeará las propiedades de navegación Categoria y Proveedor
        CreateMap<Producto, ProductoWithDetailsDTO>(); 
        CreateMap<Producto, ProductoWithVentasDTO>();

        // ==========================================
        // 5. FACTURA
        // ==========================================
        CreateMap<Factura, FacturaDTO>().ReverseMap();
        CreateMap<FacturaCreateUpdateDTO, Factura>();
        // AutoMapper mapeará la propiedad de navegación Cliente
        CreateMap<Factura, FacturaWithDetailsDTO>();
        CreateMap<Factura, FacturaWithVentasDTO>();

        // ==========================================
        // 6. VENTA
        // ==========================================
        CreateMap<Venta, VentaDTO>().ReverseMap();
        CreateMap<VentaCreateUpdateDTO, Venta>();
        // AutoMapper mapeará las propiedades de navegación Factura y Producto
        CreateMap<Venta, VentaWithDetailsDTO>();
    }
}