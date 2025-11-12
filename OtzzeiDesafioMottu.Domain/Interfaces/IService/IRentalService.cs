using OtzzeiDesafioMottu.Domain.Entities;
using OtzzeiDesafioMottu.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Interfaces.IService
{
    public interface IRentalService
    {
        Task<Rental> CreateRentalAsync(CreateRentalRequest request);
        Task<Rental> FinishRentalAsync(Guid rentalId, DateTime returnDate);
        Task<Rental> GetByIdAsync(Guid rentalId);
    }
}