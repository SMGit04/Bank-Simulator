using Bank_Simulator.Database;
using Bank_Simulator.Remote;
using Bank_Simulator.Services.Implementation;
using Bank_Simulator.Services.Implementation.Card_Validation;
using Bank_Simulator.Services.Implementation.Encryption;
using Bank_Simulator.Services.Interfaces;
using Bank_Simulator.Services.Interfaces.Encryption;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<ITransactionChecksService, TransactionChecksService>();
builder.Services.AddTransient<ITransactionStatusService, TransactionStatusService>();
builder.Services.AddSingleton<IErrorCodesServices, ErrorCodesService>();
builder.Services.AddSingleton<IEncrptionService, EncrptionService>();
builder.Services.AddSingleton<IEncryptionKeyReaderService, EncryptionKeyReaderService>();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((hosts) => true));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options =>
{
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

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
app.MapHub<NotificationHub>("/notification");

app.Run();
