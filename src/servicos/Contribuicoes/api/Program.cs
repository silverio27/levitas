using System.Reflection;
using domain.CadastroDeAtividades.Repositorio;
using infra;
using infra.CadastroDeAtividades.Repositorio;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configureBinderMongo = builder.Configuration.GetSection("MongoDB");
builder.Services.Configure<MongoSettings>(configureBinderMongo);
builder.Services.AddSingleton<ContribuicoesContexto>();
builder.Services.AddSingleton<IAtividades, Atividades>();
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);

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
