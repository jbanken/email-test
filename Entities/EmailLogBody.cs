using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Email.Entities
{
    [Table("Email.LogBody")]
    public class EmailLogBody
    {
        public Guid EmailLogId { get; set; }
        public string HTMLBody { get; set; }
        public string TextBody { get; set; }
        public EmailLog Log { get; set; }
    }
}
