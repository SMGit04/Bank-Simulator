namespace Bank_Simulator.Services.Interfaces.Transactions
{
    public interface INotificationHub
    {
        Task SendNotification(string message);
    }
}
