using OtzzeiDesafioMottu.Domain.Requests;
using OtzzeiDesafioMottu.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Interfaces.IService
{
    public interface IMotorcycleService
    {
        Task<MotorcycleResponse> CreateAsync(CreateMotorcycleRequest request);
        Task<IEnumerable<MotorcycleResponse>> GetAllAsync();
    }
}
