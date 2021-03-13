using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotePadServerAPI.DAO;
using NotePadServerAPI.Models;
using NotePadServerAPI.Models.RequestCreators;
using System.Net;

namespace NotePadServerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/users/{userId}")]
    [ApiController]
    public class PurchasesController : Controller
    {
        private readonly IPurchasesDAO _purchaseDAO;
        private readonly IUsersDAO _userDAO;
        public PurchasesController(IPurchasesDAO purchaseDAO, IUsersDAO userDAO)
        {
            _purchaseDAO = purchaseDAO;
            _userDAO = userDAO;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public bool userExists(int userId)
        {
            return _userDAO.getUsers().Find(u => u.id == userId) != null;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public bool purchaseExists(int userId, int purchaseId)
        {
            return _purchaseDAO.getPurchase(userId, purchaseId) != null;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public bool correctPurchase(CreatePurchaseRequest purchase)
        {
            return purchase.cost != 0 && purchase.name != null;
        }
        /// <summary>
        /// Returns all user purchases
        /// </summary>
        /// <response code="200">Returns all user purchases</response>
        /// <response code="404">User was not found</response> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public JsonResult getPurchases(int userId)
        {
            if (!userExists(userId))
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(NotFound("User was not found"));
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(_purchaseDAO.getPurchases(userId));
        }
        /// <summary>
        /// Returns a specific user purchase
        /// </summary>
        /// <response code="200">Returns a specific user purchase</response>
        /// <response code="404">Purchase was not found</response> 
        [HttpGet("{purchaseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public JsonResult getPurchase(int userId, int purchaseId)
        {
            if (!purchaseExists(userId, purchaseId))
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(NotFound("Purchase not found"));
            }
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(_purchaseDAO.getPurchase(userId, purchaseId));
        }
        /// <summary>
        /// Creates new purchase
        /// </summary>
        /// <response code="201">The purchase was created</response>
        /// <response code="404">User was not found</response> 
        /// <response code="400">Bad request</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public JsonResult addPurchase(int userId, [FromBody] CreatePurchaseRequest purchase)
        {
            if (!userExists(userId))
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(NotFound("User was not found"));
            }
            if (!correctPurchase(purchase))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ValidationProblem());
            }
            var newPurchase = new Purchase(userId, purchase.purchaseTime, purchase.name, purchase.cost);
            _purchaseDAO.addPurchase(newPurchase);
            Response.StatusCode = (int)HttpStatusCode.Created;
            return Json(Created($"api/users/{userId}", newPurchase));
        }
        /// <summary>
        /// Deletes a purchase
        /// </summary>
        /// <response code="200">Purchase was deleted</response>
        /// <response code="404">Purchase or user was not found</response> 
        [HttpDelete("{purchaseId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public JsonResult delPurchase(int userId, int purchaseId)
        {
            if (!userExists(userId))
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(NotFound("User not found"));
            }
            if (!purchaseExists(userId, purchaseId))
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(NotFound("Purchase not found"));
            }
            var deletedPurchase = _purchaseDAO.delPurchase(userId, purchaseId);
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(Ok(deletedPurchase));
        }
    }
}
