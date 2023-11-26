using Edifact.App.Edifact.Attributes;

namespace Edifact.App.Edifact.Segments;

public abstract class Segment
{
    [DataElement(1, Mandatory = true)]
    public string SegmentName { get; set; }
}