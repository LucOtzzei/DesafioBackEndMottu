using Otzzei.DesafioMottu.Infraestructure;
using Otzzei.DesafioMottu.Infraestructure.Messaging;
using Otzzei.DesafioMottu.Infraestructure.Persistence.Repositories;
using Otzzei.DesafioMottu.Infraestructure.Storage;
using OtzzeiDesafioMottu.Domain.Interfaces.IMessaging;
using OtzzeiDesafioMottu.Domain.Interfaces.IRepository;
using OtzzeiDesafioMottu.Domain.Interfaces.IService;
using OtzzeiDesafioMottu.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();
builder.Services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();
builder.Services.AddScoped<IMotorcycleNotificationRepository, MotorcycleNotificationRepository>();
builder.Services.AddScoped<IEventPublisher, RabbitMqEventPublisher>();
builder.Services.AddScoped<IDeliveryManService, DeliveryManService>();
builder.Services.AddScoped<IDeliveryManRepository, DeliveryManRepository>();
builder.Services.AddScoped<IFileService, LocalStorageService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
