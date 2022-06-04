using CryptoAvenue.Application.CommandHandlers;
using CryptoAvenue.Application.Commands;
using CryptoAvenue.Application.Queries;
using CryptoAvenue.Dal;
using CryptoAvenue.Dal.Repositories;
using CryptoAvenue.Domain.IRepositories;
using CryptoAvenue.Middleware;
using CryptoAvenue.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "http://localhost:4200/",
            ValidAudience = "http://localhost:4200/",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@346"))
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", corsBuilder =>
    {
        corsBuilder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("EnableCORS");

//app.UseCookiePolicy();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMyMiddleware();

app.MapControllers();

app.Run();
