using RestauranteAPI.Controllers;
using RestauranteAPI.Repositories;
using RestauranteAPI.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("RestauranteDB");

builder.Services.AddScoped<IPlatoPrincipalRepository, PlatoPrincipalRepository>(provider =>
new PlatoPrincipalRepository(connectionString));

builder.Services.AddScoped<IBebidaRepository, IBebidaRepository>(provider =>
new BebidaRepository(connectionString));

builder.Services.AddScoped<IPostreRepository, IPostreRepository>(provider =>
new PostreRepository(connectionString));

builder.Services.AddScoped<IPlatoPrincipalService, PlatoPrincipalService>(provider =>
new PlatoPrincipalService(connectionString));
// Add services to the container.

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



//PlatoPrincipalController.InicializarDatos();
app.Run();
