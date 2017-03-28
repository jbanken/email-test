using Email.Services.Interfaces;
using System.Threading.Tasks;
using Email.Services.Models;
using Email.DataProviders.Interfaces;
using Email.MailGunEmailProvider.Interfaces;
namespace Email.Services
{
    public class SendService : ISendService
    {
        private IEmailDataProvider _emailDataProvider { get; set; }
        private IMailGunService _mailGunService { get; set; }

        public SendService(IEmailDataProvider emailDataProvider, IMailGunService mailGunService)
        {
            _emailDataProvider = emailDataProvider;
            _mailGunService = mailGunService;
        }

        public async Task<SendResponse> Send(SendRequest request)
        {
            var log = request.ToEmailLog();
            log = await _emailDataProvider.SaveLog(log);

            var logBody = request.ToEmailLogBody();
            logBody.EmailLogId = log.Id;
            await _emailDataProvider.SaveLogBody(logBody);

            await SendToProvider(log, logBody); //swap out with strategy
            var response = new SendResponse() { Status = Status.Queued };

            response.EmailLogId = log.Id;
            return response;
        }

        private async Task SendToProvider(Entities.EmailLog log,Entities.EmailLogBody logBody)
        {
            var mailGunResponse = await _mailGunService.Send(new MailGunEmailProvider.Models.SendRequest()
            {
                to = ""xxx"//log.To  TODO Test data
                , from = log.From
                , subject = log.Subject
                , html = logBody.HTMLBody
                , text = logBody.TextBody
            });
            log.ThirdPartyReferenceCode = mailGunResponse.Id;
            log.SentDate = System.DateTime.UtcNow;
            log = await _emailDataProvider.SaveLog(log);
        }
    }
}
