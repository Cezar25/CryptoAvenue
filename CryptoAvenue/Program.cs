using CryptoAvenue.Application.CommandHandlers;
using CryptoAvenue.Application.Commands;
using CryptoAvenue.Application.Queries;
using CryptoAvenue.Dal;
using CryptoAvenue.Dal.Repositories;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Middleware;
using CryptoAvenue.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();

builder.Services.AddScoped<ICoinRepository, CoinRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<ITradeOfferRepository, TradeOfferRepository>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMediatR(typeof(CreateCoin));
builder.Services.AddMediatR(typeof(CreateUser));
builder.Services.AddMediatR(typeof(CreateWallet));
builder.Services.AddMediatR(typeof(CreateTradeOffer));
//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddDbContext<CryptoAvenueContext>(options
 => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMyMiddleware();

app.MapControllers();

app.Run();
