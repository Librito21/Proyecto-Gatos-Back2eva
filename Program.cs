using ProtectoraAPI.Controllers;
using ProtectoraAPI.Repositories;
using ProtectoraAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ProtectoraDB");

// Repositorios
builder.Services.AddScoped<IGatoRepository, GatoRepository>(provider =>
    new GatoRepository(connectionString));

builder.Services.AddScoped<IProtectoraRepository, ProtectoraRepository>(provider =>
    new ProtectoraRepository(connectionString));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(provider =>
    new UsuarioRepository(connectionString));

builder.Services.AddScoped<IDeseadoRepository, DeseadoRepository>(provider =>
    new DeseadoRepository(connectionString));

// Servicios
builder.Services.AddScoped<IGatoService, GatoService>(provider =>
    new GatoService(provider.GetRequiredService<IGatoRepository>()));

builder.Services.AddScoped<IProtectoraService, ProtectoraService>(provider =>
    new ProtectoraService(provider.GetRequiredService<IProtectoraRepository>()));

builder.Services.AddScoped<IUsuarioService, UsuarioService>(provider =>
    new UsuarioService(provider.GetRequiredService<IUsuarioRepository>()));

builder.Services.AddScoped<IDeseadoService, DeseadoService>(provider =>
    new DeseadoService(provider.GetRequiredService<IDeseadoRepository>()));

// Agregar controladores
builder.Services.AddControllers();

// Configuración Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuración del pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
