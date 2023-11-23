using Domain.Entities;

namespace Domain.Interfaces;
public interface IEmpleado : IGenericRepo<Empleado>
{
    Task<IEnumerable<Object>> EmpleadosyJefes();
}
