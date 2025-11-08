using OtzzeiDesafioMottu.Domain.Interfaces.IRepository;
using OtzzeiDesafioMottu.Domain.Interfaces.IService;
using OtzzeiDesafioMottu.Domain.Requests;
using OtzzeiDesafioMottu.Domain.Responses;

namespace OtzzeiDesafioMottu.Domain.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly MotorcycleRepository _motoRepository;
        private readonly IEventPublisher _publisher;
        public MotorcycleService(MotorcycleRepository motoRepository, IEventPublisher publisher)
        {
            _motoRepository = motoRepository;
            _publisher = publisher;
        }
        public async Task<MotorcycleResponse> CreateAsync(CreateMotorcycleRequest request)
        {
            var existing = await _motoRepository.GetByPlacaAsync(request.Placa);
            if (existing != null)
                throw new InvalidOperationException("Placa já cadastrada.");

            var moto = new Moto
            {
                Ano = request.Ano,
                Modelo = request.Modelo,
                Placa = request.Placa
            };

            await _motoRepository.AddAsync(moto);

            await _publisher.Publish(new MotoCadastradaEvent
            {
                MotoId = moto.Id,
                Ano = moto.Ano,
                Modelo = moto.Modelo,
                Placa = moto.Placa
            });

            return new MotoResponse
            {
                Id = moto.Id,
                Ano = moto.Ano,
                Modelo = moto.Modelo,
                Placa = moto.Placa,
                CreatedAt = moto.CreatedAt
            };
        }

        public async Task<IEnumerable<MotoResponse>> GetAllAsync()
        {
            var motos = await _motoRepository.GetAllAsync();
            return motos.Select(m => new MotoResponse
            {
                Id = m.Id,
                Ano = m.Ano,
                Modelo = m.Modelo,
                Placa = m.Placa,
                CreatedAt = m.CreatedAt
            });
        }
    }
}