using AwHellNah.TicketService.Domain;
using AwHellNah.TicketService.Driven;
using AwHellNah.TicketService.Driving;
using Frametux.Shared.Core;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSharedCore(typeof(Program).Assembly);
builder.Services.AddDriven(builder.Configuration);
builder.Services.AddDomain();
builder.Services.AddDriving();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseDriving();

app.Run();