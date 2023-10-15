using Bank_Simulator.Controllers;
using Bank_Simulator.Database;
using Bank_Simulator.Models;
using Bank_Simulator.Orchestration.Implementation;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Implementation;
using Bank_Simulator.Services.Implementation.Card_Validation;
using Bank_Simulator.Services.Implementation.Encryption;
using Bank_Simulator.Services.Implementation.Transactions;
using Bank_Simulator.Services.Interfaces.Encryption;
using Bank_Simulator.Services.Interfaces.Transactions;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

FirebaseApp temp = FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(@".\Keys\mobileposauth-firebase-adminsdk-b709f-bac8b34a0f.json"),
});

builder.Services.AddTransient<ITransactionChecksService, TransactionChecksService>();
builder.Services.AddTransient<ITransactionStatusService, TransactionStatusService>();
builder.Services.AddSingleton<IErrorCodesServices, ErrorCodesService>();
builder.Services.AddSingleton<IEncrptionService, EncrptionService>();
builder.Services.AddSingleton<IEncryptionKeyReaderService, EncryptionKeyReaderService>();
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddSingleton<TransactionRequestResultModel>();
builder.Services.AddScoped<NotificationController>();
// builder.Services.AddSingleton<MessageQueueService, MessageQueueService>();
builder.Services.AddTransient<ITransactionStatusOrchestration, TransactionRequestOrchestration>();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// app.MapHub<NotificationService>("/notification");

app.Run();
