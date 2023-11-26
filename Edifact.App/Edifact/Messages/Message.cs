using Edifact.App.Edifact.Attributes;
using Edifact.App.Edifact.Segments;

namespace Edifact.App.Edifact.Messages;

public abstract class Message
{
    /// <summary>
    /// Message header
    /// </summary>
    [Segment(1)]
    public UNH UNH { get; set; }
}