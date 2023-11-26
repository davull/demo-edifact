using Edifact.App.Edifact.Attributes;

namespace Edifact.App.Edifact.Segments;

/// <summary>
/// S009 - MESSAGE IDENTIFIER
/// </summary>
public class S009 : ComponentDataElement
{
    /// <summary>
    /// 0065 Message type
    /// </summary>
    [DataElement(1, Mandatory = true)]
    public string MessageType { get; set; }

    /// <summary>
    /// 0052 Message version number
    /// </summary>
    [DataElement(2, Mandatory = true)]
    public string MessageVersionNumber { get; set; }

    /// <summary>
    /// 0054 Message release number
    /// </summary>
    [DataElement(3, Mandatory = true)]
    public string MessageReleaseNumber { get; set; }

    /// <summary>
    /// 0051 Controlling agency, coded
    /// </summary>
    [DataElement(4, Mandatory = true)]
    public string ControllingAgencyCoded { get; set; }

    /// <summary>
    /// 0057 Association assigned code
    /// </summary>
    [DataElement(5)]
    public string? AssociationAssignedCode { get; set; }

    /// <summary>
    /// 0110 Code list directory version number
    /// </summary>
    [DataElement(6)]
    public string? CodeListDirectoryVersionNumber { get; set; }

    /// <summary>
    /// 0113 Message type sub-function identification
    /// </summary>
    [DataElement(7)]
    public string? MessageTypeSubFunctionIdentificationCode { get; set; }
}