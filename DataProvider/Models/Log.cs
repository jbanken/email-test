using System;

namespace Email.DataProviders.Models
{
    public class Log
    {
        public Guid Id { get; set; }
        public string To { get; set; }
        public string ToName { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        
    }
}
