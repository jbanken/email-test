using System;

namespace Email.DataProviders.Models
{
    public class LogBody
    {
        public Guid EmailLogId { get; set; }
        public string HTMLBody { get; set; }
        public string TextBody { get; set; }
    }
}
