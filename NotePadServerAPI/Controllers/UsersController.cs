using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotePadServerAPI.DAO;
using NotePadServerAPI.Models;
using NotePadServerAPI.Models.RequestCreators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NotePadServerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IPurchasesDAO _purchaseDAO;
        private readonly IUsersDAO _userDAO;
        public UsersController(IPurchasesDAO purchaseDAO, IUsersDAO userDAO)
        {
            _purchaseDAO = purchaseDAO;
            _userDAO = userDAO;
        }
        /// <summary>
        /// Сhecking the user's existence
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>User existence</returns>
        protected bool userExists(int userId)
        {
            return _userDAO.getUsers().Find(u => u.id == userId) != null;
        }
        /// <summary>
        /// Checking the validity of the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Validity of the user</returns>
        protected bool correctUser(CreateUserRequest user)
        {
            return user.name != null && user.name != "";
        }
        /// <summary>
        /// Returs all users
        /// </summary>
        /// <response code="200">Returns all users</response> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public JsonResult getUsers()
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(_userDAO.getUsers());
        }
        /// <summary>
        /// Сreates a new user by name
        /// </summary>
        /// <response code="201">User was created</response> 
        /// <response code="400">Bad request</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public JsonResult addUser(CreateUserRequest user)
        {
            if (!correctUser(user))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ValidationProblem());
            }
            var newUser = new User(user.name);
            _userDAO.addUser(newUser);
            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(Created("api/users", newUser));
        }
        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <response code="204">User was deleted</response> 
        /// <response code="404">User was not found</response> 
        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public JsonResult delUser(int userId)
        {
            if (!userExists(userId))
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(NotFound("User was not found"));
            }
            Response.StatusCode = (int)HttpStatusCode.NoContent;
            _purchaseDAO.delUserPurchases(userId);
            _userDAO.delUser(userId);
            return Json(NoContent());
        }
    }
}
