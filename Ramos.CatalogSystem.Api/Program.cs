using MediatR;
using Ramos.CatalogSystem.Api.Services;
using Ramos.CatalogSystem.Api.Services.Context;
using Ramos.CatalogSystem.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona IHttpContextAccessor
builder.Services.AddHttpContextAccessor(); 

// Configuração do contexto MongoDB
builder.Services.Configure<MongoDBContext>(builder.Configuration);
builder.Services.AddSingleton<MongoDBContext>();

// Injeção de Dependência para os Serviços
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IDependencyService, DependencyService>();
builder.Services.AddScoped<IInfrastructureService, InfrastructureService>();
builder.Services.AddScoped<ISoftwareService, SoftwareService>();

// Adiciona MediatR
builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();

// Configura o pipeline de requisição HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();