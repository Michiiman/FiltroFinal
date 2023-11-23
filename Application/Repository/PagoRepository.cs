using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class PagoRepository: GenericRepo<Pago>, IPago
{
        private readonly ApiContext _context;
    
    public PagoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Pago>> GetAllAsync()
    {
        return await _context.Pagos
            .ToListAsync();
    }

    public async Task<Pago> GetByIdAsync(int id)
    {
        return await _context.Pagos
        .FirstOrDefaultAsync(pa =>  pa.CodigoCliente == id);
    }
    
    public async Task<IEnumerable<Object>> PagosPaypal2008()
    {
        var Dato = await (
            from p in _context.Pagos
            where p.FechaPago.Year == 2008 && p.FormaPago == "Paypal"
            select new
            {
                IdTransaccion = p.IdTransaccion,
                Cliente = p.CodigoCliente,
                MetodoPago = p.FormaPago,
                FechaPago = p.FechaPago,
                Precio = p.Total
            }).OrderDescending()
            .ToListAsync();

        return Dato;
    }

    public async Task<IEnumerable<Object>> MetodosPago()
    {
        var Dato = await (
            from p in _context.Pagos
            where p.FormaPago != null
            select new
            {
                MetodoDePago = p.FormaPago
            }
            ).Distinct()
            .ToListAsync();

        return Dato;
    }

}