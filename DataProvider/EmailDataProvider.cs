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
        private readonly IConfigurationRoot configuration;
        public EmailDataProvider(IConfigurationRoot configuration)
        {
            EmailLogCols = new List<string>();
            EmailLogCols.Add("Id");
            EmailLogCols.Add("To");
            EmailLogCols.Add("ToName");
            EmailLogCols.Add("From");
            EmailLogCols.Add("FromName");
            EmailLogCols.Add("Subject");
            EmailLogCols.Add("ReferenceCode");
            EmailLogCols.Add("ThirdPartyReferenceCode");
            EmailLogCols.Add("SentDate");
            EmailLogCols.Add("DeliveredDate");
            EmailLogCols.Add("OpenDate");

            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "DefaultConnection");
        }

        public async Task<EmailLog> SaveLog(EmailLog log)
        {
            using(var db = new SqlConnection(ConnectionString)) {
                db.Open();

                if (log.Id == Guid.Empty)
                {
                    log.Id = Guid.NewGuid();
                    try {
                        
                         await db.ExecuteAsync(BuildInsertStatement("[email].log",EmailLogCols),log);
                    }
                    catch(Exception ex)
                    {
                        var one = 1;
                    }
                }
                else
                {
                    await db.ExecuteAsync(BuildUpdateStatement("[email].log", EmailLogCols), log);
                }
                db.Close();

                return log;
            }
        }

        public async Task<EmailLogBody> SaveLogBody(EmailLogBody logBody)
        {
            return new EmailLogBody();
        }
    }
}
