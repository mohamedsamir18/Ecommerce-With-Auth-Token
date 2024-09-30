using EcommerceAuthToken.Models;
using EcommerceAuthToken.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAuthToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservice;
        public AuthController(IAuthService authservice)
        {
            _authservice = authservice;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]Register model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authservice.RegisterAsync(model);
            if (!result.IsAuth)
                return BadRequest(result.Message);


            return Ok(new { token=result.Token , expires = result.Expireson });
        }
        [HttpPost("Login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authservice.GetTokenAsync(model);
            if (!result.IsAuth)
                return BadRequest(result.Message);


            return Ok(result);
        }


        [Authorize(Roles ="SuperAdmin")]
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRole model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authservice.AddRoleAsync(model);
            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);


            return Ok(model);
        }
    }
}
