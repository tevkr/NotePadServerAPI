using System.Collections.Generic;
using Xunit;
using NotePadServerAPI.Controllers;
using Moq;
using NotePadServerAPI.DAO;
using NotePadServerAPI.Models;
using NotePadServerAPI.Models.RequestCreators;

namespace NotePadServerAPI.Tests
{
    public class UsersControllerTest
    {
        private readonly UsersController _uController;
        private readonly Mock<IPurchasesDAO> _purchaseDAO = new Mock<IPurchasesDAO>();
        private readonly Mock<IUsersDAO> _userDAO = new Mock<IUsersDAO>();
        public UsersControllerTest()
        {
            _userDAO.Setup(f => f.getUsers())
                .Returns(new List<User>() { new User() { id = 1, name = "Vlad" } });
            _uController = new UsersController(_purchaseDAO.Object, _userDAO.Object);
        }
        [Fact]
        public void userExistsReturnFalse()
        {
            var id = 2;
            var result = _uController.userExists(id);
            Assert.False(result);
        }
        [Fact]
        public void userExistsReturnTrue()
        {
            var id = 1;
            var result = _uController.userExists(id);
            Assert.True(result);
        }
        [Fact]
        public void correctUserReturnFalse()
        {
            CreateUserRequest user = new CreateUserRequest() { name = null};
            var result = _uController.correctUser(user);
            Assert.False(result);
        }
        [Fact]
        public void correctUserReturnTrue()
        {
            CreateUserRequest user = new CreateUserRequest() { name = "some name" };
            var result = _uController.correctUser(user);
            Assert.True(result);
        }
    }
}
