using Bank_Simulator.Services.Interfaces.Transactions;
using FirebaseAdmin.Messaging;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Crypto.Prng;

namespace Bank_Simulator.Services.Implementation.Transactions;

public class NotificationService : INotificationService
{
    private static readonly Random RandomGenerator = new();
    private readonly List<string> merchantNames = new()
        {
            "Ackermans", "ALDI", "Checkers", "Clicks", "Edgars", "Foschini",
            "Game", "H&M", "Hyperama", "Incredible Connection", "Jumbo Cash",
            "Makro", "Mr Price", "Pep", "Pick n Pay", "Shoprite", "Spar",
            "Totalsports", "Truworths", "Woolworths"
        };
    public async Task SendNotification()
    {
        try
        {
            var registrationToken = "DELL";
           
            var message = new Message()
            {
                Token = GetRegistrationTokenFromAppSettings(registrationToken),

                Notification = new Notification()   
                {
                    Title = "Transaction Request",
                    Body = $"Transaction at {merchantNames[RandomMerchantSelector(merchantNames.Count)]}"
                },
            };
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            Console.WriteLine("Successfully sent message: ");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending notification: " + ex.Message);
        }
    }

    private int RandomMerchantSelector(int count)
    {
        return RandomGenerator.Next(0, count);
    }
    private string GetRegistrationTokenFromAppSettings(string key)
    {
        var appSettings = JObject.Parse(File.ReadAllText("appsettings.json"));
        return appSettings["RegistrationTokens"][key].ToString();
    }
}
