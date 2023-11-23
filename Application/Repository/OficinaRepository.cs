using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;
public class OficinaRepository: GenericRepo<Oficina>, IOficina
{
        private readonly ApiContext _context;
    
    public OficinaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Oficina>> GetAllAsync()
    {
        return await _context.Oficinas
            .ToListAsync();
    }

    public async Task<Oficina> GetByIdAsync(string id)
    {
        return await _context.Oficinas
        .FirstOrDefaultAsync(p =>  p.CodigoOficina == id);
    }

}