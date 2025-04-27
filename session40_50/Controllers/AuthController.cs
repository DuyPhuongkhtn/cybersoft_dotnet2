
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

        [HttpGet("verify-email")]
        public async Task<ActionResult> VerifyEmail([FromQuery] string token) {
            try{
                var result = await _userService.VerifyEmailAsync(token);
                if(result != null) {
                    return Ok("Email verified successfully");
                }
                return BadRequest("Invalid token");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginDTO loginDTO){
            try {
                var token = await _userService.LoginAsync(loginDTO);
                if(token == null) {
                    return BadRequest("Invalid email or password");
                }
                return Ok(token);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPassDTO forgotPassDTO){
            try {
                Console.WriteLine($"Email: {forgotPassDTO.Email}");
                var result = await _userService.ForgotPassword(forgotPassDTO.Email);
                if(result == null) {
                    return BadRequest("Invalid email");
                }
                return Ok("Password reset link sent to your email");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPassDTO resetPassDTO) {
            try {
                var result = await _userService.ResetPasswordAsync(resetPassDTO);
                if(result == null) {
                    return BadRequest("Invalid token or new password is not provided");
                }

                return Ok("Password reset successfully");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}