using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class PedidoRepository: GenericRepo<Pedido>, IPedido
{
        private readonly ApiContext _context;
    
    public PedidoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Pedido>> GetAllAsync()
    {
        return await _context.Pedidos
            .ToListAsync();
    }

    public async Task<Pedido> GetByIdAsync(int id)
    {
        return await _context.Pedidos
        .FirstOrDefaultAsync(p =>  p.CodigoPedido == id);
    }
    
    public async Task<IEnumerable<Object>> PedidosPorEstado()
    {
        var pedidosPorEstado = await _context.Pedidos
            .GroupBy(p => p.Estado)
            .Select(g => new
            {
                Estado = g.Key,
                CantidadPedidos = g.Count()
            })
            .OrderByDescending(x => x.CantidadPedidos)
            .ToListAsync();

        return pedidosPorEstado;
    }
}