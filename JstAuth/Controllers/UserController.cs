using JstAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JstAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("Directors")]
        [Authorize(Roles = "Director")]
        public IActionResult AdminsEndpoints() 
        { 
            var currentUser = GetCurrentUser();

            return Ok($"Hello {currentUser.GivenName}, you are a {currentUser.Role}");
        }


        [HttpGet("Professors")]
        [Authorize(Roles = "Professor")]
        public IActionResult SellersEndpoints()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hello {currentUser.GivenName}, you are a {currentUser.Role}");
        }

        [HttpGet("Students")]
        [Authorize(Roles = "Student")]
        public IActionResult StudentsEndpoints()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hello {currentUser.GivenName}, you are a {currentUser.Role}");
        }

        [HttpGet("DirectorsProfessors")]
        [Authorize(Roles = "Director,Professor")]
        public IActionResult AdminsSellersEndpoints()
        {
            var currentUser = GetCurrentUser();

            return Ok($"Hello {currentUser.GivenName}, you are a {currentUser.Role}");
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hello, you are in a public property");
        }

        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null) {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                    GivenName = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value,
                    Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;
        }
    }
}
