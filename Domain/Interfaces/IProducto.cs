using Domain.Entities;

namespace Domain.Interfaces;
public interface IProducto : IGenericRepo<Producto>
{
    Task<IEnumerable<Object>> ProductosSinPedidoPlus();
}
