using CoreAssignment.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IDataRepository<User> _dataRepository;
        private readonly IConfiguration _configuration;
        public AuthenticationController(IDataRepository<User> dataRepository, IConfiguration configuration)
        {
            _dataRepository = dataRepository;
            _configuration = configuration;
        }

        /// <summary>
        /// Get Blogs
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Login login)
        {
            IEnumerable<User> users = _dataRepository.GetAll();
            User user = users.FirstOrDefault(x => x.UserName == login.UserName);
            if(user!=null)
            {
                string accessToken = JWTTokenCreator.GetToken(GetClaims(user), _configuration);
            }
            return Unauthorized();
            
        }

        #region Private Methods
        private IEnumerable<Claim> GetClaims(User user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("UserId", user.UserID.ToString()));
            claims.Add(new Claim("Role", user.Role.ToString()));
            return claims;
        }

        #endregion
    }
}
