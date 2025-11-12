using Microsoft.EntityFrameworkCore;
using OtzzeiDesafioMottu.Domain.Entities;
using OtzzeiDesafioMottu.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.DesafioMottu.Infraestructure.Persistence.Repositories
{
    public class MotorcycleRepository : IMotorcycleRepository
    {
        private readonly MottuDbContext _context;

        public MotorcycleRepository(MottuDbContext context)
        {
            _context = context;
        }

        public async Task<Motorcycle> AddAsync(Motorcycle moto)
        {
            _context.Motorcycles.Add(moto);
            await _context.SaveChangesAsync();
            return moto;
        }

        public async Task<Motorcycle?> GetByPlacaAsync(string placa)
        {
            return await _context.Motorcycles
                .FirstOrDefaultAsync(x => x.Placa == placa);
        }

        public async Task<IEnumerable<Motorcycle>> GetAllAsync()
        {
            return await _context.Motorcycles.ToListAsync();
        }
        public async Task<Motorcycle?> GetByIdAsync(Guid id)
        {
            return await _context.Motorcycles
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}