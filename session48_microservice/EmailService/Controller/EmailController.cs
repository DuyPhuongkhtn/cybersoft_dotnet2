using Microsoft.AspNetCore.Mvc;
using EmailService.Services;
using EmailService.DTOs;

namespace EmailService.Controller {
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController: ControllerBase {
        private readonly Services.EmailService _emailService;

        public EmailController(Services.EmailService emailService) {
            _emailService = emailService;
        }

        [HttpPost("welcome")]
        public async Task<ActionResult> SendWelcomeEmail([FromBody] WelcomeEmailRequest request){
            try
            {
                await _emailService.SendWelcomeEmail(request.Email, request.Username);
                return Ok("Email sent successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}