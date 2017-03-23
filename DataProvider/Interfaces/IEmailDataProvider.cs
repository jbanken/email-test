using Email.DataProviders.Models;
using System.Threading.Tasks;

namespace Email.DataProviders.Interfaces
{
    public interface IEmailDataProvider
    {
        Task<Log> SaveLog(Log log);
        Task<LogBody> SaveLogBody(LogBody logBody);
    }
}
