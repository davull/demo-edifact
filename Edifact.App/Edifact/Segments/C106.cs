using Edifact.App.Edifact.Attributes;

namespace Edifact.App.Edifact.Segments;

// https://service.unece.org/trade/untdid/d97a/trcd/trcdc106.htm

/// <summary>
/// DOCUMENT/MESSAGE IDENTIFICATION
/// </summary>
public class C106 : ComponentDataElement
{
    /// <summary>
    /// 1004 Document/message number
    /// </summary>
    [DataElement(1)]
    public string MessageReferenceNumber { get; set; }

    /// <summary>
    /// 1056 Version
    /// </summary>
    [DataElement(2)]
    public string Version { get; set; }

    /// <summary>
    /// 1060 Revision number
    /// </summary>
    [DataElement(3)]
    public string RevisionNumber { get; set; }
}