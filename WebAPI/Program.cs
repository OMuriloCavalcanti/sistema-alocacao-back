using Application;
using Application.Interfaces;
using Application.Repository;
using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


// INTERFACE E REPOSITÓRIO
builder.Services.AddScoped(typeof(IGeneric<>), typeof(RepositoryGeneric<>));
builder.Services.AddScoped<IVeiculo, VeiculoRepository>();
builder.Services.AddScoped<IVeiculoAssistencia, VeiculoAssistenciaRepository>();
builder.Services.AddScoped<IEmpresaAssistencia, EmpresaAssistenciaRepository>();
builder.Services.AddScoped<IPlanoAssistencia, PlanoAssistenciaRepository>();
builder.Services.AddScoped<IGrupoVeiculo, GrupoVeiculoRepository>();
// INTERFACE APLICAÇÃO
builder.Services.AddScoped<InterfaceVeiculoApp, AppVeiculo>();
builder.Services.AddScoped<InterfaceGrupoVeiculoApp, AppGrupoVeiculo>();
builder.Services.AddScoped<InterfacePlanoAssistenciaApp, AppPlanoAssistencia>();
builder.Services.AddScoped<InterfaceVeiculoAssistenciaApp, AppVeiculoAssistencia>();
builder.Services.AddScoped<InterfaceEmpresasAssistenciaApp, AppEmpresasAssistencia>();
// INTERFACE DOMÍNIO
builder.Services.AddScoped<IVeiculoAssistenciaService, VeiculoAssistenciaService>();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.WebHost.ConfigureKestrel(options =>
{
    // Define portas explícitas (evita conflito)
    options.ListenAnyIP(8080);
    // Se quiser HTTPS, defina aqui também (ex: options.ListenAnyIP(8081, o => o.UseHttps()))
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
    options.Limits.RequestHeadersTimeout = TimeSpan.FromSeconds(30);
});

var app = builder.Build();

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

app.Run();
