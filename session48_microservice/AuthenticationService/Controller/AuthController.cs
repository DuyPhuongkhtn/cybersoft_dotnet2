
using AuthenticationService.DTOs;
using AuthenticationService.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controller {

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase {
        private readonly AuthService _authService;

        public AuthController(AuthService authService) {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterDTO request) {
            try
            {
                var response = await _authService.Register(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}