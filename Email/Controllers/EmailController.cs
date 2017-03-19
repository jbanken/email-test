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
        // POST api/values
        [HttpPost]
        public async Task<ObjectResult> Post([FromBody]Email.Services.Models.SendRequest request)
        {
            var response = await _emailService.Send(request);

            return Ok(response);
        }

    }
}