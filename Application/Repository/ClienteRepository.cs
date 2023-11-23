using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class ClienteRepository: GenericRepo<Cliente>, ICliente
{
        private readonly ApiContext _context;
    
    public ClienteRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .ToListAsync();
    }

    public async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes
        .FirstOrDefaultAsync(c =>  c.CodigoCliente == id);
    }
    
    public async Task<IEnumerable<Object>> ClientesPagoVentasCiudad()
    {
        var Dato = await (
            from cli in _context.Clientes
            join pag in _context.Pagos on cli.CodigoCliente equals pag.CodigoCliente
            join emp in _context.Empleados on cli.CodigoEmpleadoRepVentas equals emp.CodigoEmpleado
            where pag.IdTransaccion != null
            select new
            {
                Nombre = cli.NombreCliente,
                NombreRepresentante = emp.Nombre + " " + emp.Apellidol + " " + emp.Apellido2,
                CiudadOficina = emp.CodigoOficina
            }).Distinct().ToListAsync();

        return Dato;
    }

    public async Task<IEnumerable<Object>> ClientesNingunPago()
    {
        var resultado = await (
            from cli in _context.Clientes
            where !_context.Pagos.Any(p => p.CodigoCliente == cli.CodigoCliente)
            select cli
        ).ToListAsync();

        return resultado;
    }

    public async Task<IEnumerable<Object>> ClientesConRepresentanteYCiudadOficina()
    {
        var clientes = await (
            from cliente in _context.Clientes
            join emp in _context.Empleados on cliente.CodigoEmpleadoRepVentas equals emp.CodigoEmpleado
            join ofi in _context.Oficinas on emp.CodigoOficina equals ofi.CodigoOficina
            select new
            {
                NombreCliente = cliente.NombreCliente,
                NombreRepresentante = emp.Nombre + " " + emp.Apellidol,
                CiudadOficina = ofi.Ciudad
            }
        ).ToListAsync();

        return clientes;
    }

    public async Task<IEnumerable<Object>> ClientesSinPagosConRepresentante()
    {
        var clientesSinPagosConRepresentante = await (
            from cliente in _context.Clientes
            where !cliente.Pagos.Any()
            join emp in _context.Empleados on cliente.CodigoEmpleadoRepVentas equals emp.CodigoEmpleado
            select new
            {
                NombreCliente = cliente.NombreCliente,
                NombreRepresentante = emp.Nombre + " " + emp.Apellidol,
                ExtensionTelefonica = emp.Extension
            }
        ).ToListAsync();

        return clientesSinPagosConRepresentante;
    }

    
}