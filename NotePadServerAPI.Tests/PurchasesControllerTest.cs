using Moq;
using NotePadServerAPI.Controllers;
using NotePadServerAPI.DAO;
using NotePadServerAPI.Models;
using NotePadServerAPI.Models.RequestCreators;
using System;
using Xunit;

namespace NotePadServerAPI.Tests
{
    public class PurchasesControllerTest
    {
        private readonly PurchasesController _pController;
        private readonly Mock<IPurchasesDAO> _purchaseDAO = new Mock<IPurchasesDAO>();
        private readonly Mock<IUsersDAO> _userDAO = new Mock<IUsersDAO>();
        public PurchasesControllerTest()
        {
            _purchaseDAO.Setup(f => f.getPurchase(1, 1))
                .Returns(new Purchase() { id = 1, userId = 1, name = "purchase_name", 
                    cost = 1337, purchaseTime = new DateTime(2011,11,11,11,11,11) });
            _purchaseDAO.Setup(f => f.getPurchase(1, 0))
                .Returns((Purchase)null);
            _pController = new PurchasesController(_purchaseDAO.Object, _userDAO.Object);
        }
        [Fact]
        public void purchaseExistsReturnFalse()
        {
            var userId = 1;
            var id = 0;
            var result = _pController.purchaseExists(userId, id);
            Assert.False(result);
        }
        [Fact]
        public void purchaseExistsReturnTrue()
        {
            var userId = 1;
            var id = 1;
            var result = _pController.purchaseExists(userId, id);
            Assert.True(result);
        }
        [Fact]
        public void correctPurchaseReturnFalseWhileNameIsNull()
        {
            CreatePurchaseRequest purchase = new CreatePurchaseRequest()
            {
                name = null,
                cost = 1337,
                purchaseTime = new DateTime(2011, 11, 11, 11, 11, 11)
            };
            var result = _pController.correctPurchase(purchase);
            Assert.False(result);
        }
        [Fact]
        public void correctPurchaseReturnFalseWhileCostIsNull()
        {
            CreatePurchaseRequest purchase = new CreatePurchaseRequest()
            {
                name = "some name",
                cost = 0,
                purchaseTime = new DateTime(2011, 11, 11, 11, 11, 11)
            };
            var result = _pController.correctPurchase(purchase);
            Assert.False(result);
        }
        [Fact]
        public void correctPurchaseReturnTrue()
        {
            CreatePurchaseRequest purchase = new CreatePurchaseRequest()
            {
                name = "some name",
                cost = 1337,
                purchaseTime = new DateTime(2011, 11, 11, 11, 11, 11)
            };
            var result = _pController.correctPurchase(purchase);
            Assert.True(result);
        }
    }
}
