using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Otzzei.DesafioMottu.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.DesafioMottu.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<MottuDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("MottuConnection")));

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(config["RabbitMq:Host"], h =>
                    {
                        h.Username(config["RabbitMq:Username"]);
                        h.Password(config["RabbitMq:Password"]);
                    });
                });
            });

            return services;
        }
    }
}
