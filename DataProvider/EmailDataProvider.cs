using Email.DataProviders.Interfaces;
using System;
using System.Threading.Tasks;
using Email.DataProviders.Models;

namespace Email.DataProviders
{
    public class EmailDataProvider : IEmailDataProvider
    {
        public async Task<Log> SaveLog(Log log)
        {
            return new Log();
        }

        public async Task<LogBody> SaveLogBody(LogBody logBody)
        {
            return new LogBody();
        }
    }
}
