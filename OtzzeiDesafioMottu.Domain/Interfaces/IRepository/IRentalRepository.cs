using OtzzeiDesafioMottu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Interfaces.IRepository
{
    public interface IRentalRepository
    {
        Task<IEnumerable<Rental>> GetAllAsync();
        Task<Rental?> GetByIdAsync(Guid id);
        Task AddAsync(Rental rental);
        Task UpdateAsync(Rental rental);
        Task<bool> IsMotorcycleRentedAsync(Guid motorcycleId);
    }
}
