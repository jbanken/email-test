using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Email.Entities
{
    [Table("Email.Log")]
    public class EmailLog
    {
        public Guid Id { get; set; }
        [Required]
        public string To { get; set; }
        public string ToName { get; set; }
        [Required]
        public string From { get; set; }
        public string FromName { get; set; }
        public string Subject { get; set; }
        public string ReferenceCode { get; set; }
        public string ThirdPartyReferenceCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public EmailLogBody Body { get; set; }
        public DateTime? SentDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public DateTime? OpenDate { get; set; }
    }
}
