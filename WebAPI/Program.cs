using Aplicacion.Cursos;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

string connectionMode = "DefaultConnection";
bool environmentMac = true;

//Add context created
builder.Services.AddDbContext<CursosOnlineContext>(options => {
    if (environmentMac){
        connectionMode = "onMacConnection";
    };
    options.UseSqlServer(builder.Configuration.GetConnectionString(connectionMode));
});

//add mediator
builder.Services.AddMediatR(typeof(Consulta.Manejador).Assembly);

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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();