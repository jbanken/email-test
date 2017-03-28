namespace Email.MailGunEmailProvider.Models
{
    public class SendResponse
    {
        public string Content { get; set; }
        public System.Net.HttpStatusCode StatusCode { get; set; }
        public string Id { get; set; }
    }
}
