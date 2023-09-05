using Bank_Simulator.Services.Interfaces.Transactions;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace Bank_Simulator.Services.Implementation.Transactions;

public class NotificationService : INotificationService
{
    public NotificationService()
    {

        _ = FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile(@".\Keys\mobileposauth-firebase-adminsdk-b709f-bac8b34a0f.json"),
        });
    }

    public async Task SendNotification()
    {
        var registrationToken = "eQ0LJSq6TF--fmiLRZdFqD:APA91bGaf7ILKinWn2Uv5bsS9Ry841MUvZV5rMWoWR73S6r-wNFjOJKTxpBeZLsFZNm9c0cEgb-uh2X0qBx2xlKwu_SSQCHkn8sXW_wVa75esg2l5hUb-rWFHFD70kfG2rmUP1-XGMIJ";


        // See documentation on defining a message payload.
        var message = new Message()
        {
            Token = registrationToken,
            Notification = new Notification()
            {
                Title = "Test",
                Body = "Test Testing",
            }
        };
        Console.WriteLine("message read");


        string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;

        // Response is a message ID string.
        Console.WriteLine("Successfully sent message: " + response);
    }
}
