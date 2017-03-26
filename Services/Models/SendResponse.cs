
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Email.Services.Models
{
    [DataContract]
    public class SendResponse
    {
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
        
        [DataMember]
        public System.Guid EmailLogId { get; set; }
    }
}
