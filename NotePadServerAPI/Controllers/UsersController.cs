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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersDAO _userDAO;
        public UsersController(IUsersDAO userDAO)
        {
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
        [HttpGet]
        public JsonResult getUsers()
        {
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(_userDAO.getUsers());
        }
        [HttpPost]
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
        [HttpDelete("{userId}")]
        public JsonResult delUser(int userId)
        {
            if (!userExists(userId))
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(NotFound("User was not found"));
            }
            Response.StatusCode = (int)HttpStatusCode.NoContent;
            _userDAO.delUser(userId);
            return Json(NoContent());
        }
    }
}
