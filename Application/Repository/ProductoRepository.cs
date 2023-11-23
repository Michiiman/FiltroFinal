using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ProductoRepository: GenericRepo<Producto>, IProducto
{
        private readonly ApiContext _context;
    
    public ProductoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos
            .ToListAsync();
    }

    public async Task<Producto> GetByIdAsync(string id)
    {
        return await _context.Productos
        .FirstOrDefaultAsync(pr =>  pr.CodigoProducto == id);
    }

    public async Task<IEnumerable<Object>> ProductosSinPedidoPlus()
    {
        var productosSinPedidos = await (
            from prod in _context.Productos
            join gp in _context.GamaProductos on prod.Gama equals gp.Gama
            where !_context.DetallePedidos.Any(dp => dp.CodigoProducto == prod.CodigoProducto)
            select new
            {
                CodigoProducto = prod.CodigoProducto,
                NombreProducto = prod.Nombre,
                Descripcion=gp.DescripcionTexto,
                Imagen= gp.Imagen
            }
        ).ToListAsync();

        return productosSinPedidos;
    }
}