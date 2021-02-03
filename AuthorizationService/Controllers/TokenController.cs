using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthorizationService.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AuthorizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IAuthService authService;
        public TokenController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet]
        public IActionResult GenerateJSONWebToken()
        {
            string Token = authService.GetJsonWebToken();
            if (Token == null)
            {
                return BadRequest(Token);
            }
            else
            {
                return Ok(Token);
            }
            
        }
    }
}
