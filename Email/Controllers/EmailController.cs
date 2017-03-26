using Microsoft.AspNetCore.Mvc;
using Email.Services.Interfaces;
using System.Threading.Tasks;

namespace Email.Controllers
{
    [Produces("application/json")]
    [Route("api/email")]
    public class EmailController : Controller
    {

        private readonly ISendService _emailService;

        public EmailController(ISendService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Services.Models.SendRequest request)
        {
            var response = await _emailService.Send(request);

            return Created("api/email/"+response.EmailLogId, response);
        }

    }
}