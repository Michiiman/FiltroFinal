using Domain.Entities;

namespace Domain.Interfaces;
public interface IPago : IGenericRepo<Pago>
{
    Task<IEnumerable<Object>> PagosPaypal2008();
    Task<IEnumerable<Object>> MetodosPago();
}
