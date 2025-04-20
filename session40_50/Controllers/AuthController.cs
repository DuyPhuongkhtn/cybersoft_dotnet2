
using Microsoft.AspNetCore.Mvc;
using session40_50.Interfaces;
using session40_50.Models;
using session40_50.Models.DTOs;

namespace session40_50.Controllers {
    public class AuthController: ControllerBase {
        private readonly IUserService _userService;

        public AuthController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserDTO user) {
            try {
                var result = await _userService.CreateUserAsync(user);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}