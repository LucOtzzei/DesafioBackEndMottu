using OtzzeiDesafioMottu.Domain.Entities;
using OtzzeiDesafioMottu.Domain.Events;
using OtzzeiDesafioMottu.Domain.Interfaces.IMessaging;
using OtzzeiDesafioMottu.Domain.Interfaces.IRepository;
using OtzzeiDesafioMottu.Domain.Interfaces.IService;
using OtzzeiDesafioMottu.Domain.Requests;
using OtzzeiDesafioMottu.Domain.Responses;

namespace OtzzeiDesafioMottu.Domain.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly IMotorcycleRepository _motoRepository;
        private readonly IEventPublisher _publisher;
        public MotorcycleService(IMotorcycleRepository motoRepository, IEventPublisher publisher)
        {
            _motoRepository = motoRepository;
            _publisher = publisher;
        }
        public async Task<MotorcycleResponse> CreateAsync(CreateMotorcycleRequest request)
        {
            var existing = await _motoRepository.GetByPlacaAsync(request.Placa);
            if (existing != null)
                throw new InvalidOperationException("Placa já cadastrada.");

            var moto = new Motorcycle
            {
                Ano = request.Ano,
                Modelo = request.Modelo,
                Placa = request.Placa
            };

            await _motoRepository.AddAsync(moto);

            await _publisher.PublishAsync(new MotorcycleRegisteredEvent
            {
                MotoId = moto.Id,
                Ano = moto.Ano,
                Modelo = moto.Modelo,
                Placa = moto.Placa
            });

            return new MotorcycleResponse
            {
                Ano = moto.Ano,
                Modelo = moto.Modelo,
                Placa = moto.Placa,
            };
        }

        public async Task<IEnumerable<MotorcycleResponse>> GetAllAsync()
        {
            var motos = await _motoRepository.GetAllAsync();
            return motos.Select(m => new MotorcycleResponse
            {
                Ano = m.Ano,
                Modelo = m.Modelo,
                Placa = m.Placa,
            });
        }
    }
}