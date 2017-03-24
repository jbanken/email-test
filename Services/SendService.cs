using Email.Services.Interfaces;
using System.Threading.Tasks;
using Email.Services.Models;
namespace Email.Services
{
    public class SendService : ISendService
    {
        private DataProviders.Interfaces.IEmailDataProvider _emailDataProvider { get; set; }

        public SendService(DataProviders.Interfaces.IEmailDataProvider emailDataProvider)
        {
            _emailDataProvider = emailDataProvider;
        }

        public async Task<SendResponse> Send(SendRequest request)
        {
            var log = new Entities.EmailLog();
            log.To = request.To;
            log.From = request.From;
            log = await _emailDataProvider.SaveLog(log);

            var logBody = new Entities.EmailLogBody();
            logBody.EmailLogId = log.Id;
            await _emailDataProvider.SaveLogBody(logBody);

            var response = new SendResponse() { Status = Status.Queued };
            return response;
        }
    }
}
