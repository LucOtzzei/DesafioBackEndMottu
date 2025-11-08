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
    public class MotorcycleNotificationRepository : IMotorcycleNotificationRepository
    {
        private readonly MottuDbContext _context;
        public MotorcycleNotificationRepository(MottuDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(MotorcycleNotification notificacao)
        {
            _context.Notifications.Add(notificacao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MotorcycleNotification>> GetAllAsync()
        {
            return await _context.Notifications.ToListAsync();
        }
    }
}