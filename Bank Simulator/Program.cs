using Bank_Simulator.Database;
using Bank_Simulator.Orchestration.Implementation;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Implementation;
using Bank_Simulator.Services.Implementation.Encryption;
using Bank_Simulator.Services.Interfaces;
using Bank_Simulator.Services.Interfaces.Encryption;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICardValidatorService, CardValidatorService>();
builder.Services.AddSingleton<IErrorCodesServices, ErrorCodesService>();
builder.Services.AddSingleton<IEncrptionService, EncrptionService>();
builder.Services.AddSingleton<IEncryptionKeyReaderService, EncryptionKeyReaderService>();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<ICardValidatorOrchestration, CardValidatorOrchestration>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
