using Edifact.App.Edifact.Attributes;

namespace Edifact.App.Edifact.Segments;

// https://service.unece.org/trade/untdid/d97a/trsd/trsdbgm.htm

/// <summary>
/// Beginning of message
/// </summary>
public class BGM : Segment
{
    /// <summary>
    /// DOCUMENT/MESSAGE NAME
    /// </summary>
    [DataElement(2)]
    public C002? DocumentMessageName { get; set; }

    /// <summary>
    /// DOCUMENT/MESSAGE IDENTIFICATION
    /// </summary>
    [DataElement(3)]
    public C106? DocumentMessageIdentification { get; set; }

    /// <summary>
    /// MESSAGE FUNCTION, CODED
    /// </summary>
    [DataElement(3)]
    public string? MessageFunctionCoded { get; set; }

    /// <summary>
    /// RESPONSE TYPE, CODED
    /// </summary>
    [DataElement(4)]
    public string? ResponseTypeCoded { get; set; }
}