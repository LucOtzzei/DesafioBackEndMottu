using OtzzeiDesafioMottu.Domain.Entities;
using OtzzeiDesafioMottu.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Otzzei.DesafioMottu.Infraestructure.Persistence.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly MottuDbContext _context;

        public RentalRepository(MottuDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rental>> GetAllAsync()
        {
            return await _context.Rentals.AsNoTracking().ToListAsync();
        }

        public async Task<Rental?> GetByIdAsync(Guid id)
        {
            return await _context.Rentals
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Rental rental)
        {
            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rental rental)
        {
            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsMotorcycleRentedAsync(Guid motorcycleId)
        {
            return await _context.Rentals.AnyAsync(r => r.MotorcycleId == motorcycleId && r.ActualEndDate == null);
        }
    }
}