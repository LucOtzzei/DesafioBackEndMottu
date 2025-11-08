using OtzzeiDesafioMottu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Interfaces.IRepository
{
    public interface IMotorcycleNotificationRepository
    {
        Task AddAsync(MotorcycleNotification notificacao);
        Task<IEnumerable<MotorcycleNotification>> GetAllAsync();
    }
}
