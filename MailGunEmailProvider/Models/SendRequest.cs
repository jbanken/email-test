namespace Email.MailGunEmailProvider.Models
{
    public class SendRequest
    {
        public string to { get; set; }
        public string from { get; set; }
        public string subject { get; set; }
        public string text { get; set; }
        public string html { get; set; }
    }
}
