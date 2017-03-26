using Email.DataProviders.Interfaces;
using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Collections.Generic;
using Email.Entities;

namespace Email.DataProviders
{
    public class EmailDataProvider : BaseDataProvider, IEmailDataProvider
    {
        private string ConnectionString { get; set; }
        private List<string> EmailLogCols { get; set; }
        private List<string> EmailLogBodyCols { get; set; }
        private readonly IConfigurationRoot configuration;
        public EmailDataProvider(IConfigurationRoot configuration)
        {
            EmailLogCols = new List<string>() { "Id", "To","ToName", "From", "FromName", "Subject", "ReferenceCode", "ThirdPartyReferenceCode","SentDate", "DeliveredDate", "OpenDate" };
            EmailLogBodyCols = new List<string>() { "EmailLogId","HTMLBody","TextBody"  };

            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "DefaultConnection");
        }

        public async Task<EmailLog> SaveLog(EmailLog log)
        {
            using(var db = new SqlConnection(ConnectionString)) {
                db.Open();
                var cols = EmailLogCols;

                if (log.Id == Guid.Empty)
                {
                    log.Id = Guid.NewGuid();
                    log.CreateDate = DateTime.UtcNow;
                    log.ModifiedDate = DateTime.UtcNow;
                    log.IsActive = true;
                    await db.ExecuteAsync(BuildInsertStatement("[email].log", cols),log);
                }
                else
                {
                    log.ModifiedDate = DateTime.UtcNow;
                    await db.ExecuteAsync(BuildUpdateStatement("[email].log", cols), log);
                }
                db.Close();

                return log;
            }
        }

        public async Task<EmailLogBody> SaveLogBody(EmailLogBody logBody)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                db.Open();

                if (logBody.CreateDate == DateTime.MinValue)
                {
                    logBody.CreateDate = DateTime.UtcNow;
                    logBody.ModifiedDate = DateTime.UtcNow;
                    logBody.IsActive = true;
                    await db.ExecuteAsync(BuildInsertStatement("[email].logBody", EmailLogBodyCols), logBody);
                }
                else
                {
                    logBody.ModifiedDate = DateTime.UtcNow;
                    await db.ExecuteAsync(BuildUpdateStatement("[email].logBody", EmailLogBodyCols), logBody);
                }
                db.Close();

                return logBody;
            }
        }
    }
}
