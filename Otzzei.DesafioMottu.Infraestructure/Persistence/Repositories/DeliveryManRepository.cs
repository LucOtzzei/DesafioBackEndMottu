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
    public class DeliveryManRepository : IDeliveryManRepository
    {
        private readonly MottuDbContext _context;
        public DeliveryManRepository(MottuDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(DeliveryMan driver)
        {
            await _context.DeliveryMen.AddAsync(driver);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DeliveryMan>> GetAllAsync()
        {
            return await _context.DeliveryMen.ToListAsync();
        }

        public async Task<DeliveryMan?> GetByCnhNumberAsync(string cnhNumber)
        {
            return await _context.DeliveryMen.FirstOrDefaultAsync(x => x.CnhNumber == cnhNumber);
        }

        public async Task<DeliveryMan?> GetByCnpjAsync(string cnpj)
        {
            return await _context.DeliveryMen.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
        }
    }
}
