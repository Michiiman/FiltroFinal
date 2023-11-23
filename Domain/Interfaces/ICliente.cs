using Domain.Entities;

namespace Domain.Interfaces;
public interface ICliente : IGenericRepo<Cliente>
{
    Task<IEnumerable<Object>> ClientesPagoVentasCiudad();
    Task<IEnumerable<Object>> ClientesNingunPago();
    Task<IEnumerable<Object>> ClientesConRepresentanteYCiudadOficina();
    Task<IEnumerable<Object>> ClientesSinPagosConRepresentante();
}
