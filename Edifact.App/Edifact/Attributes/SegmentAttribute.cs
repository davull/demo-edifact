using System.Diagnostics;

namespace Edifact.App.Edifact.Attributes;

[DebuggerDisplay("{Position}")]
public class SegmentAttribute : Attribute
{
    public int Position { get; }

    public SegmentAttribute(int position)
    {
        Position = position;
    }
}