using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Otzzei.DesafioMottu.Infraestructure;
using Otzzei.DesafioMottu.Infraestructure.Messaging;
using Otzzei.DesafioMottu.Infraestructure.Persistence;
using Otzzei.DesafioMottu.Infraestructure.Persistence.Repositories;
using Otzzei.DesafioMottu.Infraestructure.Storage;
using OtzzeiDesafioMottu.Domain.Interfaces.IMessaging;
using OtzzeiDesafioMottu.Domain.Interfaces.IRepository;
using OtzzeiDesafioMottu.Domain.Interfaces.IService;
using OtzzeiDesafioMottu.Domain.Services;
using OtzzeiDesafioMottu.Domain.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddDbContext<MottuDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MottuConnection")));

builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();
builder.Services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
builder.Services.AddScoped<IMotorcycleNotificationRepository, MotorcycleNotificationRepository>();
builder.Services.AddScoped<IEventPublisher, RabbitMqEventPublisher>();
builder.Services.AddScoped<IDeliveryManService, DeliveryManService>();
builder.Services.AddScoped<IDeliveryManRepository, DeliveryManRepository>();
builder.Services.AddScoped<IFileService, LocalStorageService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(typeof(DeliveryManValidator).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
