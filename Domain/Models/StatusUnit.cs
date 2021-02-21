using System.ComponentModel;

namespace filed.Domain.Models
{
    public enum StatusUnit : byte
    {
        [Description("P")]
        Pending = 1,

        [Description("S")]
        Processed = 2,

        [Description("F")]
        Failed = 3,
    }
}