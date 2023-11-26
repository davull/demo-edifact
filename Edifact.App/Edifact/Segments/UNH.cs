using Edifact.App.Edifact.Attributes;

namespace Edifact.App.Edifact.Segments;

// https://www.stylusstudio.com/edifact/40100/UNH_.htm
// UNH+1+ORDERS:D:97A:UN

/// <summary>
/// UNH - Message header
/// </summary>
public class UNH : Segment
{
    /// <summary>
    /// 0062 Message reference number
    /// </summary>
    [DataElement(2, Mandatory = true)]
    public string MessageReferenceNumber { get; set; }

    /// <summary>
    /// S009 MESSAGE IDENTIFIER
    /// </summary>
    [DataElement(3, Mandatory = true)]
    public S009 MessageIdentifier { get; set; }

    /// <summary>
    /// 0068 Common access reference
    /// </summary>
    [DataElement(4)]
    public string? CommonAccessReference { get; set; }
}