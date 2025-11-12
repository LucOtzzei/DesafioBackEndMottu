using OtzzeiDesafioMottu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Interfaces.IRepository
{
    public interface IMotorcycleRepository
    {
        Task<Motorcycle> AddAsync(Motorcycle moto);
        Task<Motorcycle?> GetByPlacaAsync(string placa);
        Task<Motorcycle?> GetByIdAsync(Guid id);
        Task<IEnumerable<Motorcycle>> GetAllAsync();
    }
}
