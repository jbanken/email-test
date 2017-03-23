using Email.Services.Interfaces;
using System.Threading.Tasks;
using Email.Services.Models;
using Email.DataProviders.Interfaces;

namespace Email.Services
{
    public class SendService : ISendService
    {
        private IEmailDataProvider _emailDataProvider { get; set; }

        public SendService(IEmailDataProvider emailDataProvider)
        {
            _emailDataProvider = emailDataProvider;
        }

        public async Task<SendResponse> Send(SendRequest request)
        {
            var log = new DataProviders.Models.Log();
            log = await _emailDataProvider.SaveLog(log);

            var logBody = new DataProviders.Models.LogBody();
            logBody.EmailLogId = log.Id;
            await _emailDataProvider.SaveLogBody(logBody);

            var response = new SendResponse() { Status = Status.Queued };
            return response;
        }
    }
}
