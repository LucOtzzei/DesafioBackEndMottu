using OtzzeiDesafioMottu.Domain.Entities;
using OtzzeiDesafioMottu.Domain.Enums;
using OtzzeiDesafioMottu.Domain.Interfaces.IRepository;
using OtzzeiDesafioMottu.Domain.Interfaces.IService;
using OtzzeiDesafioMottu.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtzzeiDesafioMottu.Domain.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly IDeliveryManRepository _deliverymanRepository;

        public RentalService(
            IRentalRepository rentalRepository,
            IMotorcycleRepository motorcycleRepository,
            IDeliveryManRepository deliverymanRepository)
        {
            _rentalRepository = rentalRepository;
            _motorcycleRepository = motorcycleRepository;
            _deliverymanRepository = deliverymanRepository;
        }

        public async Task<Rental> CreateRentalAsync(CreateRentalRequest request)
        {
            var deliveryman = await _deliverymanRepository.GetByIdAsync(request.DeliverymanId);
            if (deliveryman == null)
                throw new KeyNotFoundException("Deliveryman not found.");

            if (deliveryman.CnhType != CNHTypeEnum.A || deliveryman.CnhType != CNHTypeEnum.AB)
                throw new InvalidOperationException("Only drivers with CNH A can rent motorcycles.");

            var motorcycle = await _motorcycleRepository.GetByIdAsync(request.MotorcycleId);
            if (motorcycle == null)
                throw new KeyNotFoundException("Motorcycle not found.");

            var dailyRate = GetDailyRate(request.PlanDays);

            var plan = new Plan(request.PlanDays, dailyRate);
            var rental = new Rental(
                request.MotorcycleId,
                request.DeliverymanId,
                plan
            );


            await _rentalRepository.AddAsync(rental);
            return rental;
        }

        public async Task<Rental> FinishRentalAsync(Guid rentalId, DateTime returnDate)
        {
            var rental = await GetByIdAsync(rentalId);

            rental.FinishRental(returnDate);
            await _rentalRepository.UpdateAsync(rental);

            return rental;
        }

        public async Task<Rental> GetByIdAsync(Guid rentalId)
        {
            var rental = await _rentalRepository.GetByIdAsync(rentalId);
            if (rental == null)
                throw new KeyNotFoundException("Rental not found.");

            return rental;
        }

        private static decimal GetDailyRate(int planDays) => planDays switch
        {
            7 => 30m,
            15 => 28m,
            30 => 22m,
            45 => 20m,
            50 => 18m,
            _ => throw new ArgumentException("Invalid rental plan")
        };
    }
}