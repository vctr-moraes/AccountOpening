using AccountOpening.Core.Application.DTOs.Request;
using AccountOpening.Core.Application.DTOs.Response;
using AccountOpening.Core.Application.Ports.DrivingPorts;
using AccountOpening.Core.Application.UseCases;
using AccountOpening.Core.Domain.Interfaces.Repositories;
using AccountOpening.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using AccountOpening.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AccountOpeningDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AccountOpeningDbContext>();
builder.Services.AddScoped<IClientRepository, ClientRepository>(); 
builder.Services.AddScoped<IUseCase<RegisterClientRequestDto, RegisterClientResponseDto>, RegisteringClientUseCase>();
builder.Services.AddScoped<IUseCase<GetClientByIdRequestDto, GetClientByIdResponseDto>, GetClientByIdUseCase>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();