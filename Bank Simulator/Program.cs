using Bank_Simulator.Database;
using Bank_Simulator.Orchestration.Implementation;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Implementation;
using Bank_Simulator.Services.Implementation.Card_Validation;
using Bank_Simulator.Services.Implementation.Encryption;
using Bank_Simulator.Services.Interfaces;
using Bank_Simulator.Services.Interfaces.Encryption;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ICardValidatorService, CardValidatorService>();
builder.Services.AddTransient<ITransactionChecksService, TransactionChecksService>();
builder.Services.AddTransient<ITransactionStatusService, TransactionStatusService>();
builder.Services.AddSingleton<IErrorCodesServices, ErrorCodesService>();
builder.Services.AddSingleton<IEncrptionService, EncrptionService>();
builder.Services.AddSingleton<IEncryptionKeyReaderService, EncryptionKeyReaderService>();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<ICardValidatorOrchestration, CardValidatorOrchestration>();

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
