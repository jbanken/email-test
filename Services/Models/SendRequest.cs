
namespace Email.Services.Models
{
    public class SendRequest
    {
        public string To { get; set; }
        public string ToName { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
        public string ReferenceCode { get; set; }
        public string ThirdPartyReferenceCode { get; set; }
        public string Subject { get; set; }
        public string HTMLBody { get; set; }
        public string TextBody { get; set; }

        public Entities.EmailLog ToEmailLog()
        {
            return new Entities.EmailLog()
            {
                To = To
                , ToName = ToName
                , From = From
                , FromName = FromName
                , Subject = Subject
                , ReferenceCode = ReferenceCode
                , ThirdPartyReferenceCode = ThirdPartyReferenceCode
            };
        }

        public Entities.EmailLogBody ToEmailLogBody()
        {
            return new Entities.EmailLogBody()
            {
                TextBody = TextBody
                , HTMLBody = HTMLBody
            };
        }
    }
}
