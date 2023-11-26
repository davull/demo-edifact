using System.Diagnostics;

namespace Edifact.App.Edifact.Attributes;

[DebuggerDisplay("{Position} {Mandatory ? \"M\" : \"C\"}")]
public class DataElementAttribute : Attribute
{
    public int Position { get; set; }

    // M/C
    public bool Mandatory { get; set; }

    public DataElementAttribute(int position)
    {
        Position = position;
    }
}