using Email.Entities;
using System.Threading.Tasks;

namespace Email.DataProviders.Interfaces
{
    public interface IEmailDataProvider
    {
        Task<EmailLog> SaveLog(EmailLog log);
        Task<EmailLogBody> SaveLogBody(EmailLogBody logBody);
    }
}
