using OtzzeiDesafioMottu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Interfaces.IRepository
{
    public interface IDeliveryManRepository
    {
        Task AddAsync(DeliveryMan driver);
        Task<DeliveryMan?> GetByCnpjAsync(string cnpj);
        Task<DeliveryMan?> GetByCnhNumberAsync(string cnhNumber);
        Task<IEnumerable<DeliveryMan>> GetAllAsync();
    }
}
