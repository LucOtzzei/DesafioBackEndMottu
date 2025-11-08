using MassTransit;
using OtzzeiDesafioMottu.Domain.Entities;
using OtzzeiDesafioMottu.Domain.Events;
using OtzzeiDesafioMottu.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.DesafioMottu.Infraestructure.Messaging.Costumers
{
    public class MotorcycleRegisteredCostumer : IConsumer<MotorcycleRegisteredEvent>
    {
        private readonly IMotorcycleNotificationRepository _notificationRepository;
        public MotorcycleRegisteredCostumer(IMotorcycleNotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task Consume(ConsumeContext<MotorcycleRegisteredEvent> context)
        {
            var message = context.Message;

            if (message.Ano == 2024)
            {
                var notificacao = new MotorcycleNotification
                {
                    MotoId = message.MotoId,
                    Placa = message.Placa,
                    Ano = message.Ano,
                    DataRegistro = DateTime.UtcNow
                };

                await _notificationRepository.AddAsync(notificacao);
            }
        }
    }
}