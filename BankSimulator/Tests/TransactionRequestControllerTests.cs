//using Bank_Simulator.Controllers;
//using Bank_Simulator.Models;
//using Bank_Simulator.Orchestration.Interfaces;
//using Bank_Simulator.Services.Implementation.Transactions;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Routing;
//using Moq;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace Bank_Simulator.Tests
//{
//    [TestFixture]
//    public class TransactionRequestControllerTests
//    {
//        private Mock<ITransactionStatusOrchestration> _transactionStatusOrchestrationMock;
//        private TransactionService _transactionService;
//        private TransactionRequestController _controller;

//        [SetUp]
//        public void Setup()
//        {
//            _transactionStatusOrchestrationMock = new Mock<ITransactionStatusOrchestration>();
//            _transactionService = new TransactionService();
//            _controller = new TransactionRequestController(_transactionStatusOrchestrationMock.Object, _transactionService);
//        }

//        [Test]
//        public async Task DataFromUserEndpoint_ReturnsBadRequest_ForInvalidModel()
//        {
//            // Arrange
//            _controller.ModelState.AddModelError("error", "some error");

//            // Act
//            var result = await _controller.DataFromUserEndpoint(new EntityDetails());

//            // Assert
//            Assert.IsInstanceOf<BadRequestObjectResult>(result);
//            var badRequestResult = result as BadRequestObjectResult;
//            Assert.AreEqual("Transaction declined or timeout", badRequestResult.Value);
//        }

//        [Test]
//        public async Task DataFromUserEndpoint_ReturnsOk_WhenAuthenticated()
//        {
//            // Arrange
//            var entityDetails = new EntityDetails { IDNumber = "12345" };

//            _transactionStatusOrchestrationMock
//                .Setup(x => x.ApproveOrDeclineTransaction(It.IsAny<EntityDetails>(), It.IsAny<bool>()))
//                .Returns(new TransactionStatusResult { /*... fill properties as needed ...*/ });

//            // Simulate approving the transaction by another thread
//            _ = Task.Run(() =>
//            {
//                _transactionService.PendingAuths.TryGetValue(entityDetails.IDNumber, out var tcs);
//                tcs.SetResult(true);
//            });

//            // Act
//            var result = await _controller.DataFromUserEndpoint(entityDetails);

//            // Assert
//            Assert.IsInstanceOf<OkObjectResult>(result);
//            var okResult = result as OkObjectResult;
//            Assert.IsInstanceOf<TransactionStatusResult>(okResult.Value);
//        }

//        [Test]
//        public void TransactionRequest_ReturnsBadRequest_WhenNotFound()
//        {
//            // Arrange
//            var authorization = new ApprovalRequestResultModel { userID = "12345", isApproved = true };

//            // Act
//            var result = _controller.TransactionRequest(authorization);

//            // Assert
//            Assert.IsInstanceOf<BadRequestResult>(result);
//        }

//        [Test]
//        public void TransactionRequest_ReturnsOk_WhenFound()
//        {
//            // Arrange
//            var authorization = new ApprovalRequestResultModel { userID = "12345", isApproved = true };
//            _transactionService.PendingAuths.TryAdd(authorization.userID, new TaskCompletionSource<bool>());

//            // Act
//            var result = _controller.TransactionRequest(authorization);

//            // Assert
//            Assert.IsInstanceOf<OkResult>(result);
//        }
//    }
//}

