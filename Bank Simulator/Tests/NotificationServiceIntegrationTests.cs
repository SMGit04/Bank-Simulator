//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using Bank_Simulator.Services.Implementation.Transactions;

//namespace Bank_Simulator.Test.Transactions
//{
//    [TestClass]
//    public class NotificationServiceIntegrationTests
//    {
//        private NotificationService _notificationService;

//        [TestInitialize]
//        public void Initialize()
//        {
//            // Set up your NotificationService with real Firebase credentials here
//            // Replace with your actual Firebase credentials file path
//            var firebaseCredentialsPath = @"path-to-your-firebase-credentials.json";

//            _notificationService = new NotificationService(firebaseCredentialsPath);
//        }

//        [TestMethod]
//        public void SendNotification_Success()
//        {
//            // Replace with a real registration token for a device
//            var registrationToken = "your-real-device-token";

//            // Act
//            var result = _notificationService.SendNotification(registrationToken);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.IsTrue(result.Success); // You may need to customize this assertion based on Firebase response
//        }
//    }
//}
