using Auth_API_1.Models;
using Auth_API_1.Repositorios.Entity;
using Auth_API_1.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IServicoADM<Administrador>, AdministradorRepositorioEntity>();
builder.Services.AddScoped<IServico<Veiculo>, VeiculoRepositorioEntity>();
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
