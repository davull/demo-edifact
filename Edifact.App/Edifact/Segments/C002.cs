using Edifact.App.Edifact.Attributes;
using Edifact.App.Edifact.Enums;

namespace Edifact.App.Edifact.Segments;

// https://service.unece.org/trade/untdid/d97a/trcd/trcdc002.htm

/// <summary>
/// C002 - DOCUMENT/MESSAGE NAME
/// </summary>
public class C002 : ComponentDataElement
{
    /// <summary>
    /// 1001 Document/message name, coded
    /// </summary>
    [DataElement(1)]
    public string? DocumentMessageNameCodedString { get; set; }

    public DocumentMessageName DocumentMessageNameCoded
        => Enum.Parse<DocumentMessageName>(DocumentMessageNameCodedString ?? string.Empty);

    /// <summary>
    /// 1131 Code list qualifier
    /// </summary>
    [DataElement(2)]
    public string? CodeListQualifier { get; set; }

    /// <summary>
    /// 3055 Code list responsible agency, coded
    /// </summary>
    [DataElement(3)]
    public string? CodeListResponsibleAgencyCoded { get; set; }

    /// <summary>
    /// 1000 Document/message name
    /// </summary>
    [DataElement(4)]
    public string? DocumentMessageName { get; set; }
}