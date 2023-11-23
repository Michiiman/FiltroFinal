using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class EmpleadoRepository: GenericRepo<Empleado>, IEmpleado
{
        private readonly ApiContext _context;
    
    public EmpleadoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _context.Empleados
            .ToListAsync();
    }

    public async Task<Empleado> GetByIdAsync(int id)
    {
        return await _context.Empleados
        .FirstOrDefaultAsync(p =>  p.CodigoEmpleado == id);
    }
    

    public async Task<IEnumerable<Object>> EmpleadosyJefes()
    {
        var resultado = await (
            from e1 in _context.Empleados
            join e2 in _context.Empleados on e1.CodigoJefe equals e2.CodigoEmpleado into join1
            from jefe in join1.DefaultIfEmpty()
            join e3 in _context.Empleados on jefe.CodigoJefe equals e3.CodigoEmpleado into join2
            from jefe2 in join2.DefaultIfEmpty()
            select new
            {
                NombreEmpleado = e1.Nombre + " " + e1.Apellidol,
                NombreJefe = jefe != null ? jefe.Nombre + " " + jefe.Apellidol : null,
                NombreJefedelJefe = jefe2 != null ? jefe2.Nombre + " " + jefe2.Apellidol : null
            }).ToListAsync();

        return resultado;
    }



}