using ExamRoomBackend.Models;
using ExamRoomBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamRoomBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public HomeController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("verifyByEmail")]
        public IActionResult GetVerificationEmail()
        {
            try
            {
                // credentials to send 
                UserEmailOptions options = new UserEmailOptions
                {
                    PlaceHolders = new List<KeyValuePair<string, string>>()
                    {
                    new KeyValuePair<string, string>("{{ UserName }}", "John"),
                    new KeyValuePair<string, string>("{{ Code }}", _emailService.GenerateVerificationCode())
                    }
                };
                // send the email 
                _emailService.SendVerificationEmail(options);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest($"Error occured: {ex.Message}");
            }
        }

        [HttpPost("verifyBySMS")]
        public IActionResult GetVerificationSMS()
        {
            try
            {
                _emailService.SendVerificationSMS("+2348080978412", _emailService.GenerateVerificationCode(), "John");
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest($"Error occured: {ex.Message}");
            }
        }

    }
}
