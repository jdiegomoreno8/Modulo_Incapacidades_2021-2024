using Common.EmailHelper;
using Common.ReadTemplateHelper;
using LibreriasIncapacidades.AccesoDatos;
using NegocioIncapacidades;
using NegocioIncapacidades.Implementaciones;
using NegocioIncapacidades.Interfaces;
using Notificaciones.Consumer;
using Notificaciones.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyectar acceso a datos
builder.Services.AddTransient<IDapperWrapper, DapperWrapper>();
builder.Services.AddTransient<IConexionFactory, ConexionFactory>();

//Inyeccion dependencias
builder.Services.AddTransient<IEmailHelper, EmailHelper>();
builder.Services.AddTransient<IReadTemplateHelper, ReadTemplateHelper>();
builder.Services.AddTransient<IIncapacidadNegocio, IncapacidadNegocio>();
builder.Services.AddTransient<IAccesoDatosDataWrite, AccesoDatosDataWrite>();
builder.Services.AddTransient<IAccesoDatosReadOnly, AccesoDatosReadOnly>();
builder.Services.AddTransient<INotificacionIncapacidadNegocio, NotificacionIncapacidadNegocio>();

//Add consumers
builder.Services.AddHostedService<NotificacionExpedicionIncapacidadAnulada>();
builder.Services.AddHostedService<NotificacionExpedicionIncapacidadConsumer>();
builder.Services.AddHostedService<NotificacionExpedicionIncapacidadPagada>();
builder.Services.AddHostedService<NotificacionExpedicionIncapacidadRehabilitacion>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
