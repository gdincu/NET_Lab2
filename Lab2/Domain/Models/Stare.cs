using System.ComponentModel;

namespace TaskManager.Domain.Models
{
    public enum Stare : byte
    {
        [Description("open")]
        Open = 1,
        [Description("inprogress")]
        InProgress = 2,
        [Description("closed")]
        Closed = 3
    }
}
