using System.ComponentModel;

namespace TaskManager.Domain.Models
{
    public enum Importance : byte
    {
        [Description("low")]
        Low = 1,
        [Description("medium")]
        Medium = 2,
        [Description("high")]
        High = 3
    }
}