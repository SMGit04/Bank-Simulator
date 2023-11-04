using Bank_Simulator.Models;
using Bank_Simulator.Services.Interfaces.Transactions;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace Bank_Simulator.Services.Implementation.Transactions;

public class NotificationService : INotificationService
{
readonly List<string> merchantName = new List<string>
{"Ackermans"
,"ALDI"
,"Checkers"
,"Clicks"
,"Edgars"
,"Foschini"
,"Game"
,"H&M"
,"Hyperama"
,"Incredible Connection"
,"Jumbo Cash"
,"Makro"
,"Mr Price"
,"Pep"
,"Pick n Pay"
,"Shoprite"
,"Spar"
,"Totalsports"
,"Truworths"
,"Woolworths"
,"Edgars"
,"Foschini"
,"Woolworths"
,"Incredible Connection"
,"Clicks"
,"Makro"
,"Pick n Pay"
,"Shoprite"
,"Spar"};

    public async Task SendNotification()
    {
        EntityDetails transactionDetails = new EntityDetails();

        try
        {
            // Physical device
           //  var registrationToken = "e3NCy4RbQ4CgGBGXiLhOef:APA91bHB4GyXA5HbNiUG6-ERKmHMV5mUYPXF2J5ZA5jDy1NBq0g9sj106G-iXN0wNh5ZqCSjUk-62wGBRzPJoTSGkX1HOPvEz62koDzef0KY1StiE2nKlsDvOPmGsotdmmWl440aGep_";

            // HP 
            // var registrationToken = "cvKLfIfoo3tCQ8sI1MwpEi:APA91bELgNJB4ajoCFGsFVLtq89y_CJPcFa9Tt4JQaxlLOBJwcY8YUpz_ajTFtRCZS6t6-spAsD3Uiyy323HVwuTlNlx24sgm980bKYaCVdnCIp5Xi5Bs3t-S5PbtLmci7LuK-Yft_hY";

            // DELL
            var registrationToken = "cnhJo0J9SJa5g5gTUtxK0J:APA91bHjKsksHlziM0idr7erMzuJfgMTnCmUrfhLxlRbOtnvpXKItSdiEumxZMjzg8fGo_Zduf9vmFMCbPRejD6XfsA2UU08eOh65vx5_Hq723lczkIV_8N_Bv9TRkAYBMkNd8Kf6Cxf";
           
            var message = new Message()
            {
                Token = registrationToken,

                Notification = new Notification()   
                {
                    Title = "Transaction Request",
                    Body = "Transaction at " + merchantName[RandomMerchantSelector(merchantName)] // transactionDetails.MerchantName
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

    public static int RandomMerchantSelector(List<string> merchantName)
    {
        Random rand = new();
        return rand.Next(0, merchantName.Count);
    }
}
