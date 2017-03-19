
namespace Email.Services.Models
{
    public class SendRequest
    {
        public string To { get; set; }
        public string ToName { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string HTMLBody { get; set; }
        public string TextBody { get; set; }
    }
}
