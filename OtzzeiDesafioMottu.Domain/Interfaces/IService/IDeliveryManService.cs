using OtzzeiDesafioMottu.Domain.Requests;
using OtzzeiDesafioMottu.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Interfaces.IService
{
    public interface IDeliveryManService
    {
        Task<DeliveryManResponse> CreateAsync(CreateDeliveryManRequest request);
        Task<IEnumerable<DeliveryManResponse>> GetAllAsync();
        Task<DeliveryManResponse?> GetByCnpjAsync(string cnpj);
        //Task UpdateCnhImageAsync(Guid id, UpdateCnhImageRequest request);
    }
}
