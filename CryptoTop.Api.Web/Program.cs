using CryptoTop.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var rabbitMqConnectionString = builder.Configuration.GetConnectionString("RabbitMqConnection") ??
                               throw new InvalidOperationException("Connection string 'RabbitMqConnection' not found.");

builder.Services.AddDbContextPool<CryptoTopDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.Create(10, 9, 2, ServerType.MariaDb)));

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
