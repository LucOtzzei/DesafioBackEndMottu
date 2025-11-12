using FluentValidation;
using OtzzeiDesafioMottu.Domain.Entities;
using OtzzeiDesafioMottu.Domain.Interfaces.IRepository;
using OtzzeiDesafioMottu.Domain.Interfaces.IService;
using OtzzeiDesafioMottu.Domain.Requests;
using OtzzeiDesafioMottu.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Services
{
    public class DeliveryManService : IDeliveryManService
    {
        private readonly IDeliveryManRepository _deliveryManRepository;
        private readonly IValidator<DeliveryMan> _validator;
        private readonly IFileService _storage;
        public DeliveryManService(IDeliveryManRepository deliveryManRepository, IValidator<DeliveryMan> validator, IFileService storage)
        {
            _deliveryManRepository = deliveryManRepository;
            _validator = validator;
            _storage = storage;
        }

        public async Task<DeliveryManResponse> CreateAsync(CreateDeliveryManRequest request)
        {
            var existingCnpj = await _deliveryManRepository.GetByCnpjAsync(request.Cnpj);
            if (existingCnpj != null)
                throw new InvalidOperationException("CNPJ already registered.");

            var existingCnh = await _deliveryManRepository.GetByCnhNumberAsync(request.CnhNumber);
            if (existingCnh != null)
                throw new InvalidOperationException("CNH already registered.");

            var driver = new DeliveryMan(
                request.Identifier,
                request.Name,
                request.Cnpj,
                request.BirthDate,
                request.CnhNumber,
                request.CnhType
            );

            await _validator.ValidateAndThrowAsync(driver);
            await _deliveryManRepository.AddAsync(driver);

            return new DeliveryManResponse(driver);
        }
        }

        public async Task<IEnumerable<DeliveryManResponse>> GetAllAsync()
        {
            var deliversMen = await _deliveryManRepository.GetAllAsync();
            return deliversMen.Select(dm => new DeliveryManResponse(dm));
        }

        public async Task<DeliveryManResponse?> GetByCnpjAsync(string cnpj)
        {
            var deliveryMan = await _deliveryManRepository.GetByCnpjAsync(cnpj);
            if(deliveryMan == null) return null;
            return new DeliveryManResponse(deliveryMan);
        }

        public async Task UpdateCnhImageAsync(Guid id, UpdateCnhImageRequest request)
        {
            var driver = (await _deliveryManRepository.GetAllAsync())
                .FirstOrDefault(x => x.Id == id);

            if (driver == null)
                throw new KeyNotFoundException("Driver not found.");

            // Atualiza a propriedade da entidade
            driver.UpdateCnhImage(request.CnhImagePath);

            await _deliveryManRepository.UpdateAsync(driver);
        }
    }
}
