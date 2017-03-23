
using System.Runtime.Serialization;

namespace Email.Services
{
    public enum Status
    {
        [EnumMember(Value = "Queued")]
        Queued,

        [EnumMember(Value = "Sent")]
        Sent,

        [EnumMember(Value = "Delivered")]
        Delivered,

        [EnumMember(Value = "Opened")]
        Opened
    }
}
