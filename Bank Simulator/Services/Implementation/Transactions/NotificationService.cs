using Bank_Simulator.Services.Interfaces.Transactions;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace Bank_Simulator.Services.Implementation.Transactions;

public class NotificationService : INotificationService
{



    public async Task SendNotification()
    {

        try
        {
            
              //var registrationToken = "eQ0LJSq6TF--fmiLRZdFqD:APA91bGaf7ILKinWn2Uv5bsS9Ry841MUvZV5rMWoWR73S6r-wNFjOJKTxpBeZLsFZNm9c0cEgb-uh2X0qBx2xlKwu_SSQCHkn8sXW_wVa75esg2l5hUb-rWFHFD70kfG2rmUP1-XGMIJ";
            var registrationToken = "eebK8tXWRLe0L897TeqeGr:APA91bFf48MRSR9wI1DMBtQ8z9eddX2r-CLLI1cMT1gP61GXxEkxYv1Vnbv8y4JxbZUnKel8AYKXK-YgJlUhDAqDccyxBsu3AI_M-wdh8xhcG5SIuWBli52XQGS0GXbeu6sqAhACpAV9";
            // See documentation on defining a message payload.
            var message = new Message()
            {
                Token = registrationToken,

                Notification = new Notification()   
                {
                    Title = "Transaction Request",
                    Body = "Payment at Merchant Name",
                },

            };
            Console.WriteLine("message read");

            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            Console.WriteLine("Successfully sent message: " + response);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending notification: " + ex.Message);
        }

    }
}
